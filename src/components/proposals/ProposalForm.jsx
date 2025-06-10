import React, { useState, useEffect } from 'react';
import Accordion from '../common/Accordion';

const ProposalForm = ({ onSubmit, editingProposal = null, onCancel}) => {
  const [formData, setFormData] = useState({
    proposalName: '',
    proposalDescription: '',
    theme: ''
  });
  const [isEditing, setIsEditing] = useState(false);

  useEffect(() => {
    const handleEditProposal = (event) => {
      const proposal = event.detail;
      setFormData({
        proposalName: proposal.proposalName,
        proposalDescription: proposal.proposalDescription,
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
        proposalName:editingProposal.proposalName,
        proposalDescription:editingProposal.proposalDescription,
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
    if (!formData.proposalName.trim() || !formData.proposalDescription.trim() || !formData.theme.trim()) {
      alert('Please fill in all fields');
      return;
    }

    onSubmit(formData);
    
    // Reset form after submission
    setFormData({
      proposalName: '',
      proposalDescription: '',
      theme: ''
    });
    setIsEditing(false);
  };

  const handleCancel = () => {
    setFormData({
      proposalName: '',
      proposalDescription: '',
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
          <label htmlFor="proposalName">Proposal Name *</label>
          <input
            type="text"
            id="proposalName"
            name="proposalName"
            value={formData.proposalName}
            onChange={handleInputChange}
            placeholder="Enter proposal Name"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="proposalDescription">Proposal Description *</label>
          <textarea
            id="proposalDescription"
            name="proposalDescription"
            value={formData.proposalDescription}
            onChange={handleInputChange}
            placeholder="Enter detailed Description of your proposal"
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