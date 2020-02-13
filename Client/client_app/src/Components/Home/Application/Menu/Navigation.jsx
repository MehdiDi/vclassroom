import React from 'react';
import { Menu, Icon } from 'antd';
import './Navigation.css';


  export const Navigation = props => {
    const handleClick = e => {
      
      props.changeRoute(e.key);
    };

    const {current} = props;

    return (
      <div>
      <Menu 
        defaultSelectedKeys={[current]}
        defaultOpenKeys={[current]}
        mode="inline"
        theme="light"
        inlineCollapsed={true}
        onClick={handleClick}
      >
        <Menu.Item key="0">
          <Icon type="home" />
          <span>Home</span>
        </Menu.Item>
        <Menu.Item key="courses">
          <Icon type="unordered-list" />
          <span>Courses</span>
        </Menu.Item>
        <Menu.Item key="messages">
          <Icon type="inbox" />
          <span>messages</span>
        </Menu.Item>

      </Menu>
    </div>
    );
  }
  export default Navigation;