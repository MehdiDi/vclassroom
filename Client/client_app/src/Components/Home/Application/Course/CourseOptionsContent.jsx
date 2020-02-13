import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTimesCircle, faPen } from '@fortawesome/free-solid-svg-icons'

const CourseOptionsContent = props => {
    return (
        <div className="course-options-container">
            <div className="course-action-item normal" onClick={() => props.onEdit()}>
                <FontAwesomeIcon icon={faPen} /> &nbsp;
                Edit
            </div>
            <div className="course-action-item delete" onClick={() => props.onDelete()}>
                <FontAwesomeIcon icon={faTimesCircle} /> &nbsp;
                Delete
            </div>
        </div>
    );
}

export default CourseOptionsContent;
