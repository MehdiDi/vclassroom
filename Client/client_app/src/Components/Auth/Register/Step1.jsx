import React, { Component } from 'react'
import { Form, Icon, Input, Button, Row, Col } from 'antd';
import { hasErrors } from '../../../Helpers/Form'


export class Step1 extends Component {

    handleSubmit =  e => {
        e.preventDefault();
        this.props.form.validateFields(async (err, values) => {
          if (!err) {
              this.props.fn(values);
          }
        });
      };
      
    render() {
        const { getFieldDecorator, getFieldsError, getFieldError, isFieldTouched } = this.props.form;

        // Only show error after a field is touched.
        const usernameError = isFieldTouched('username') && getFieldError('username');
        const passwordError = isFieldTouched('password') && getFieldError('password');
        const firstnameError = isFieldTouched('firstname') && getFieldError('firstname');
        const lastnameError = isFieldTouched('lastname') && getFieldError('lastname');
        const emailError = isFieldTouched('email') && getFieldError('email');

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
                    <Row>
                        <Col span={11}>
                            <Form.Item validateStatus={firstnameError ? 'error' : ''} help={usernameError || ''}>
                                {getFieldDecorator('firstname', {
                                    rules: [{ required: true, message: '' }],
                                })(
                                    <Input
                                    prefix={<Icon type="user" style={{ color: 'rgba(0,0,0,.25)' }} />}
                                    placeholder="Firstname"
                                    />,
                                )}
                            </Form.Item>
                        </Col>
                        <Col offset={2} span={11}>
                            <Form.Item validateStatus={lastnameError ? 'error' : ''} help={lastnameError || ''}>
                                {getFieldDecorator('lastname', {
                                    rules: [{ required: true, message: '' }],
                                })(
                                    <Input
                                    prefix={<Icon type="user" style={{ color: 'rgba(0,0,0,.25)' }} />}
                                    placeholder="Lastname"
                                    />,
                                )}
                            </Form.Item>
                        </Col>
                    </Row>
                    <Form.Item validateStatus={emailError ? 'error' : ''} help={emailError || ''}>
                        {getFieldDecorator('email', {
                            rules: [{ required: true, message: '' }],
                        })(
                            <Input
                            prefix={<Icon type="user" style={{ color: 'rgba(0,0,0,.25)' }} />}
                            placeholder="Email"
                            />,
                        )}
                    </Form.Item>
                    <Form.Item validateStatus={lastnameError ? 'error' : ''} help={lastnameError || ''}>
                        {getFieldDecorator('address', {
                            rules: [{ required: true, message: '' }],
                        })(
                            <Input
                            prefix={<Icon type="user" style={{ color: 'rgba(0,0,0,.25)' }} />}
                            placeholder="Address"
                            />,
                        )}
                    </Form.Item>
                    <Form.Item validateStatus={passwordError ? 'error' : ''} help={passwordError || ''}>
                        {getFieldDecorator('password', {
                            rules: [{ required: true, message: '' }],
                        })(
                            <Input type="password"
                            prefix={<Icon type="password" style={{ color: 'rgba(0,0,0,.25)' }} />}
                            placeholder="Password"
                            />,
                        )}
                    </Form.Item>
                    
                    <Form.Item>
                        <Button type="primary" htmlType="submit" disabled={hasErrors(getFieldsError())}>
                            {this.props.submitText}
                        </Button>
                    </Form.Item>
                </Form>
            </div>
        )
    }
}

export default Step1;
