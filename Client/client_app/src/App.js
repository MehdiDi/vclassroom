import React from 'react';
import {BrowserRouter as Router, Route , Switch} from 'react-router-dom'
import './App.css'
import Landing from './Components/Home/Landing/Index'
import ProtectedRoute from './Components/Routes/ProtectedRoutes'
import Application from './Components/Home/Application/Application'
import Auth from './Components/Auth/Auth'
import Logout from './Components/Auth/Logout'

function App() {
  return (
    <div className="App">
      <Router>
        <Switch>
          <Route exact path="/" component={ Landing} />
          <ProtectedRoute path="/home" component={Application} />
          <Route exact path="/auth" component={Auth} />
          <Route exact path="/logout" component={Logout}/>
        </Switch>
      </Router>
    </div>
  );
}

export default App;
