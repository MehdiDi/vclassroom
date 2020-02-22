import React, { Component } from 'react'
import {Button} from 'antd'

export class Course extends Component {

    handleClick = () => {
        const {onSubClick, course, isSubbed} = this.props;

        onSubClick(course.id, isSubbed);
    }

    render() {
        const course = this.props.course;
        const isSubbed = this.props.isSubbed;

        return (
            <div className="course">
                <h2 className="bold">
                    {course.title}
                </h2>
                <p className="course-description">
                    {course.description}
                </p>
                <div className="course-footer">
                    <span className="course-actions">
                       <Button onClick={this.handleClick}>{isSubbed ? "Cancel Subscription" : "Subscribe" }</Button>
                    </span>
                </div>
            </div>
        )
    }
}

export default Course
