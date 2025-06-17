import React, { useState,useEffect } from 'react';
import { useAuth } from '../../context/AuthContext';
import { Link, useNavigate } from 'react-router-dom';
import '../../styles/auth.css';

const SignUp = () => {
  const { signup } = useAuth();
  const navigate = useNavigate();
  const [isManager, setIsManager] = useState(false);
  const [managers, setManagers] = useState([]);
  const [designations, setDesignations] = useState([]);
  const [formData, setFormData] = useState({
    employeeid:'',
    firstName: '',
    lastName: '',
    email: '',
    phone: '',
    dob: '',
    isManager: false,
    managerId: '',
    designation: '',
    username: '',
    password: '',
    confirmPassword: ''
  });
  const [errors, setErrors] = useState({});

  // In a real app, these would come from an API
  useEffect(() => {
    // Mock data - replace with API call
    setManagers([
      { id: '1', name: 'Krishnakanth Erukulla(KK)' },
      { id: '2', name: 'Santoshi Bondalapati' }
    ]);
    setDesignations(['Developer', 'Designer', 'QA', 'Product Manager']);
  }, []);

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value
    }));
  };

  const validate = () => {
    const newErrors = {};
    if (!formData.employeeid) newErrors.firstName = 'Employee Id is required';
    if (!formData.firstName) newErrors.firstName = 'First name is required';
    if (!formData.lastName) newErrors.lastName = 'Last name is required';
    if (!formData.email) newErrors.email = 'Email is required';
    if (!formData.phone) newErrors.phone = 'Phone number is required';
    if (!formData.dob) newErrors.dob = 'Date of birth is required';
    if (!formData.isManager && !formData.managerId) newErrors.managerId = 'Manager is required';
    if (!formData.designation) newErrors.designation = 'Designation is required';
    if (!formData.username) newErrors.username = 'Username is required';
    if (!formData.password) newErrors.password = 'Password is required';
    if (formData.password !== formData.confirmPassword) newErrors.confirmPassword = 'Passwords do not match';
    
    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!validate()) return;

    const result = await signup({
      ...formData,
      role: formData.isManager ? 'manager' : 'employee'
    });

    if (result.success) {
      navigate('/login');
    } else {
      setErrors({ ...errors, form: result.message });
    }
  };

  return (
    <div className="auth-container">
      <div className="auth-card">
        <h2>Create Your Account</h2>
        {errors.form && <div className="error-message">{errors.form}</div>}
        
        <form onSubmit={handleSubmit}>
        <div className="form-group">
            <label>Employee Id</label>
            <input
              type="text"
              name="employeeid"
              value={formData.employeeid}
              onChange={handleChange}
              className={errors.employeeid ? 'error' : ''}
            />
            {errors.employeeid && <span className="error-text">{errors.employeeid}</span>}
          </div>

          <div className="form-group">
            <label>First Name</label>
            <input
              type="text"
              name="firstName"
              value={formData.firstName}
              onChange={handleChange}
              className={errors.firstName ? 'error' : ''}
            />
            {errors.firstName && <span className="error-text">{errors.firstName}</span>}
          </div>

          <div className="form-group">
            <label>Last Name</label>
            <input
              type="text"
              name="lastName"
              value={formData.lastName}
              onChange={handleChange}
              className={errors.lastName ? 'error' : ''}
            />
            {errors.lastName && <span className="error-text">{errors.lastName}</span>}
          </div>

          <div className="form-group">
            <label>Email</label>
            <input
              type="email"
              name="email"
              value={formData.email}
              onChange={handleChange}
              className={errors.email ? 'error' : ''}
            />
            {errors.email && <span className="error-text">{errors.email}</span>}
          </div>

          <div className="form-group">
            <label>Phone Number</label>
            <input
              type="tel"
              name="phone"
              value={formData.phone}
              onChange={handleChange}
              className={errors.phone ? 'error' : ''}
            />
            {errors.phone && <span className="error-text">{errors.phone}</span>}
          </div>

          <div className="form-group">
            <label>Date of Birth</label>
            <input
              type="date"
              name="dob"
              value={formData.dob}
              onChange={handleChange}
              className={errors.dob ? 'error' : ''}
            />
            {errors.dob && <span className="error-text">{errors.dob}</span>}
          </div>

          <div className=" checkbox-group">
            <input
              type="checkbox"
              id="isManager"
              name="isManager"
              checked={formData.isManager}
              onChange={handleChange}
            />
            <label htmlFor="isManager">Are you a manager?</label>
          </div>

          {!formData.isManager && (
            <div className="form-group">
              <label>Manager</label>
              <select
                name="managerId"
                value={formData.managerId}
                onChange={handleChange}
                className={errors.managerId ? 'error' : ''}
              >
                <option value="">Select Manager</option>
                {managers.map(manager => (
                  <option key={manager.id} value={manager.id}>{manager.name}</option>
                ))}
              </select>
              {errors.managerId && <span className="error-text">{errors.managerId}</span>}
            </div>
          )}

          <div className="form-group">
            <label>Designation</label>
            <select
              name="designation"
              value={formData.designation}
              onChange={handleChange}
              className={errors.designation ? 'error' : ''}
            >
              <option value="">Select Designation</option>
              {designations.map(designation => (
                <option key={designation} value={designation}>{designation}</option>
              ))}
            </select>
            {errors.designation && <span className="error-text">{errors.designation}</span>}
          </div>

          <div className="form-group">
            <label>Username</label>
            <input
              type="text"
              name="username"
              value={formData.username}
              onChange={handleChange}
              className={errors.username ? 'error' : ''}
            />
            {errors.username && <span className="error-text">{errors.username}</span>}
          </div>

          <div className="form-group">
            <label>Password</label>
            <input
              type="password"
              name="password"
              value={formData.password}
              onChange={handleChange}
              className={errors.password ? 'error' : ''}
            />
            {errors.password && <span className="error-text">{errors.password}</span>}
          </div>

          <div className="form-group">
            <label>Confirm Password</label>
            <input
              type="password"
              name="confirmPassword"
              value={formData.confirmPassword}
              onChange={handleChange}
              className={errors.confirmPassword ? 'error' : ''}
            />
            {errors.confirmPassword && <span className="error-text">{errors.confirmPassword}</span>}
          </div>

          <button type="submit" className="auth-button">Sign Up</button>
        </form>

        <div className="auth-footer">
          Already have an account? <Link to="/login">Login</Link>
        </div>
      </div>
    </div>
  );
};

export default SignUp;