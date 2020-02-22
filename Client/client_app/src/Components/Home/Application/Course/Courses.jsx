import React, { Component } from 'react'
import './Courses.css'
import {getCourses, createCourse, updateCourse, deleteCourse} from '../../../../Api/Course'
import CourseItem from './CourseItem'
import {Row, Col, Button, message } from 'antd'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPlusCircle, faCalendarAlt } from '@fortawesome/free-solid-svg-icons'
import CreateCourseModal from './CreateCourseModal'
import SessionTimeTable from '../Sessions/SessionTimeTable'
import {updateSessions} from '../../../../Api/Session'


export class Courses extends Component {
    constructor(props) {
        super(props);
        this.state = {
            courses : [],
            loading: true,
            createModalVisible: false,
            courseActionLoading: false,
            editingId: null,
            sessionCalendarVisible: false,
            sessions: []
        }
        this.courseModalRef = React.createRef();
    }
    async componentDidMount() {
        const courses = await getCourses("title", null, 0, 10);
        const sessions = this.getSessions(courses);
        this.setState({courses, sessions, loading: false});
    }
    editCourse = id => {
        this.setState(() => ({
            editingId: id
        }), () => this.setCreateModalVisible(true));
    }
    adjustForTimezone = (date) => {
        var timeOffsetInMS = date.getTimezoneOffset() * 60000;
        date.setTime(date.getTime() - timeOffsetInMS);
        return date
    }
    createCourse = async data => {
        this.setState({courseActionLoading: true});
        const course = await createCourse(data);
        
        this.setState(prevState => (
            {courseActionLoading: false, courses: [...prevState.courses, course]}
        ));
    }
    updateCourse = async data => {
        this.setState({courseActionLoading: true});
        const id = this.state.editingId;

        const res = await updateCourse(data);
        const courses = this.state.courses.slice();

        Object.assign(courses.find(cr => cr.id === id), res);

        this.setState({
            courseActionLoading: false,
            editingId: null,
            courses
        });
    }
    deleteCourse = async id => {
        const courses = this.state.courses;
        const newCourses = courses.filter(c => c.id !== id);

        await deleteCourse(id);
        this.setState({courses: newCourses});
    }
    setCreateModalVisible = value => {
        const id = value ? this.state.editingId : null;
        
        this.setState(state => ({
            createModalVisible : value,
            editingId: id
        }), () => {
            
            let course = this.state.courses.find(c => c.id === id);
            if(!course)
                course = {
                    title: "",
                    description: ""
                };
            
            this.courseModalRef.current.setEditingCourse(course);
            
        });
    }
    handleCourseModalSubmit = async data => {
        if(this.state.editingId != null) {
            await this.updateCourse(data);
        }
        else {
            await this.createCourse(data);
        }
    }
    setCalendarVisible = value => {
        this.setState(prevState => {
            return {
                sessionCalendarVisible: value
            }
        });
    }
    getSessions = courses => {
        let sessions = [];
        

        for (let i = 0; i < courses.length; i++) {
            const sessionMap = courses[i].sessions.map(s => ({
                id: s.id,
                start: this.adjustForTimezone(new Date(s.start)),
                end: this.adjustForTimezone(new Date(s.end)),
                title: s.title,
                sessionStatus: s.sessionStatus,
                courseId: s.courseId
            }));
            sessions = sessions.concat(sessionMap);
        }
        return sessions;
    }
    saveSessions = async data => {
        await updateSessions(data);
        this.setCalendarVisible(false);
        message.success({content: 'Saved'});

    }
    addSession = session => {
        this.setState({
            sessions: [...this.state.sessions, session]
        })
    }
    removeSession = session => {
        const sessions =  this.state.sessions.filter(s => s !== session);
        this.setState({
            sessions
        })
    }
    closeSessionCalendar = () => {
        const sessions = this.getSessions(this.state.courses);
        this.setState({
            sessions,
            sessionCalendarVisible: false
        });
    }
    render() {
        const courseMap = this.state.courses.map(c =>
            <Col xs={12} md={6} key={c.id}>
                <CourseItem editCourse={this.editCourse} deleteCourse={this.deleteCourse} course={c}></CourseItem>      
            </Col>
        );
        return (
            <>
                <div className="create-btn-container">
                    <Button className="main-button" type="primary" onClick={() => this.setCreateModalVisible(true)}>
                        <FontAwesomeIcon size="1x" icon={faPlusCircle} /> &nbsp;
                        Create Course
                    </Button>
                    &nbsp;
                    <Button className="main-button" type="primary" onClick={() => this.setCalendarVisible(true)}>
                        <FontAwesomeIcon size="1x" icon={faCalendarAlt} /> &nbsp;
                        Manage Schedule
                    </Button>
                </div>
                <div>
                    <SessionTimeTable onCancel={() => this.setCalendarVisible(false)}
                        onOk={this.onSessionsSubmit}
                        close={this.closeSessionCalendar}
                        visible={this.state.sessionCalendarVisible}
                        courses={this.state.courses}
                        sessions={this.state.sessions}
                        saveSessions={this.saveSessions}
                        addSession={this.addSession}
                        removeSession={this.removeSession}
                    />
                </div>
                <Row>
                    {courseMap}
                </Row>
                <CreateCourseModal setVisible={this.setCreateModalVisible}
                    visible={this.state.createModalVisible}
                    onSubmit={this.handleCourseModalSubmit}
                    courseActionLoading={this.state.courseActionLoading}
                    ref={this.courseModalRef}
                />
            </>
        )
    }
}

export default Courses
