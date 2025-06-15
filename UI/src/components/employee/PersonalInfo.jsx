import React, { useState, useEffect } from 'react';
import { useAuth } from '../../context/AuthContext';
import Accordion from '../common/Accordion';
import '../../styles/dashboard.css';

const PersonalInfo = ({ isPersonalInfoOpen }) => {
  const { user } = useAuth();
  const [isEditing, setIsEditing] = useState(false);
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    dob: '',
    gender: '',
    email: '',
    phone: '',
    hobbies: ''
  });
  const [errors, setErrors] = useState({});

  useEffect(() => {
    
    setFormData({
      firstName: user?.firstName || '',
      lastName: user?.lastName || '',
      dob: user?.dob || '',
      gender: user?.gender || '',
      email: user?.email || '',
      phone: user?.phone || '',
      hobbies: user?.hobbies || ''
    });
  }, [user]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: value
    }));
  };

  const validate = () => {
    const newErrors = {};
    if (!formData.firstName) newErrors.firstName = 'First name required';
    if (!formData.lastName) newErrors.lastName = 'Last name required';
    if (!formData.email) newErrors.email = 'Email required';
    if (!formData.phone) newErrors.phone = 'Phone number required';
    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleSave = () => {
    if (!validate()) return;
    
    // calling an API to save the data
    console.log('Saving personal info:', formData);
    setIsEditing(false);
  };

  const handleCancel = () => {
    // Reset form to original values
    setFormData({
      firstName: user?.firstName || '',
      lastName: user?.lastName || '',
      dob: user?.dob || '',
      gender: user?.gender || '',
      email: user?.email || '',
      phone: user?.phone || '',
      hobbies: user?.hobbies || ''
    });
    setIsEditing(false);
    setErrors({});
  };

  // Handler to pass to parent for toggling section
  const handleSectionToggle = () => {
  };
  
  return (
    <Accordion 
      title="Personal Information" 
      isOpen={isPersonalInfoOpen}
      onClick={handleSectionToggle}
    >
      <div className="form-section">
        <div className="form-row">
          <div className="form-group inline-form-group">
            <label>First Name</label>
            <input
              type="text"
              name="firstName"
              value={formData.firstName}
              onChange={handleChange}
              disabled={!isEditing}
              className={errors.firstName ? 'error' : ''}
            />
            {errors.firstName && <span className="error-text">{errors.firstName}</span>}
          </div>
          
          <div className="form-group inline-form-group">
            <label>Last Name</label>
            <input
              type="text"
              name="lastName"
              value={formData.lastName}
              onChange={handleChange}
              disabled={!isEditing}
              className={errors.lastName ? 'error' : ''}
            />
            {errors.lastName && <span className="error-text">{errors.lastName}</span>}
          </div>
        </div>

        <div className="form-row">
          <div className="form-group inline-form-group">
            <label>Date of Birth</label>
            <input
              type="date"
              name="dob"
              value={formData.dob}
              onChange={handleChange}
              disabled={!isEditing}
            />
          </div>
          
          <div className="form-group inline-form-group">
            <label>Gender</label>
            <select
              name="gender"
              value={formData.gender}
              onChange={handleChange}
              disabled={!isEditing}
            >
              <option value="">Select Gender</option>
              <option value="male">Male</option>
              <option value="female">Female</option>
              <option value="other">Other</option>
            </select>
          </div>
        </div>

        <div className="form-row">
          <div className="form-group inline-form-group">
            <label>Email</label>
            <input
              type="email"
              name="email"
              value={formData.email}
              onChange={handleChange}
              disabled={!isEditing}
              className={errors.email ? 'error' : ''}
            />
            {errors.email && <span className="error-text">{errors.email}</span>}
          </div>
          
          <div className="form-group inline-form-group">
            <label>Phone Number</label>
            <input
              type="tel"
              name="phone"
              value={formData.phone}
              onChange={handleChange}
              disabled={!isEditing}
              className={errors.phone ? 'error' : ''}
            />
            {errors.phone && <span className="error-text">{errors.phone}</span>}
          </div>
        </div>

        <div className="form-group inline-form-group">
          <label>Hobbies</label>
          <textarea
            name="hobbies"
            value={formData.hobbies}
            onChange={handleChange}
            disabled={!isEditing}
            rows="3"
          />
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
          <div className="form-actions">
            <button 
              type="button" 
              className="btn-primary" 
              onClick={() => setIsEditing(true)}
            >
              Edit
            </button>
          </div>
        )}
      </div>
    </Accordion>
  );
};

export default PersonalInfo;