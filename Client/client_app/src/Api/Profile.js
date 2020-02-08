import axios from 'axios'
import userManager from '../Managers/UserManager'

const baseUrl = process.env.REACT_APP_DEV_API;


export async function AddProfile(data) {
    const token = userManager.getToken();
    const config = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    }
    await axios.post(baseUrl + '/profile/create', {
        ...data, 
        UserId: userManager.getUserId()
    }, config);
}