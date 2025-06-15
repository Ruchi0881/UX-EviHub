import React, { useState } from 'react';
import { useAuth } from '../../context/AuthContext';
import { Link } from 'react-router-dom';
import '../../styles/dashboard.css';

const Header = ({ appName, highlights, toggleSidebar }) => {
  const { user, logout } = useAuth();
  const [showDropdown, setShowDropdown] = useState(false);
  const [showNotifications, setShowNotifications] = useState(false);

  return (
    <header className="dashboard-header">
      <div className="header-left">
        <button className="menu-toggle" onClick={toggleSidebar}>
          <i className="fas fa-bars"></i>
        </button>
        <div className="brand">
          <h1>{appName}</h1>
        </div>
        <div className="search-bar">
          <i className="fas fa-search search-icon"></i>
          <input type="text" placeholder="Search..." />
        </div>
      </div>
      
      <div className="header-right">
        <div className="notification-area">
          <button 
            className="notification-button"
            onClick={() => setShowNotifications(!showNotifications)}
          >
            <i className="fas fa-bell"></i>
            <span className="notification-badge">{highlights.length}</span>
          </button>
          
          {showNotifications && (
            <div className="notification-dropdown">
              <div className="notification-header">
                <h3>Notifications</h3>
                <button className="mark-all-read">Mark all as read</button>
              </div>
              {highlights.map((highlight, index) => (
                <div key={index} className="notification-item">
                  {highlight.type === 'birthday' && (
                    <>
                      <div className="notification-icon birthday">
                        <i className="fas fa-birthday-cake"></i>
                      </div>
                      <div className="notification-content">
                        <p className="notification-title">{highlight.name}'s Birthday</p>
                        <p className="notification-time">{highlight.date}</p>
                      </div>
                    </>
                  )}
                  {highlight.type === 'proposal' && (
                    <>
                      <div className="notification-icon proposal">
                        <i className="fas fa-file-alt"></i>
                      </div>
                      <div className="notification-content">
                        <p className="notification-title">New Proposal: {highlight.name}</p>
                        <p className="notification-time">By {highlight.author}</p>
                      </div>
                    </>
                  )}
                </div>
              ))}
            </div>
          )}
        </div>
        
        <div 
          className="user-profile"
          onClick={() => setShowDropdown(!showDropdown)}
        >
          <div className="avatar">
            {user?.firstName?.charAt(0)}{user?.lastName?.charAt(0)}
          </div>
          
          {showDropdown && (
            <div className="dropdown-menu">
              <div className="dropdown-header">
                <h4>{user?.firstName} {user?.lastName}</h4>
                <p className="dropdown-user-id">ID: {user?.employeeId || 'EMP001'}</p>
                <p className="dropdown-user-role">{user?.designation || 'Developer'}</p>
              </div>
              <div className="dropdown-divider"></div>
              <Link to="/profile" className="dropdown-item">
                <i className="fas fa-user"></i> View Profile
              </Link>
              <Link to="/settings" className="dropdown-item">
                <i className="fas fa-cog"></i> Account Settings
              </Link>
              <div className="dropdown-divider"></div>
              <button onClick={logout} className="dropdown-item">
                <i className="fas fa-sign-out-alt"></i> Logout
              </button>
            </div>
          )}
        </div>
      </div>
    </header>
  );
};

export default Header;