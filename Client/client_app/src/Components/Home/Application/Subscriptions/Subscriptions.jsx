import React, { Component } from 'react'
import {getAllCourses} from '../../../../Api/Course'
import {getSubscriptions, addSubscription, removeSubscription} from '../../../../Api/Subscription.js'
import Course from './Course'
import {Col} from 'antd'

export class Subscriptions extends Component {
    constructor(props){
        super(props);
        this.state = {
            courses: [],
            subscriptions: [],
        }
    }

    async componentDidMount() {
        const courses = await getAllCourses("title", null, 0, 10);
        const subscriptions = await getSubscriptions();
        this.setState({
            courses,
            subscriptions
        });
    }
    isSubbedToCourse = courseId => {
        const res = this.state.subscriptions.find(s => s.id === courseId);

        if(!res)
           return false;

        return true;
    }
    handleSubClick = async (courseId, isSubbed) => {
        if(!isSubbed){
            await addSubscription(courseId);
            this.setState({
                subscriptions: [...this.state.subscriptions, {id: courseId}]
            })
        }
        else {
            await removeSubscription(courseId);
            this.setState({
                subscriptions: this.state.subscriptions.filter(s => s.id !== courseId)
            })
        }
    }

    render() {
        const courseMap = this.state.courses.map(c =>
            <Col xs={12} md={6} key={c.id}>
                <Course onSubClick={this.handleSubClick} editCourse={this.editCourse} deleteCourse={this.deleteCourse} 
                    isSubbed={this.isSubbedToCourse(c.id)} course={c}>
                </Course>      
            </Col>
        );
        return (
            <div>
                {courseMap}
            </div>
        )
    }
}

export default Subscriptions
