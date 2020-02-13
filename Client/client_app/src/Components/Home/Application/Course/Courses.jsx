import React, { Component } from 'react'
import './Courses.css'
import {getCourses, createCourse, updateCourse, deleteCourse} from '../../../../Api/Course'
import CourseItem from './CourseItem'
import {Row, Col, Button} from 'antd'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPlusCircle } from '@fortawesome/free-solid-svg-icons'
import CreateCourseModal from './CreateCourseModal'

export class Courses extends Component {
    constructor(props) {
        super(props);
        this.state = {
            courses : [],
            loading: true,
            createModalVisible: false,
            courseActionLoading: false,
            editingId: null,

        }
        this.courseModalRef = React.createRef();
    }
    async componentDidMount() {
        const courses = await getCourses("title", null, 0, 10);
        this.setState({courses, loading: false});
    }
    editCourse = id => {
        this.setState(() => ({
            editingId: id
        }), () => this.setCreateModalVisible(true));
        
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
        console.log(id, newCourses);
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
    openCalendar = async id => {

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
