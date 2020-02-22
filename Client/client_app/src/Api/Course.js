import axios from 'axios'
import querystring from 'query-string';
import getHeadersWithBearer from './Config';

const apiurl = process.env.REACT_APP_DEV_API;

export const getCourses = async (sortby="", filter="", page, limit) => {
 
    const options = {
        sortby,
        filter,
        page,
        limit
    };
    const qs = querystring.stringify(options);

    const res = await axios.get(apiurl + '/courses?' + qs, getHeadersWithBearer());

    return res.data;
}
export const getAllCourses = async () => {
    const res = await axios.get(apiurl + '/courses/all', getHeadersWithBearer());

    return res.data;
}
export const createCourse = async course => {
    const res = await axios.post(apiurl + '/courses', course, getHeadersWithBearer());
    return res.data;
}

export const updateCourse = async course => {
    const res = await axios.put(apiurl + '/courses', course, getHeadersWithBearer());
    return res.data;
}
export const deleteCourse = async id => {
    const res = await axios.delete(apiurl + '/courses/' + id, getHeadersWithBearer());
    return res.data;
}
