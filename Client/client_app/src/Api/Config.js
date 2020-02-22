import UserManager from '../Managers/UserManager';

const getHeadersWithBearer = () =>({
    headers: {
        Authorization: `Bearer ${UserManager.getToken()}`,
        'Content-Type': "application/json"
    }
})
console.log("Config!!")

export default getHeadersWithBearer;