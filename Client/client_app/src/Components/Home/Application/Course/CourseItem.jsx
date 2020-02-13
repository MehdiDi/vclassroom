import React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faEllipsisH, faCalendarAlt } from '@fortawesome/free-solid-svg-icons'
import {Popover} from 'antd'
import CourseOptionsContent from './CourseOptionsContent'
import SessionTimeTable from '../Sessions/SessionTimeTable'


export class CourseItem extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            timetableVisible: false
        }
    }

    setCalendarVisible = value => {
        this.setState(prevState => {
            return {
                timetableVisible: value
            }
        });
    }

    render() {
        const {course} = this.props;
        const content = <CourseOptionsContent
            onDelete={() => this.props.deleteCourse(course.id)}
            onEdit={() => this.props.editCourse(course.id)} 
        />;
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
                        <FontAwesomeIcon onClick={() => this.setCalendarVisible(true)} className="course-action"
                            icon={faCalendarAlt} />
                        <Popover content={content} title="Actions" trigger="click">
                            <FontAwesomeIcon className="course-action" icon={faEllipsisH} />
                        </Popover>
                    </span>
                </div>
                <SessionTimeTable onCancel={() => this.setCalendarVisible(false)}
                    onOk={this.onSessionsSubmit}
                    visible={this.state.timetableVisible}/>

            </div>
        )
    }
}
export default CourseItem;