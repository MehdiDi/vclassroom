import React, { Component } from 'react';
import Login from './Login';
import Register from './Register/Register';
import { Radio } from 'antd';

export class Auth extends Component {
    constructor(props) {
        super(props);
        this.state = {
            currentPage: "login"
        };
    }
    onCurrentPageChange = (e) =>  {
        this.setState({currentPage: e.target.value});
    }
    
    storeToken = token => {
        localStorage.setItem("token", token);
    }
    
    render() {
        const comp = this.state.currentPage === "login" ?
            <Login storeAccessToken={this.storeToken} /> : <Register storeAccessToken={this.storeToken} />
        return (
            <div>
                <Radio.Group value={this.state.currentPage} onChange={this.onCurrentPageChange}>
                    <Radio.Button value="login">Login</Radio.Button>
                    <Radio.Button value="register">Register</Radio.Button>
                </Radio.Group>
                { comp }
            </div>
        )
    }
}

export default Auth
