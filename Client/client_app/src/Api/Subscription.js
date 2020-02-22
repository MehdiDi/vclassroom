import axios from 'axios'
import getHeadersWithBearer from './Config';

const apiurl = process.env.REACT_APP_DEV_API;

export const getSubscriptions = async () => {
    const res = await axios.get(apiurl + '/subscriptions', getHeadersWithBearer());
    return res.data.subscriptions;
}
export const addSubscription = async CourseId => {
    const res = await axios.post(apiurl + '/subscriptions', { CourseId }, getHeadersWithBearer());
    return res.data
}
export const removeSubscription = async courseId => {
    const res = await axios.delete(apiurl + '/subscriptions/' + courseId, getHeadersWithBearer());
    return res.data;
}