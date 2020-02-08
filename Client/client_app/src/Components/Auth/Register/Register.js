import React, { Component } from 'react'
import { Form, Steps, Icon } from 'antd'
import axios from 'axios'
import Step1 from './Step1'
import Step2 from './Step2'
import { AddProfile} from '../../../Api/Profile'


const  { Step } = Steps;

const apiurl = process.env.REACT_APP_DEV_API;

export class Register extends Component {
    constructor(props) {
        super(props);
        this.state = {
            steps: [
                new StepData("User Data", "login", Step1, this.handleRegister),
                new StepData("Instructor informations", "solution", Step2, this.handleProfileSubmit)
            ],
            index: 0
        };
    }
    componentDidMount() {
        
    }
    next = () => {
        let index = this.state.index;
        if(index  < this.state.steps.length - 1) {
            index++;
            this.setState({index});
        }
        else {
            console.log("Registeration Done!");
        }
    }
    handleRegister = async data => {
        try{
            const response = await axios.post(apiurl + '/auth/register', {
                ...data
            });
            
            this.props.storeAccessToken(response.data.token);

            this.next();

        }
        catch(err) {
            console.error(err.message);
        }
    }

    
    handleProfileSubmit = async data => {
        try {
            await AddProfile(data);

            this.next();
            
        } catch (error) {
            console.log(error.message);   
        }
    }

    getStatus = i => {
        const { index } = this.state;
        if(i > index) {
            return "wait";
        }
        else if(i === index) {
            return "process";
        }
        else {
            return "done";
        }
    }
    handleSubmit = (index, data) => {
        const steps = Object.assign({}, this.state.steps[index]);
        steps.values = data;
        this.setState({ steps: data });
    };
    isLast = () => this.state.index === this.state.steps.length - 1;
    render() {
        const { index, steps } = this.state;
        var c = steps[index];
        const stepsMap = steps.map((s, i) => 
            <Step key={i} status={this.getStatus(i) } title={s.title} 
                icon={<Icon type={index === i ? "loading" : s.icon}/>}
            />
        );
        const CurrentComponent =  Form.create({ name: 'register_form' })(c.component); ;
        return (
            <div>
                <Steps>
                    {stepsMap}
                </Steps>
                <CurrentComponent fn={c.fn} submitText={this.isLast() ? "Finish" : "Next" } values={c.values} onSubmit={this.handleSubmit} />
            </div>
        )
    }
}

export default Register

class StepData {

    values = {};

    constructor(title, icon, component, fn){
        this.title = title;
        this.icon = icon;
        this.component = component
        this.fn = fn;
    }
    
}
