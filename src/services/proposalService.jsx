const api = {
    get: async (url) => {
      const response = await fetch(`/api${url}`);
      if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);
      return { data: await response.json() };
    },
    post: async (url, data) => {
      const response = await fetch(`/api${url}`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
      });
      if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);
      return { data: await response.json() };
    },
    put: async (url, data) => {
      const response = await fetch(`/api${url}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
      });
      if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);
      return { data: await response.json() };
    },
    delete: async (url) => {
      const response = await fetch(`/api${url}`, { method: 'DELETE' });
      if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);
      return { data: await response.json() };
    },
    patch: async (url, data) => {
      const response = await fetch(`/api${url}`, {
        method: 'PATCH',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
      });
      if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);
      return { data: await response.json() };
    }
  };
  
  export const proposalService = {
    // Get all proposals
    getAllProposals: async () => {
      try {
        // For development, return mock data if API is not available
        const mockProposals = [
          {
            id: '1',
            proposalName: 'AI-Powered Customer Service',
            proposalDescription: 'Implement AI chatbots to improve customer service response times and accuracy.',
            theme: 'Technology',
            status: 'Approved',
            teams: ['Bhavana', 'Vaishnavi'],
            dateOfSubmission: '2024-01-15',
            submitter: 'Nikhil'
          },
          {
            id: '2',
            proposalName: 'Green Office Initiative',
            proposalDescription: 'Reduce office carbon footprint through sustainable practices and equipment.',
            theme: 'Sustainability',
            status: 'In-Progress',
            teams: ['Bhanu', 'Sai'],
            dateOfSubmission: '2024-01-20',
            submitter: 'Ruchira'
          },
          {
            id: '3',
            proposalName: 'Remote Work Policy Enhancement',
            proposalDescription: 'Improve remote work policies to increase employee satisfaction and productivity.',
            theme: 'Sustainability',
            status: 'Pending',
            teams: [],
            dateOfSubmission: '2024-01-25',
            submitter: 'Bhavana'
          }
        ];
  
        try {
          const response = await api.get('/proposals');
          return response.data;
        } catch (error) {
          console.warn('API not available, using mock data:', error.message);
          return mockProposals;
        }
      } catch (error) {
        console.error('Error fetching proposals:', error);
        throw new Error('Failed to fetch proposals');
      }
    },
  
    // Get proposal by ID
    getProposalById: async (id) => {
      try {
        const response = await api.get(`/proposals/${id}`);
        return response.data;
      } catch (error) {
        console.error('Error fetching proposal:', error);
        throw new Error('Failed to fetch proposal');
      }
    },
  
    // Create new proposal
    createProposal: async (proposalData) => {
      try {
        // For development, simulate API call
        const newProposal = {
          ...proposalData,
          id: Date.now().toString(),
          dateOfSubmission: new Date().toISOString().split('T')[0],
          status: 'Pending',
          teams: []
        };
  
        try {
          const response = await api.post('/proposals', newProposal);
          return response.data;
        } catch (error) {
          console.warn('API not available, using mock response:', error.message);
          return newProposal;
        }
      } catch (error) {
        console.error('Error creating proposal:', error);
        throw new Error('Failed to create proposal');
      }
    },
  
    // Update proposal
    updateProposal: async (id, proposalData) => {
      try {
        const updatedProposal = {
          ...proposalData,
          id,
          updatedAt: new Date().toISOString().split('T')[0]
        };
  
        try {
          const response = await api.put(`/proposals/${id}`, updatedProposal);
          return response.data;
        } catch (error) {

          console.warn('API not available, using mock response:', error.message);
          return updatedProposal;
        }
      } catch (error) {
        console.error('Error updating proposal:', error);
        throw new Error('Failed to update proposal');
      }
    },
  
    // Delete proposal
    deleteProposal: async (id) => {
      try {
        try{
        const response = await api.delete(`/proposals/${id}`);
        return response.data;
      } catch (error) {
        console.error('Error deleting proposal:', error);
        return{success:true};
      }
    } catch(error){
        console.error('Error deleting proposal:',error);
        throw new Error('Failed to delete proposal');
    }
    },
  
    // Get proposals by user
    getProposalsByUser: async (userId) => {
      try {
        const response = await api.get(`/proposals/user/${userId}`);
        return response.data;
      } catch (error) {
        console.error('Error fetching user proposals:', error);
        throw new Error('Failed to fetch user proposals');
      }
    },
  
    // Get proposals by status
    getProposalsByStatus: async (status) => {
      try {
        const response = await api.get(`/proposals/status/${status}`);
        return response.data;
      } catch (error) {
        console.error('Error fetching proposals by status:', error);
        throw new Error('Failed to fetch proposals by status');
      }
    },
  
    // Update proposal status
    updateProposalStatus: async (id, status) => {
      try {
        const response = await api.patch(`/proposals/${id}/status`, { status });
        return response.data;
      } catch (error) {
        console.error('Error updating proposal status:', error);
        throw new Error('Failed to update proposal status');
      }
    },
  
    // Assign team to proposal
    assignTeam: async (id, teamMembers) => {
      try {
        const response = await api.patch(`/proposals/${id}/team`, { teams: teamMembers });
        return response.data;
      } catch (error) {
        console.error('Error assigning team:', error);
        throw new Error('Failed to assign team');
      }
    }
  };