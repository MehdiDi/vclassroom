import React, { Component } from 'react'
import { Modal, Button, Input, Form } from 'antd'

const {TextArea} = Input;

export class CreateCourseModal extends Component {
    constructor(props) {
        super(props);
        this.state = {
            title: "",
            description: ""
        }
    }
    clear = () => {
        this.setState({
            title: "",
            description: ""
        });
    }
    setEditingCourse = course => {
        this.setState({
            ...course
        });
    }
    handleSubmit = e => {
        e.preventDefault();
        
        
        const {title, description, id} = this.state;
        const data = {
            title,
            description
        };
        if(id) {
            data.id = id;
        }
        try {
            this.props.onSubmit(data);
            this.clear();
            this.props.setVisible(false);
            
        } catch (error) {
            console.log(error);
        }
    }
    handleCancel = () => {
        this.clear();
        this.props.setVisible(false);
    }
    handleChange = e => {
        this.setState({
            [e.target.name]: e.target.value
        });
    }
    render() {
        const {visible, courseActionLoading} = this.props;
  
        return (
            <Modal className="custom-modal"
                visible={visible}
                title="New Course"
                onOk={this.handleSubmit}
                onCancel={this.handleCancel}
                footer={[
                ]}
                >
                <h1 className="form-title">
                    New Course
                </h1>

                <Form onSubmit={this.handleSubmit}>
                    <Form.Item>
                        <label className="form-label">Title</label>
                        <Input name="title" size="large" value={this.state.title} onChange={this.handleChange} />
                    </Form.Item>
                    <Form.Item >
                        <label className="form-label">Description</label>
                        <TextArea name="description" rows={2} value={this.state.description}
                            onChange={this.handleChange}
                        />
                    </Form.Item>
                </Form>
                <Button key="back" onClick={this.handleCancel}>
                  Return
                </Button> &nbsp;
                <Button className="main-button submit-course-btn"  
                    key="submit" type="primary" loading={courseActionLoading} onClick={this.handleSubmit}
                >
                  Submit
                </Button>
            </Modal>
        )
    }
}

export default CreateCourseModal
