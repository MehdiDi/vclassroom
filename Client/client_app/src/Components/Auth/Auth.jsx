import React, { Component } from 'react';
import Login from './Login';
import Register from './Register/Register';
import { Radio } from 'antd';
import querystring from 'query-string';
import {redirectPage} from '../../Keys/QueryStrings';
import routes from '../Routes/RoutesList';
import User from '../../Managers/UserManager';

export class Auth extends Component {
    constructor(props) {
        super(props);
        this.state = {
            currentPage: "login",
            redirect: null
        };
        this.ref = React.createRef();
    }
    componentWillMount() {
        if(User.isLoggedIn()) {
            this.props.history.push(routes.home);
        }
    }
    onCurrentPageChange = (e) =>  {
        this.setState({currentPage: e.target.value});
    }
    componentDidMount() {
        this.getRedirectPage();
    }
    getRedirectPage = () => {
        const qs = querystring.parse(this.props.location.search);
        if(redirectPage in qs) {
            this.setState({
                redirect: qs[redirectPage]
            });
        }
    }
    
    loggedInCB = token => {
        User.login(token);
    }

    redirect = () => {
        const path = this.state.redirect;
        if(path != null) {
            this.props.history.push(path);
        }
        else {
            this.props.history.push(routes.home);
        }
    }
    
    render() {
        const comp = this.state.currentPage === "login" ?
            <Login redirect={this.redirect} onLoggedIn={this.loggedInCB} />
             :
            <Register redirect={this.redirect} onLoggedIn={this.loggedInCB} />;
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
