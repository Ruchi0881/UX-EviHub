import React from 'react';
import { Link } from 'react-router-dom';
import '../../styles/dashboard.css';

const Sidebar = ({ selectedMenu, setSelectedMenu, user, collapsed }) => {
  return (
    <aside className={`dashboard-sidebar ${collapsed ? 'collapsed' : ''}`}>
      <div className="sidebar-content">
        <div className="sidebar-profile">
          <div className="sidebar-avatar">
            {user?.firstName?.charAt(0)}{user?.lastName?.charAt(0)}
          </div>
          <div className="sidebar-user-info">
            <h3>{user?.firstName} {user?.lastName}</h3>
            <p className="sidebar-user-id">ID: {user?.employeeId || 'EMP001'}</p>
            <p className="sidebar-user-designation">{user?.designation || 'Developer'}</p>
          </div>
        </div>

        <nav className="sidebar-nav">
          <div className="nav-section">
            <h4>Main Menu</h4>
            <ul>
              <li
                className={`nav-item ${selectedMenu === 'dashboard' ? 'active' : ''}`}
                onClick={() => setSelectedMenu('dashboard')}
              >
                {/* <Link to="/dashboard" className="nav-item active">
                  <i className="fas fa-tachometer-alt"></i>
                  <span>Dashboard</span>
                  </Link>
                   */}
                <i className="fas fa-tachometer-alt"></i>
                <span>Dashboard</span>
              </li>
            </ul>
          </div>

          <div className="nav-section">
            <h4>Workspace</h4>
            <ul>
              <li>
                <a
                href='#'
                className = {`nav-item ${selectedMenu === 'calendar' ? 'active' : ''}`}
                onClick = {(e) => {
                  e.preventDefault();
                  setSelectedMenu('calendar')}}
                >
                <i className="fas fa-calendar-alt"></i>
                <span>Calendar</span>
                </a>
                {/* <Link to="/calendar" className="nav-item">
                  <i className="fas fa-calendar-alt"></i>
                  <span>Calendar</span>
                </Link> */}
              </li>
              <li>
              <a
                href='#'
                className = {`nav-item ${selectedMenu === 'proposals' ? 'active' : ''}`}
                onClick = {(e) => {
                  e.preventDefault();
                  setSelectedMenu('proposals')}}
                >
                <i className="fas fa-comment"></i>
                <span>Proposals</span>
                </a>
                {/* <Link to="/proposals" className="nav-item">
                  <i className="fas fa-comment"></i>
                  <span>Proposals</span>
                </Link> */}
              </li>
            </ul>
          </div>
        </nav>

        <div className="sidebar-footer">
          {/* <Link to="/settings" className="sidebar-footer-btn">
            <i className="fas fa-cog"></i>
            <span>Settings</span>
          </Link> */}
          <button className="sidebar-footer-btn logout-btn">
            <i className="fas fa-sign-out-alt"></i>
            <span>Logout</span>
          </button>
        </div>
      </div>
    </aside>
  );
};

export default Sidebar;