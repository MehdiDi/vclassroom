import axios from 'axios'

const apiurl = process.env.REACT_APP_DEV_API;

export const register = async data => {
    const response = await axios.post(apiurl + '/auth/register', {
        ...data
    });
    return response.data.token;
}
export const login = async data => {
    const response = await axios.post(apiurl + '/auth/login', {
       ...data 
    });
    return response.data.token;
}