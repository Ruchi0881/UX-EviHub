import React, { useState, useEffect} from 'react';
import Accordion from '../common/Accordion';

const ProposalGrid = ({ proposals = [] }) => {
  const [visibleColumns, setVisibleColumns] = useState({
    proposalName: true,
    proposalDescription: true,
    theme: true,
    status: true,
    teams: true,
    ProposalDate: false,
    submitter: false
  });
  const [showColumnSelector, setShowColumnSelector] = useState(false);

  const toggleColumn = (columnName) => {
    setVisibleColumns(prev => ({
      ...prev,
      [columnName]: !prev[columnName]
    }));
  };

  const getStatusClass = (status) => {
    switch (status?.toLowerCase()) {
      case 'approved':
        return 'status-approved';
      case 'rejected':
        return 'status-rejected';
      case 'in-progress':
        return 'status-in-progress';
      case 'completed':
        return 'status-completed';
      default:
        return 'status-pending';
    }
  };

  const formatTeams = (teams) => {
    if (!teams || teams.length === 0) {
      return 'Not assigned';
    }
    return teams.join(', ');
  };

  const formatDate = (dateString) => {
    if (!dateString) return 'N/A';
    return new Date(dateString).toLocaleDateString();
  };

  return (
    <div className="proposalName-grid-container">
      <div className="grid-header">
        <h3>All Proposals</h3>
        <div className="grid-controls">
          <button 
            className="add-column-btn"
            onClick={() => setShowColumnSelector(!showColumnSelector)}
          >
            Add Column
          </button>
          
          {showColumnSelector && (
            <div className="column-selector">
              <h4>Select Columns to Display:</h4>
              <div className="column-checkboxes">
                <label>
                  <input
                    type="checkbox"
                    checked={visibleColumns.ProposalDate}
                    onChange={() => toggleColumn('ProposalDate')}
                  />
                  Date of Submission
                </label>
                <label>
                  <input
                    type="checkbox"
                    checked={visibleColumns.submitter}
                    onChange={() => toggleColumn('submitter')}
                  />
                  Submitter
                </label>
              </div>
              <button 
                className="close-selector-btn"
                onClick={() => setShowColumnSelector(false)}
              >
                Close
              </button>
            </div>
          )}
        </div>
      </div>

      {proposals.length === 0 ? (
        <div className="no-proposals">
          <p>No proposals available</p>
        </div>
      ) : (
        <div className="proposals-grid">
          <table className="proposals-table">
            <thead>
              <tr>
                {visibleColumns.proposalName && <th>proposalName</th>}
                {visibleColumns.proposalDescription && <th>proposalDescription</th>}
                {visibleColumns.theme && <th>Theme</th>}
                {visibleColumns.status && <th>Status</th>}
                {visibleColumns.teams && <th>Teams</th>}
                {visibleColumns.ProposalDate && <th>Date of Submission</th>}
                {visibleColumns.submitter && <th>Submitter</th>}
              </tr>
            </thead>
            <tbody>
              {proposals.map((proposal) => (
                <tr key={proposal.id} className="proposalName-row">
                  {visibleColumns.proposalName && (
                    <td className="proposalName-name">
                      <strong>{proposal.proposalName}</strong>
                    </td>
                  )}
                  {visibleColumns.proposalDescription && (
                    <td className="proposalName-proposalDescription">
                      <div className="proposalDescription-content" title={proposal.proposalDescription}>
                        {proposal.proposalDescription.length > 100 
                          ? `${proposal.proposalDescription.substring(0, 100)}...` 
                          : proposal.proposalDescription}
                      </div>
                    </td>
                  )}
                  {visibleColumns.theme && (
                    <td className="proposalName-theme">
                      <span className="theme-badge">{proposal.theme}</span>
                    </td>
                  )}
                  {visibleColumns.status && (
                    <td className="proposalName-status">
                      <span className={`status-badge ${getStatusClass(proposal.status)}`}>
                        {proposal.status}
                      </span>
                    </td>
                  )}
                  {visibleColumns.teams && (
                    <td className="proposalName-teams">
                      {formatTeams(proposal.teams)}
                    </td>
                  )}
                  {visibleColumns.ProposalDate && (
                    <td className="proposalName-date">
                      {formatDate(proposal.ProposalDate)}
                    </td>
                  )}
                  {visibleColumns.submitter && (
                    <td className="proposalName-submitter">
                      {proposal.submitter}
                    </td>
                  )}
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
};

export default ProposalGrid;