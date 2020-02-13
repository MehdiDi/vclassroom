import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import UserManager from '../../Managers/UserManager';

function ProtectedRoute({component: Component, ...otherProps}) {

    if(UserManager.isLoggedIn())
        return <Route {...otherProps} 
        render={ props =>
            <Component {...props} user={UserManager.getUser()}/> } 
        />;
    else {
        const redirectUrl = "/auth?page=" + otherProps.location.pathname;
        return <Redirect to={redirectUrl} />;
    }
}

export default ProtectedRoute