import React, { Component } from 'react'
import { ScheduleComponent, Day, Week, Inject, ViewsDirective, ViewDirective } from '@syncfusion/ej2-react-schedule';
import {Modal} from 'antd'


export class SessionTimeTable extends Component {
    constructor(props) {
        super(props);

        this.data = [{
            Id: 2,
            Subject: 'Meeting',
            StartTime: new Date(2020, 1, 13, 10, 0),
            EndTime: new Date(2020, 1, 13, 12, 30),
            IsAllDay: false,
            Status: 'Completed',
            Priority: 'High'
        }]; 
    }
    render() {

        console.log(this.data);
        return (
            <div>
                <Modal width='90%' style={{top: '10px'}} visible={this.props.visible} className="custom-modal"
                    onOk={this.props.onOk}
                    onCancel={this.props.onCancel}
                >
                    <ScheduleComponent height='550px' selectedDate={new Date()}  eventSettings={{ dataSource: this.data,
                        fields: {
                            id: 'Id',
                            subject: { name: 'Subject' },
                            isAllDay: { name: 'IsAllDay' },
                            startTime: { name: 'StartTime' },
                            endTime: { name: 'EndTime' }
                        }
                    }}>
                        <ViewsDirective>
                                <ViewDirective option='Day'/>
                                <ViewDirective option='Week'/>
                        </ViewsDirective>
                        <Inject services={[Day, Week]}/>
                    </ScheduleComponent>
                </Modal>
            </div>
        )
    }
}

export default SessionTimeTable
