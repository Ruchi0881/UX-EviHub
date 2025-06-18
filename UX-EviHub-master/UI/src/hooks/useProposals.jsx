import { useState, useEffect, useContext } from 'react';
import { ProposalContext } from '../context/ProposalContext';
import { proposalService } from '../services/proposalService';

export const useProposals = () => {
  const context = useContext(ProposalContext);
  
  if (!context) {
    // Fallback if context is not available
    const [proposals, setProposals] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    const fetchProposals = async () => {
      setLoading(true);
      try {
        const data = await proposalService.getAllProposals();
        setProposals(data);
        setError(null);
      } catch (err) {
        setError(err.message);
        console.error('Error fetching proposals:', err);
      } finally {
        setLoading(false);
      }
    };

    const addProposal = async (proposalData) => {
      setLoading(true);
      try {
        const newProposal = await proposalService.createProposal(proposalData);
        setProposals(prev => [...prev, newProposal]);
        setError(null);
        return newProposal;
      } catch (err) {
        setError(err.message);
        console.error('Error adding proposal:', err);
        throw err;
      } finally {
        setLoading(false);
      }
    };

    const updateProposal = async (proposalData) => {
      setLoading(true);
      try {
        const updatedProposal = await proposalService.updateProposal(proposalData.id, proposalData);
        setProposals(prev => 
          prev.map(p => p.id === proposalData.id ? updatedProposal : p)
        );
        setError(null);
        return updatedProposal;
      } catch (err) {
        setError(err.message);
        console.error('Error updating proposal:', err);
        throw err;
      } finally {
        setLoading(false);
      }
    };

    const deleteProposal = async (proposalId) => {
      setLoading(true);
      try {
        await proposalService.deleteProposal(proposalId);
        setProposals(prev => prev.filter(p => p.id !== proposalId));
        setError(null);
      } catch (err) {
        setError(err.message);
        console.error('Error deleting proposal:', err);
        throw err;
      } finally {
        setLoading(false);
      }
    };

    const getProposalById = (id) => {
      return proposals.find(proposal => proposal.id === id);
    };

    const getProposalsByUser = (userId) => {
      return proposals.filter(proposal => proposal.submitter === userId);
    };

    const getProposalsByStatus = (status) => {
      return proposals.filter(proposal => proposal.status === status);
    };

    useEffect(() => {
      fetchProposals();
    }, []);

    return {
      proposals,
      loading,
      error,
      fetchProposals,
      addProposal,
      updateProposal,
      deleteProposal,
      getProposalById,
      getProposalsByUser,
      getProposalsByStatus
    };
  }

  return context;
};