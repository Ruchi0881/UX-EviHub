import React from 'react';
import { Link } from 'react-router-dom';
import '../../styles/auth.css';

const Unauthorized = () => {
  return (
    <div className="auth-container">
      <div className="auth-card">
        <h2>Unauthorized Access</h2>
        <p>You don't have permission to access this page.</p>
        <div className="auth-footer">
          <Link to="/login" className="auth-button">
            Return to Login
          </Link>
        </div>
      </div>
    </div>
  );
};

export default Unauthorized;