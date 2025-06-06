import React, { useState, useEffect } from 'react';
import { useAuth } from '../../context/AuthContext';
import Accordion from '../common/Accordion';
import '../../styles/dashboard.css';

const OfficeInfo = ({isOfficeInfoOpen}) => {
  const { user } = useAuth();
  const [isEditing, setIsEditing] = useState(false);
  const [formData, setFormData] = useState({
    manager: '',
    projects: '',
    proposals: '',
    role: ''
  });
  const [managers, setManagers] = useState([]);
  const [roles, setRoles] = useState([]);

  useEffect(() => {
    // Mock data - replace with API calls
    setFormData({
      manager: user?.manager?.firstName + ' ' + user?.manager?.lastName || 'N/A',
      projects: user?.projects || 'Project A, Project B',
      proposals: user?.proposals || 'Proposal 1',
      role: user?.designation || 'Employee'
    });
    
    setManagers([
      { id: 1, name: 'Krishnakanth Erukulla(KK)' },
      { id: 2, name: 'Santoshi Bondalapa' }
    ]);
    
    setRoles(['Developer', 'Designer', 'QA', 'Product Manager']);
  }, [user]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: value
    }));
  };

  const handleSave = () => {
    // Save logic here
    console.log('Saving office info:', formData);
    setIsEditing(false);
  };

  const handleCancel = () => {
    // Reset form
    setFormData({
      manager: user?.manager?.firstName + ' ' + user?.manager?.lastName || 'N/A',
      projects: user?.projects || 'Project A, Project B',
      // proposals: user?.proposals || 'Proposal 1',
      designation: user?.designation || 'Employee'
    });
    setIsEditing(false);
  };

  const handleSectionToggle = () => {
    // This will be handled by parent component
  };

  return (
    <Accordion 
      title="Office Information"
      isOpen={isOfficeInfoOpen}
      onClick={handleSectionToggle}
      >
      <div className="form-section">
        <div className="form-group inline-form-group"> 
          <label>Manager</label>
          {isEditing ? (
            <select
              name="manager"
              value={formData.manager}
              onChange={handleChange}
              disabled={!isEditing}
            >
              {managers.map(manager => (
                <option key={manager.id} value={manager.name}>{manager.name}</option>
              ))}
            </select>
          ) : (
            <input
              type="text"
              value={formData.manager}
              readOnly
            />
          )}
        </div>

        <div className="form-group inline-form-group">
          <label>Projects</label>
          <input
            type="text"
            name="projects"
            value={formData.projects}
            onChange={handleChange}
            readOnly={!isEditing}
          />
        </div>

        {/* <div className="form-group inline-form-group">
          <label>Proposals</label>
          {isEditing ? (
            <textarea
              name="proposals"
              value={formData.proposals}
              onChange={handleChange}
              rows="3"
            />
          ) : (
            <input
              type="text"
              value={formData.proposals}
              readOnly
            />
          )}
        </div> */}

        <div className="form-group inline-form-group">
          <label>Designation</label>
          {isEditing ? (
            <select
              name="designation"
              value={formData.role}
              onChange={handleChange}
            >
              {roles.map(role => (
                <option key={role} value={role}>{role}</option>
              ))}
            </select>
          ) : (
            <input
              type="text"
              value={formData.role}
              readOnly
            />
          )}
        </div>

        {isEditing ? (
          <div className="form-actions">
            <button type="button" className="btn-primary" onClick={handleSave}>
              Save
            </button>
            <button type="button" className="btn-secondary" onClick={handleCancel}>
              Cancel
            </button>
          </div>
        ) : (
          user?.designation === 'Manager' && (
          <div className="form-actions">
            <button 
              type="button" 
              className="btn-primary" 
              onClick={() => setIsEditing(true)}
            >
              Edit 
            </button>
          </div>
          )
        )}
      </div>
    </Accordion>
  );
};

export default OfficeInfo;