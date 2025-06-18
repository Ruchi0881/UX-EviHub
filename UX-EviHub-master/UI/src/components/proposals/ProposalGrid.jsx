import React, { useState } from 'react';
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
      case 'approved': return 'status-approved';
      case 'rejected': return 'status-rejected';
      case 'in-progress': return 'status-in-progress';
      case 'completed': return 'status-completed';
      default: return 'status-pending';
    }
  };

  const formatTeams = (teams) => {
    if (!teams || teams.length === 0) return 'Not assigned';
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
                {visibleColumns.proposalName && <th>Proposal Name</th>}
                {visibleColumns.proposalDescription && <th>Description</th>}
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
                      {formatDate(proposal.proposalDate)}
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

      {/* Inline CSS for Evernorth theme */}
      <style>{`
        .proposalName-grid-container {
          padding: 20px;
          font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
          background-color: #f7fafa;
        }
        .grid-header {
          display: flex;
          justify-content: space-between;
          align-items: center;
          margin-bottom: 15px;
        }
        .grid-header h3 {
          color: #003B49;
          margin: 0;
        }
        .add-column-btn,
        .close-selector-btn {
          background-color: #007C91;
          color: white;
          border: none;
          padding: 6px 12px;
          border-radius: 4px;
          cursor: pointer;
          font-weight: bold;
        }
        .add-column-btn:hover,
        .close-selector-btn:hover {
          background-color: #005e6b;
        }
        .column-selector {
          position: absolute;
          top: 35px;
          right: 0;
          background-color: #ffffff;
          border: 1px solid #ccc;
          padding: 10px;
          border-radius: 6px;
          box-shadow: 0 2px 8px rgba(0,0,0,0.1);
          z-index: 100;
        }
        .column-checkboxes label {
          display: block;
          margin: 5px 0;
          color: #003B49;
        }
        .proposals-table {
          width: 100%;
          border-collapse: collapse;
          background-color: white;
          box-shadow: 0 0 10px rgba(0, 60, 70, 0.05);
        }
        .proposals-table th,
        .proposals-table td {
          padding: 10px 12px;
          border-bottom: 1px solid #e0e0e0;
          text-align: left;
          color: #222;
        }
        .proposals-table th {
          background-color: #E5F2F4;
          color: #003B49;
        }
        .proposalName-row:hover {
          background-color: #f0f8f9;
        }
        .theme-badge {
          background-color: #007C91;
          color: white;
          padding: 4px 8px;
          border-radius: 4px;
          font-size: 0.85rem;
        }
        .status-badge {
          padding: 4px 10px;
          border-radius: 5px;
          color: white;
          font-weight: 600;
          text-transform: capitalize;
          font-size: 0.85rem;
        }
        .status-approved {
          background-color: #007C91;
        }
        .status-rejected {
          background-color: #cc1f1f;
        }
        .status-in-progress {
          background-color: #ffa500;
          color: #003B49;
        }
        .status-completed {
          background-color: #2e8b57;
        }
        .status-pending {
          background-color: #999999;
        }
        .no-proposals {
          text-align: center;
          color: #777;
          font-style: italic;
        }
      `}</style>
    </div>
  );
};

export default ProposalGrid;
