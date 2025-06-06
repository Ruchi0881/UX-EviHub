import React from 'react';

const Accordion = ({ title, children, isOpen, onClick }) => {
  return (
    <div className={`accordion ${isOpen ? 'open' : ''}`}>
      <div className="accordion-header" onClick={onClick}>
        <h3>{title}</h3>
        <span className={`accordion-icon ${isOpen ? 'open' : ''}`}>
          {isOpen ? '−' : '+'}
        </span>
      </div>
      
      {isOpen && (
        <div className="accordion-content">
          {children}
        </div>
      )}
    </div>
  );
};

export default Accordion;
