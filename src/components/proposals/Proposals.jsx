import React, { useState, useEffect } from 'react';
import Accordion from '../common/Accordion';
import ProposalForm from './ProposalForm';
import ProposalGrid from './ProposalGrid';
import { useProposals } from '../../hooks/useProposals';
import '../../styles/proposals.css';

const Proposals = () => {
  const { proposals, addProposal, updateProposal, deleteProposal, loading } = useProposals();
  const [userProposals, setUserProposals] = useState([]);
  const [allProposals, setAllProposals] = useState([]);
  const [editingProposal, setEditingProposal] = useState(null);

  //accordion management
  const [accordionStates, setAccordionStates] = useState({
    proposals: true,
    proposalWork: false
  });

  useEffect(() => {
    if (proposals) {
      const currentUser = JSON.parse(localStorage.getItem('user') || '{}');
      const userSubmittedProposals = proposals.filter(p => p.submitter === currentUser.name);
      setUserProposals(userSubmittedProposals);
      setAllProposals(proposals);
    }
  }, [proposals]);

  //For handling accordion toggle
  const toggleAccordion = async (accordionName) => {
    setAccordionStates(prev => {
      if(prev[accordionName]){
        return{
      ...prev,
      [accordionName]: !prev[accordionName]
    };
  }

  const newstates={}
  Object.keys(prev).forEach(key=>{
    newstates[key]=key===accordionName;
  });
  return newstates;
});
};

  const handleProposalSubmit = async (proposalData) => {
    try {
      const currentUser = JSON.parse(localStorage.getItem('user') || '{}');
      
      if (editingProposal) {
        // Update existing proposal
        const updatedProposal = {
          ...editingProposal,
          ...proposalData,
          updatedAt: new Date().toISOString().split('T')[0]
        };
        
        await updateProposal(updatedProposal);
        setUserProposals(prev => 
          prev.map(p => p.id === editingProposal.id ? updatedProposal : p)
        );
        setAllProposals(prev => 
          prev.map(p => p.id === editingProposal.id ? updatedProposal : p)
        );
        setEditingProposal(null);
      } else {
        // Create new proposal
        const newProposal = {
          ...proposalData,
          id: Date.now().toString(),
          submitter: currentUser.name,
          dateOfSubmission: new Date().toISOString().split('T')[0],
          status: 'Pending',
          teams: []
        };
        
        await addProposal(newProposal);
        setUserProposals(prev => [...prev, newProposal]);
        setAllProposals(prev => [...prev, newProposal]);
      }
    } catch (error) {
      console.error('Error submitting proposal:', error);
    }
  };

  const handleProposalEdit = (proposal) => {
    setEditingProposal(proposal);
    // Dispatch event to ProposalForm
    const editEvent = new CustomEvent('editProposal', { detail: proposal });
    document.dispatchEvent(editEvent);
  };

  const handleProposalDelete = async (proposalId) => {
    if (window.confirm('Are you sure you want to delete this proposal?')) {
      try {
        await deleteProposal(proposalId);
        setUserProposals(prev => prev.filter(p => p.id !== proposalId));
        setAllProposals(prev => prev.filter(p => p.id !== proposalId));
      } catch (error) {
        console.error('Error deleting proposal:', error);
      }
    }
  };

  const handleCancelEdit = () => {
    setEditingProposal(null);
  };

  const handleProposalEditFromGrid = async (proposalData) => {
    try {
      await updateProposal(proposalData);
      setUserProposals(prev => 
        prev.map(p => p.id === proposalData.id ? proposalData : p)
      );
      setAllProposals(prev => 
        prev.map(p => p.id === proposalData.id ? proposalData : p)
      );
    } catch (error) {
      console.error('Error updating proposal:', error);
    }
  };

  // if (loading) {
  //   return <div className="loading">Loading proposals...</div>;
  // }

  return (
    <div className="proposals-container">
      <h1>Proposals Management</h1>
      
      <div className="proposals-content">
        <Accordion 
          title="Proposals"
          isOpen={accordionStates.proposals}
          onClick={() => toggleAccordion('proposals')}>

          <div className="proposals-section">
            <ProposalForm 
              onSubmit={handleProposalSubmit} 
              editingProposal={editingProposal}
              onCancel={handleCancelEdit}
            />
            
            {userProposals.length > 0 && (
              <div className="submitted-proposals">
                <h3>Your Submitted Proposals</h3>
                <div className="proposals-list">
                  {userProposals.map(proposal => (
                    <div key={proposal.id} className="proposal-item">
                      <div className="proposal-details">
                        <h4>{proposal.name}</h4>
                        <p><strong>Description:</strong> {proposal.description}</p>
                        <p><strong>Theme:</strong> {proposal.theme}</p>
                        <p><strong>Status:</strong> <span className={`status ${proposal.status.toLowerCase()}`}>{proposal.status}</span></p>
                        <p><strong>Submitted:</strong> {proposal.dateOfSubmission}</p>
                        {proposal.updatedAt && (
                          <p><strong>Last Updated:</strong> {proposal.updatedAt}</p>
                        )}
                      </div>
                      <div className="proposal-actions">
                        <button 
                          className="edit-btn"
                          onClick={() => handleProposalEdit(proposal)}
                        >
                          Edit
                        </button>
                        <button 
                          className="remove-btn"
                          onClick={() => handleProposalDelete(proposal.id)}
                        >
                          Remove
                        </button>
                      </div>
                    </div>
                  ))}
                </div>
              </div>
            )}
          </div>
        </Accordion>

        <Accordion
          title="Proposal Work"
          isOpen={accordionStates.proposalWork}
          onClick={() => toggleAccordion('proposalWork')}>
          <div className="proposal-work-section">
            <ProposalGrid 
              proposals={allProposals}
              onProposalEdit={handleProposalEditFromGrid}
            />
          </div>
        </Accordion>
      </div>
    </div>
  );
};

export default Proposals;