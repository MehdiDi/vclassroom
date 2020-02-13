import UserManager from '../Managers/UserManager';

const getHeadersWithBearer = () =>({
    headers: {
        Authorization: `Bearer ${UserManager.getToken()}`
    }
})
console.log("Config!!")

export default getHeadersWithBearer;