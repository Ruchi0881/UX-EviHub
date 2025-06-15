import React, { useState, useEffect } from 'react';
import { useAuth } from '../../context/AuthContext';
import Header from '../common/Header';
import Sidebar from '../common/Sidebar';
import PersonalInfo from './PersonalInfo';
import OfficeInfo from './OfficeInfo';
import Skillset from './Skillset';
import Calendar from '../calendar/Calendar';
import Proposals from '../proposals/Proposals';
import '../../styles/dashboard.css';

const EmployeeDashboard = () => {
  const { user } = useAuth();
  const [highlights, setHighlights] = useState([]);
  const [sidebarCollapsed, setSidebarCollapsed] = useState(false);
  const [activeSection, setActiveSection] = useState('personal'); // Default open section
  const [selectedMenu, setSelectedMenu] = useState('dashboard');
  
  useEffect(() => {
    // Fetch highlights (birthdays, proposals, etc.)
    const mockHighlights = [
      { type: 'birthday', name: 'Ruchira', date: 'Today' },
      { type: 'proposal', name: 'EviHub', author: 'KK' }
    ];
    setHighlights(mockHighlights);
  }, []);

  const toggleSidebar = () => {
    setSidebarCollapsed(!sidebarCollapsed);
  };

  // Function to toggle accordion sections
  const toggleSection = (section) => {      
    setActiveSection(section);
  };

  return (
    <div className="dashboard-container">
      <Header 
        user={user} 
        appName="EviHub"
        highlights={highlights}
        toggleSidebar={toggleSidebar}
      />
      
      <div className="dashboard-content">
        <Sidebar 
          selectedMenu={selectedMenu}
          setSelectedMenu={setSelectedMenu}
          user={user} 
          collapsed={sidebarCollapsed}
        />
        
        <div className="main-content">
          {selectedMenu==='dashboard' &&(
            <div>
          <div className="page-title">
            <h2>Employee Dashboard</h2>
            <p>Welcome back, {user?.firstName}! Here's your profile information.</p>
          </div>
          
          <div className="accordion-container">
            <div onClick={() => toggleSection('personal')}>
              <PersonalInfo isPersonalInfoOpen={activeSection === 'personal'} />
            </div>
            <div onClick={() => toggleSection('office')}>
              <OfficeInfo isOfficeInfoOpen={activeSection === 'office'} />
            </div>
            <div onClick={() => toggleSection('skillset')}>
              <Skillset isSkillsetOpen={activeSection === 'skillset'} />
            </div>
            </div>
          </div>
          )}

          {selectedMenu==='calendar' && <Calendar />}
          {selectedMenu==='proposals' && <Proposals />}
        </div>
      </div>
    </div>
  );
};

export default EmployeeDashboard;