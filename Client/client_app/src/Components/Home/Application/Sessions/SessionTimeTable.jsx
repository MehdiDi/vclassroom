import React, { Component } from "react";
import {
    Calendar,
    momentLocalizer,
  } from 'react-big-calendar';
import moment from "moment";
import createSlot from 'react-tackle-box/Slot';
import NewSession from './NewSession';
import "react-big-calendar/lib/css/react-big-calendar.css";
import {Button, Card} from 'antd';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTimes } from '@fortawesome/free-solid-svg-icons'
import './SessionTimetable.css'

const localizer = momentLocalizer(moment)

class SessioNTimetable extends Component {
  constructor(props) {
    super(props);
    this.state = {
      newSessionVisible: false,
      newSessionInterval: [],
      loading: false
    };
    this.Testing = createSlot();
  }

  Event = ({ event }) => {
    return (
      <span className="session-item">
        <FontAwesomeIcon className="close-icon" title={event.id +" " + event.courseId} 
          icon={faTimes} onClick={() => this.props.removeSession(event)}/>
        <Card title={event.title}>
          {event.desc && ':  ' + event.desc}  
        </Card>
      </span>
    )
  }
  
  EventAgenda = ({ event }) => {
    return (
      <span>
        <em style={{ color: 'magenta' }}>wat {event.title}</em>
        <p>{event.desc}</p>
      </span>
    )
  }

  handleSelect = ({ start, end }) => {
    this.setNewSessionVisible(true, start, end);
  }
  setNewSessionVisible = (value, start="", end="") => {
    this.setState(prevState => ({
      newSessionVisible: value,
      newSessionInterval: [start, end]
    }));
  }
  addSession = session => {
    session.start = this.state.newSessionInterval[0];
    session.end = this.state.newSessionInterval[1];

    this.setState(prevstate => ({
      newSessionVisible: false
    }));
    this.props.addSession(session);
  }
  saveSchedule = async () => {
    this.setState({
      loading: true
    });
    const sessionsDict = this.getCourseSessionsDict();
  
    await this.props.saveSessions(sessionsDict);
    this.setState({
      loading: false
    });
  } 
  getCourseSessionsDict = () => {
    const dict = {};
    const sessions = this.props.sessions;
    const courses = this.props.courses;

    // Initialize the dictionary with all the course ids with empty array
    for(let i = 0; i < courses.length; i++) {
      dict[courses[i].id] = [];
    }
    
    for (let i = 0; i < sessions.length; i++) {
      const key = sessions[i].courseId;
      dict[key].push({
        start: sessions[i].start,
        end: sessions[i].end,
        title: sessions[i].title,
        sessionStatus: sessions[i].sessionStatus
      });
    }
    return dict;
  }
  
  render() {
    const sessions = this.props.sessions;
    const visible = this.state.newSessionVisible;
    const calVisible = this.props.visible;

    return (
      <div className={"calendar-container " + (calVisible ? "shown" : "hidden")}>
        <Button loading={this.state.loading} className="main-button" onClick={this.saveSchedule}>
          Save
        </Button>
        <Button onClick={() => this.props.close()}>
          Cancel
        </Button>
        <NewSession visible={visible} 
          onOk={this.addSession}
          onCancel={() => this.setNewSessionVisible(false)}
          courses={this.props.courses}
        />
        <Calendar
          format={"DD/MM/YYYY HH:mm"} 
          selectable
          localizer={localizer}
          defaultDate={new Date()}
          defaultView="week"
          events={sessions}
          style={{ height: "70vh" }}
          views={['week', 'day', 'agenda']}
          onSelectSlot={this.handleSelect}
          components={{
            event: this.Event,
            agenda: {
              event: this.EventAgenda,
            },
          }}
        />

      </div>
    );
  }
}

export default SessioNTimetable;