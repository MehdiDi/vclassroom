import React, { Component } from 'react'
import Navigation from './Menu/Navigation'
import {Route} from 'react-router-dom'
import routes from '../../Routes/RoutesList'
import Courses from './Course/Courses'
import './Application.css'


export class Home extends Component {
    constructor(props) {
        super(props);
        this.state = {
          current: null,
        };
      }
      getKeyFormRouteValue = value => {
        for(let key in routes) {
            if(routes[key] === value) {
                return key;
            }
        }
        return null;
      }
    componentDidMount() {

    }

    handleRouteChange = key => {
        this.setState({
            current: key
        });
        let path = this.props.match.path;
        if(key !== '0')
            path = this.props.match.path + routes[key];
        
        this.props.history.push(path);
    }

    render() {
        return (
            <>
                <div className="header">

                </div>
                <div className="app-container">
                    <Navigation theme="dark"
                        user={this.props.user}
                        changeRoute={this.handleRouteChange}
                        current={this.state.current}
                    />
                    <div className="app-content">
                        <Route exact path={this.props.match.path + routes.courses} component={Courses} />
                        <Route exact path={this.props.match.path + routes.messages} component={() => <h1>Messages</h1>} />
                    </div>
                </div>
            </>
        )
    }
}

export default Home
