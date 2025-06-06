import React, { useState, useEffect } from 'react';
import Accordion from '../common/Accordion';

const ProposalForm = ({ onSubmit, editingProposal = null, onCancel}) => {
  const [formData, setFormData] = useState({
    name: '',
    description: '',
    theme: ''
  });
  const [isEditing, setIsEditing] = useState(false);

  useEffect(() => {
    const handleEditProposal = (event) => {
      const proposal = event.detail;
      setFormData({
        name: proposal.name,
        description: proposal.description,
        theme: proposal.theme
      });
      setIsEditing(true);
    };

    document.addEventListener('editProposal', handleEditProposal);
    return () => {
      document.removeEventListener('editProposal', handleEditProposal);
    };
  }, []);

  useEffect(()=>{
    if(editingProposal){
      setFormData({
        name:editingProposal.name,
        description:editingProposal.description,
        theme:editingProposal.theme
      });
      setIsEditing(true);
    }else{
      setIsEditing(false);
    }
  }, [editingProposal]);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: value
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!formData.name.trim() || !formData.description.trim() || !formData.theme.trim()) {
      alert('Please fill in all fields');
      return;
    }

    onSubmit(formData);
    
    // Reset form after submission
    setFormData({
      name: '',
      description: '',
      theme: ''
    });
    setIsEditing(false);
  };

  const handleCancel = () => {
    setFormData({
      name: '',
      description: '',
      theme: ''
    });
    setIsEditing(false);
    if (onCancel){
      onCancel();
    }
  };

  return (
    <div className="proposal-form-container">
      <form onSubmit={handleSubmit} className="proposal-form">
        <div className="form-group">
          <label htmlFor="name">Proposal Name *</label>
          <input
            type="text"
            id="name"
            name="name"
            value={formData.name}
            onChange={handleInputChange}
            placeholder="Enter proposal name"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="description">Proposal Description *</label>
          <textarea
            id="description"
            name="description"
            value={formData.description}
            onChange={handleInputChange}
            placeholder="Enter detailed description of your proposal"
            rows="4"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="theme">Theme *</label>
          <select
            id="theme"
            name="theme"
            value={formData.theme}
            onChange={handleInputChange}
            required
          >
            <option value="">Select a theme</option>
            <option value="Technology">Technology</option>
            <option value="Business Process">Business Process</option>
            <option value="Innovation">Innovation</option>
            <option value="Sustainability">Sustainability</option>
            <option value="Customer Experience">Customer Experience</option>
            <option value="Cost Optimization">Cost Optimization</option>
            <option value="Quality Improvement">Quality Improvement</option>
            <option value="Digital Transformation">Digital Transformation</option>
          </select>
        </div>

        <div className="form-actions">
          <button type="submit" className="submit-btn">
            {isEditing ? 'Update Proposal' : 'Submit Proposal'}
          </button>
          {isEditing && (
            <button type="button" className="cancel-btn" onClick={handleCancel}>
              Cancel
            </button>
          )}
        </div>
      </form>
    </div>
  );
};

export default ProposalForm;