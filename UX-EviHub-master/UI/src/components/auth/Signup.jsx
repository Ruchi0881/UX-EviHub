

import React, { useState, useEffect } from 'react';
import { useAuth } from '../../context/AuthContext';
import { Link, useNavigate } from 'react-router-dom';
import '../../styles/auth.css';

const SignUp = () => {
const { signup } = useAuth();
const navigate = useNavigate();

const [formData, setFormData] = useState({
empId: '',
firstName: '',
lastName: '',
email: '',
mobile: '',
dob: '',
designationId: '',
managerId: '',
password: '',
confirmPassword: ''
});

const [errors, setErrors] = useState({});
const [designations, setDesignations] = useState([]);
const [managers, setManagers] = useState([]);

useEffect(() => {
// Fetch these from your backend if available
// setManagers([
// { id: 1, name: 'Manager A' },
// { id: 2, name: 'Manager B' }
// ]);
setDesignations([
{ id: 1, name: 'Developer' },
{ id: 2, name: 'QA' },
{ id: 3, name: 'Designer' }
]);
 const fetchManagers = async () => {
try {
const response = await fetch('https://localhost:7218/api/Admin/managers'); // Your backend URL
if (!response.ok) throw new Error('Failed to fetch managers');
const data = await response.json();
// Map data to match {id, name} structure expected by dropdown
const formattedManagers = data.map(m => ({
id: m.managerId,
name: `${m.firstName} ${m.lastName}`
}));
setManagers(formattedManagers);
} catch (error) {
console.error('Error fetching managers:', error);
setManagers([]); // fallback to empty list on error
}
};

const fetchDesignations = async () => {
try {
const response = await fetch('https://localhost:7218/api/Admin/designations'); // Replace with your API URL
if (!response.ok) throw new Error('Failed to fetch designations');
const data = await response.json();
const formattedDesignations = data.map(d => ({
id: d.designationId, // backend property for designation ID
name: d.designationName // display name from backend
}));
setDesignations(formattedDesignations);
} catch (error) {
console.error('Error fetching designations:', error);
setDesignations([]); // fallback
}
};

fetchManagers();
fetchDesignations();

}, []);

const handleChange = (e) => {
const { name, value } = e.target;
setFormData(prev => ({ ...prev, [name]: value }));
};

const validate = () => {
const newErrors = {};
Object.entries(formData).forEach(([key, value]) => {
if (!value && key !== 'managerId') newErrors[key] = `${key} is required`;
});
if (formData.password !== formData.confirmPassword)
newErrors.confirmPassword = 'Passwords do not match';
setErrors(newErrors);
return Object.keys(newErrors).length === 0;
};

const handleSubmit = async (e) => {
e.preventDefault();
if (!validate()) return;
const data = { ...formData };
delete data.confirmPassword;
data.empId = parseInt(data.empId);
data.designationId = parseInt(data.designationId);
data.managerId = parseInt(data.managerId);

const result = await signup(data);
if (result.success) navigate('/login');
else setErrors({ form: result.message });
};

return (
<div className="auth-container">
<div className="auth-card">
<h2>Create Account</h2>
{errors.form && <div className="error-message">{errors.form}</div>}
<form onSubmit={handleSubmit}>
{['empId', 'firstName', 'lastName', 'email', 'mobile', 'dob'].map(field => (
<div className="form-group" key={field}>
<label>{field.charAt(0).toUpperCase() + field.slice(1)}</label>
<input type={field === 'dob' ? 'date' : 'text'} name={field} value={formData[field]} onChange={handleChange} className={errors[field] ? 'error' : ''} />
{errors[field] && <span className="error-text">{errors[field]}</span>}
</div>
))}

<div className="form-group">
<label>Designation</label>
<select name="designationId" value={formData.designationId} onChange={handleChange}>
<option value="">Select Designation</option>
{designations.map(d => (
<option key={d.id} value={d.id}>{d.name}</option>
))}
</select>
{errors.designationId && <span className="error-text">{errors.designationId}</span>}
</div>

<div className="form-group">
<label>Manager</label>
<select name="managerId" value={formData.managerId} onChange={handleChange}>
<option value="">Select Manager</option>
{managers.map(m => (
<option key={m.id} value={m.id}>{m.name}</option>
))}
</select>
</div>

{['password', 'confirmPassword'].map(field => (
<div className="form-group" key={field}>
<label>{field === 'password' ? 'Password' : 'Confirm Password'}</label>
<input type="password" name={field} value={formData[field]} onChange={handleChange} className={errors[field] ? 'error' : ''} />
{errors[field] && <span className="error-text">{errors[field]}</span>}
</div>
))}

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
