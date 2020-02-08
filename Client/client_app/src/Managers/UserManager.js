import User from '../Models/User'
const decode = require('jwt-decode');

class UserManager {
    
    constructor(keyName) {
        this.keyName = keyName;
        this.loadUser();
    }

    loadUser() {
        if(this.keyName in localStorage) 
        {
            const token = localStorage.getItem(this.keyName);
    
            const data = decode(token);
            this.userId = data.sub;
            var exp = data.exp * 1000;
            
            if(exp > Date.now()) {
                this.user = new User(data.sub, data.userName, data.email);
                this.token = token;
            }
        }
    }
    getUserId(){
        return this.user.id;
    }
    isLoggedIn() {
        return this.user !== undefined && this.user !== null;
    }
    getToken(){
        return this.token;
    }
}
export default new UserManager("token");