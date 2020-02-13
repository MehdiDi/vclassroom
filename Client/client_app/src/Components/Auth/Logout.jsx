import React from 'react';
import UserManager from '../../Managers/UserManager';
import {Button} from 'antd'
import routes from '../Routes/RoutesList'

const Logout = props => {
    UserManager.logOut();
    
    return (
        <div>
            <h1>You have been logged out</h1>
            <Button onClick={() => props.history.push(routes.landing)}>Go Home</Button>
        </div>
    );
};

export default Logout;
