import React, { Component } from 'react'
import { Form, Icon, Input, Button } from 'antd'
import { hasErrors } from '../../../Helpers/Form'

const {TextArea} = Input;

export class Step2 extends Component {
    handleSubmit =  e => {
        e.preventDefault();
        this.props.form.validateFields(async (err, values) => {
          if (!err) {
              this.props.fn(values);
          }
        });
      };
    render() {
        const { getFieldDecorator, getFieldsError } = this.props.form;

        return (
            <div>
                <Form layout="vertical" onSubmit={this.handleSubmit}>
                    <Form.Item label="Specialization">
                        {getFieldDecorator('specialization')(
                            <Input
                            prefix={<Icon type="user" style={{ color: 'rgba(0,0,0,.25)' }} />}
                            placeholder="Specialization"
                            />,
                        )}
                    </Form.Item>
                    <Form.Item label="Bio">
                        {getFieldDecorator('Bio')(
                            <TextArea
                            rows={4}
                            />,
                        )}
                    </Form.Item>
                    <Button type="primary" htmlType="submit" disabled={hasErrors(getFieldsError())}>
                        {this.props.submitText}
                    </Button>
                </Form>
            </div>
        )
    }
}

export default Step2
