import React, { Component } from 'react';
import { Form, Icon, Input, Button } from 'antd';
import { hasErrors } from '../../Helpers/Form';
import {login} from '../../Api/Auth'


class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      
    };
  }
  componentDidMount() {
    // To disable submit button at the beginning.
    this.props.form.validateFields();
  }

  handleSubmit = e => {
    e.preventDefault();
    this.props.form.validateFields({}, async(err, values) => {
      if (!err) {
        try{
          const token = await login(values);
          this.props.onLoggedIn(token);
          this.props.redirect();
        }
        catch(ex) {
          console.error(ex);
        }
      }
    });
  };

  render() {
    const { getFieldDecorator, getFieldsError, getFieldError, isFieldTouched } = this.props.form;

    // Only show error after a field is touched.
    const usernameError = isFieldTouched('username') && getFieldError('username');
    const passwordError = isFieldTouched('password') && getFieldError('password');
    return (
        <div>
            <Form layout="vertical" onSubmit={this.handleSubmit}>
                <Form.Item validateStatus={usernameError ? 'error' : ''} help={usernameError || ''}>
                {getFieldDecorator('username', {
                    rules: [{ required: true, message: 'Please input your username!' }],
                })(
                    <Input
                    prefix={<Icon type="user" style={{ color: 'rgba(0,0,0,.25)' }} />}
                    placeholder="Username"
                    />,
                )}
                </Form.Item>
                <Form.Item validateStatus={passwordError ? 'error' : ''} help={passwordError || ''}>
                {getFieldDecorator('password', {
                    rules: [
                        { required: true, message: 'Please input your Password!' },
                        { min: 6 }
                    ],
                })(
                    <Input
                    prefix={<Icon type="lock" style={{ color: 'rgba(0,0,0,.25)' }} />}
                    type="password"
                    placeholder="Password"
                    />,
                )}
                </Form.Item>
                <Form.Item>
                <Button type="primary" htmlType="submit" disabled={hasErrors(getFieldsError())}>
                    Log in
                </Button>
                </Form.Item>
            </Form>
        </div>
    );
  }
}

export default Form.create({ name: 'login_form' })(Login);