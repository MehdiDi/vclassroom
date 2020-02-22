import React from 'react'
import { Input, Form, Row, Button, Modal, Select } from 'antd'
import sessionStatus from './SessionOptions'

const { Option } = Select;

export class NewSession extends React.Component {

    state = {
        title: "",
        sessionStatus: null,
        courseId: null
    }
    handleSubmit = e => {
        e.preventDefault();
        const {title, sessionStatus, courseId} = this.state;
        this.props.onOk({title, sessionStatus: parseInt(sessionStatus), courseId});
    }
    handleChange = e => {
        this.setState({
            [e.target.name] : e.target.value
        });
    }
    render() {
        const {visible, onCancel} = this.props;
        const courseOptions = this.props.courses.map(c => <Option key={c.id} value={c.id} label={c.title}>
            {c.title}
        </Option>
        )
        const statusOptions = Object.keys(sessionStatus).map(k => <Option key={k} value={k}>
            {sessionStatus[k]}
        </Option>)

        return (
            <Modal className="custom-modal"
                visible={visible}
                title="New Course"
                onOk={this.handleOk}
                onCancel={onCancel}
                footer={[
                ]}
            >
                <Row>
                    <Form onSubmit={this.handleSubmit}>
                        <Select
                            name="courseId"
                            style={{ width: '100%' }}
                            placeholder="Select course to schedule"
                            onChange={value => {
                                this.setState({ courseId: value });
                              }}
                        >
                            {courseOptions}
                        </Select>
                        <Form.Item label="Title">
                            <Input type="text" name="title" onChange={this.handleChange}/>
                        </Form.Item>
                        <Select
                            name="sessionStatus"
                            style={{ width: '100%' }}
                            placeholder="Select status"
                            onChange={value => {
                                this.setState({ sessionStatus: value });
                                console.log("value", value);
                            }}
                        >
                            {statusOptions}
                        </Select>
                        <Button className="main-button" htmlType="submit">>
                            Save
                        </Button>
                    </Form>
                </Row>
            </Modal>
        )
    }
}

export default NewSession
