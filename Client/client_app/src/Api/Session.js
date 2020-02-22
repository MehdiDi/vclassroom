import axios from 'axios'
import getHeadersWithBearer from './Config'

const apiurl = process.env.REACT_APP_DEV_API;

export const updateSessions = async data => {
    const res = await axios.put(apiurl + '/sessions', {sessions: data}, getHeadersWithBearer());
    return res.data;
}