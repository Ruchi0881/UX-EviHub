import React, { useState, useEffect, useRef } from 'react';
import { useAuth } from '../../context/AuthContext';
import { useSkills } from '../../hooks/useSkills';
import { useCertifications } from '../../hooks/usecertifications';
import Accordion from '../common/Accordion';
import '../../styles/dashboard.css';

const Skillset = ({ isSkillsetOpen, userId }) => {
  const { user } = useAuth();
  const { skills: availableSkills, userSkills, saveUserSkills, fetchAvailableSkills, fetchUserSkills } = useSkills();
  const { availableCerts, userCerts, saveUserCerts, fetchAvailableCerts, fetchUserCerts } = useCertifications();

  const [isEditing, setIsEditing] = useState(false);
  const [formData, setFormData] = useState({
    skills: '',
    certifications: []
  });

  const [selectedSkills, setSelectedSkills] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const dropdownRef = useRef(null);
  const inputRef = useRef(null);

  const mockUserId='user123';//for testing

  useEffect(() => {
    const currentUserId=user?.id||userId||mockUserId;
    if (currentUserId) {
      const fetchData=async()=>{
        try{
          await Promise.all([
            fetchAvailableSkills(),
            fetchUserSkills(currentUserId),
            fetchAvailableCerts(),
            fetchUserCerts(currentUserId)
          ]);
        } catch(error){
          console.error('error fetching',error);
        }
      };
      fetchData();
    }
  }, [user?.id]);

  useEffect(() => {
    setFormData({
      skills: userSkills || '',
      certifications: Array.isArray(userCerts)?userCerts:[]
    });
    setSelectedSkills(userSkills ? userSkills.split(', ').filter(skill=>skill.trim()!=='') : []);
  }, [userSkills, userCerts]);

  useEffect(() => {
    const handleClickOutside = (event) => {
      if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
        setDropdownOpen(false);
      }
    };
    document.addEventListener('mousedown', handleClickOutside);
    return () => document.removeEventListener('mousedown', handleClickOutside);
  }, []);

  const filteredSkills = Array.isArray(availableSkills)
    ? availableSkills.filter(skill => skill &&
    skill.toLowerCase().includes(searchTerm.toLowerCase().includes(searchTerm.toLocaleLowerCase))
  ):[];

  const toggleDropdown = () => {
    setDropdownOpen(!dropdownOpen);
    if (!dropdownOpen && inputRef.current) inputRef.current.focus();
  };

  const toggleSkill = (skill) => {
    const updatedSkills = selectedSkills.includes(skill)
      ? selectedSkills.filter(s => s !== skill)
      : [...selectedSkills, skill];
    setSelectedSkills(updatedSkills);
    setFormData(prev => ({ ...prev, skills: updatedSkills.join(', ') }));
    if (inputRef.current) inputRef.current.focus();
  };

  const removeSkill = (skillToRemove) => {
    const updatedSkills = selectedSkills.filter(skill => skill !== skillToRemove);
    setSelectedSkills(updatedSkills);
    setFormData(prev => ({ ...prev, skills: updatedSkills.join(', ') }));
    if (inputRef.current) inputRef.current.focus();
  };

  const handleSearchChange = (e) => {
    setSearchTerm(e.target.value);
    if (!dropdownOpen) setDropdownOpen(true);
  };

  const handleKeyDown = (e) => {
    if (e.key === 'Enter' && searchTerm.trim() !== '') {
      e.preventDefault();
      const matchingSkill = availableSkills.find(skill => skill.toLowerCase() === searchTerm.toLowerCase());
      if (matchingSkill) {
        toggleSkill(matchingSkill);
      } else if (!selectedSkills.includes(searchTerm.trim())) {
        const updatedSkills = [...selectedSkills, searchTerm.trim()];
        setSelectedSkills(updatedSkills);
        setFormData(prev => ({ ...prev, skills: updatedSkills.join(', ') }));
      }
      setSearchTerm('');
    } else if (e.key === 'Backspace' && searchTerm === '' && selectedSkills.length > 0) {
      removeSkill(selectedSkills[selectedSkills.length - 1]);
    }
  };

  const handleCertChange = (index, field, value) => {
    const updatedCerts = [...formData.certifications];
    updatedCerts[index][field] = value;
    setFormData(prev => ({ ...prev, certifications: updatedCerts }));
  };

  const addNewCert = () => {
    setFormData(prev => ({
      ...prev,
      certifications: [...prev.certifications, { id:`temp-${Date.now()}` ,name: '', status: 'Yet to Start', completionDate: '', comments: '' }]
    }));
  };

  const removeCert = (index) => {
    const updatedCerts = formData.certifications.filter((_, i) => i !== index);
    setFormData(prev => ({ ...prev, certifications: updatedCerts }));
  };

  const handleSave = async () => {
      const currentUserId = user?.id || userId || mockUserId;
  if (!currentUserId) {
    console.error('No user ID available for saving');
    return;
  }

  console.log('Saving changes:', {
    userId: currentUserId,
    skills: selectedSkills,
    certifications: formData.certifications
  });

  try {
      await Promise.all([
        saveUserSkills(currentUserId, formData.skills),
        saveUserCerts(currentUserId, formData.certifications)
      ]);
      console.log('Save successful');
      setIsEditing(false);
    } catch (error) {
      console.error('Error saving data:', error);
    }
  };

  const handleCancel = () => {
    setFormData({
      skills: userSkills || '',
      certifications: Array.isArray(userCerts) ? userCerts : []
    });
    setSelectedSkills(userSkills ? userSkills.split(', ').filter(skill => skill.trim() !== '') : []);
    setIsEditing(false);
  };

  const handleSectionToggle=()=>{

  }

  return (
    <Accordion 
      title="Skillset"
      isOpen={isSkillsetOpen} 
      onClick={handleSectionToggle}
    >
      <div className="form-section">
        <div className="form-group inline-form-group">
          <label>Skills</label>
          {isEditing ? (
            <div className="skills-input-container">
              {/* Enhanced multi-select dropdown with checkboxes and inline skills */}
              <div className="multi-select-dropdown" ref={dropdownRef}>
                <div 
                  className={`dropdown-header ${dropdownOpen ? 'active' : ''}`}
                  onClick={toggleDropdown}
                >
                  <div className="inline-skills-container">
                    {selectedSkills.map(skill => (
                      <span key={skill} className="inline-skill-tag">
                        {skill}
                        <button 
                          className="inline-remove-skill-btn"
                          onClick={(e) => {
                            e.stopPropagation();
                            removeSkill(skill);
                          }}
                          aria-label={`Remove ${skill}`}
                        >
                          ×
                        </button>
                      </span>
                    ))}
                  </div>
                </div>

                <div id='dropdown-input'>
                  <input 
                    ref={inputRef}
                    type="text" 
                    placeholder={selectedSkills.length ? "Search to add more skills..." : "Search or add skills..."}
                    value={searchTerm}
                    onChange={handleSearchChange}
                    onClick={(e) => {
                      e.stopPropagation();
                      setDropdownOpen(true);
                    }}
                    onKeyDown={handleKeyDown}
                    className="inline-skill-search-input"
                    aria-label="Search skills"
                  />
                  <span className={`dropdown-arrow ${dropdownOpen ? 'open' : ''}`}>▼</span>
                </div>
                
                {dropdownOpen && (
                  <div className="dropdown-options-container">
                    {filteredSkills.length > 0 ? (
                      <div className="dropdown-options">
                        {filteredSkills.map(skill => (
                          <div 
                            key={skill} 
                            className={`dropdown-option checkbox-option ${selectedSkills.includes(skill) ? 'selected' : ''}`}
                            onClick={() => toggleSkill(skill)}
                          >
                            <div className="skill-checkbox-container">
                              <input 
                                type="checkbox" 
                                checked={selectedSkills.includes(skill)}
                                onChange={() => toggleSkill(skill)}
                                className="skill-checkbox"
                                id={`skill-${skill.replace(/\s+/g, '-').toLowerCase()}`}
                              />
                              <label 
                                htmlFor={`skill-${skill.replace(/\s+/g, '-').toLowerCase()}`}
                                className="skill-checkbox-label"
                              >
                                {skill}
                              </label>
                            </div>
                          </div>
                        ))}
                      </div>
                    ) : (
                      <div className="dropdown-options">
                        <div className="dropdown-option no-results">
                          {searchTerm.trim() !== '' ? (
                            <>
                              No matches found. Press <kbd>Enter</kbd> to add "{searchTerm}" as a new skill.
                            </>
                          ) : (
                            "No more skills available"
                          )}
                        </div>
                      </div>
                    )}
                    
                    {/* Skills Summary */}
                    {selectedSkills.length > 0 && (
                      <div className="skills-summary">
                        <div className="skills-count">
                          {selectedSkills.length} skill{selectedSkills.length !== 1 ? 's' : ''} selected
                        </div>
                        <button 
                          type="button" 
                          className="clear-all-skills-btn"
                          onClick={() => {
                            setSelectedSkills([]);
                            setFormData(prev => ({ ...prev, skills: '' }));
                          }}
                        >
                          Clear All
                        </button>
                      </div>
                    )}
                  </div>
                )}
              </div>
            </div>
          ) : (
            <input
              type="text"
              value={formData.skills}
              readOnly
              className="form-input"
            />
          )}
        </div>

        <div className="form-group certificates-section">
          <label className="cert-section-label">Certifications</label>
          <div className="certificates-content">
            {isEditing ? (
              <div className="certifications-grid">
                <table className="cert-table">
                  <thead>
                    <tr>
                      <th>Name</th>
                      <th>Status</th>
                      <th>Completion Date</th>
                      <th>Comments</th>
                      <th>Actions</th>
                    </tr>
                  </thead>
                  <tbody>
                    {formData.certifications.map((cert, index) => (
                      <tr key={index}>
                        <td>
                          <select
                            value={cert.name}
                            onChange={(e) => handleCertChange(index, 'name', e.target.value)}
                            className="form-select"
                          >
                            <option value="">Select Certificate</option>
                            {availableCerts.map(certName => (
                              <option key={certName} value={certName}>{certName}</option>
                            ))}
                          </select>
                        </td>
                        <td>
                          <select
                            value={cert.status}
                            onChange={(e) => handleCertChange(index, 'status', e.target.value)}
                            className="form-select"
                          >
                            <option value="Completed">Completed</option>
                            <option value="In Progress">In Progress</option>
                            <option value="Yet to Start">Yet to Start</option>
                          </select>
                        </td>
                        <td>
                          <input
                            type="date"
                            value={cert.completionDate}
                            onChange={(e) => handleCertChange(index, 'completionDate', e.target.value)}
                            disabled={cert.status !== 'Completed'}
                            className="form-input"
                          />
                        </td>
                        <td>
                          <input
                            type="text"
                            value={cert.comments}
                            onChange={(e) => handleCertChange(index, 'comments', e.target.value)}
                            className="form-input"
                            placeholder="Any comments"
                          />
                        </td>
                        <td>
                          <button 
                            onClick={() => removeCert(index)}
                            className="btn-danger btn-sm"
                          >
                            Remove
                          </button>
                        </td>
                      </tr>
                    ))}
                  </tbody>
                </table>
                <div className="add-cert-button-container">
                  <button 
                    onClick={addNewCert}
                    className="btn-secondary btn-sm"
                  >
                    + Add Certificate
                  </button>
                </div>
              </div>
            ) : (
              <div className="certifications-display">
                {formData.certifications.length > 0 ? (
                  <table className="cert-table">
                    <thead>
                      <tr>
                        <th>Name</th>
                        <th>Status</th>
                        <th>Completion Date</th>
                        <th>Comments</th>
                      </tr>
                    </thead>
                    <tbody>
                      {formData.certifications.map((cert, index) => (
                        <tr key={index}>
                          <td>{cert.name}</td>
                          <td>
                            <span className={`status-badge ${cert.status.toLowerCase().replace(' ', '-')}`}>
                              {cert.status}
                            </span>
                          </td>
                          <td>{cert.completionDate || '-'}</td>
                          <td>{cert.comments || '-'}</td>
                        </tr>
                      ))}
                    </tbody>
                  </table>
                ) : (
                  <p className="no-certs-message">No certifications added yet.</p>
                )}
              </div>
            )}
          </div>
        </div>

        {isEditing ? (
          <div className="form-actions">
            <button type="button" className="btn-primary" onClick={handleSave}>
              Save Changes
            </button>
            <button type="button" className="btn-secondary" onClick={handleCancel}>
              Cancel
            </button>
          </div>
        ) : (
          <div className="form-actions">
            <button 
              type="button" 
              className="btn-primary" 
              onClick={() => setIsEditing(true)}
            >
              Edit 
            </button>
          </div>
        )}
      </div>
    </Accordion>
  );
};

export default Skillset;

// import React, { useState, useEffect, useRef } from 'react';
// import { useAuth } from '../../context/AuthContext';
// import Accordion from '../common/Accordion';
// import '../../styles/dashboard.css';

// const Skillset = ({ isSkillsetOpen }) => {
//   const { user } = useAuth();
//   const [isEditing, setIsEditing] = useState(false);
//   const [formData, setFormData] = useState({
//     skills: '',
//     certifications: []
//   });

//   const [availableSkills, setAvailableSkills] = useState([]);
//   const [availableCerts, setAvailableCerts] = useState([]);
  
//   // States for the enhanced dropdown
//   const [selectedSkills, setSelectedSkills] = useState([]);
//   const [searchTerm, setSearchTerm] = useState('');
//   const [dropdownOpen, setDropdownOpen] = useState(false);
//   const dropdownRef = useRef(null);
//   const inputRef = useRef(null);

//   useEffect(() => {
//     // Mock data - replace with API calls
//     setFormData({
//       skills: user?.skills || 'React, JavaScript, HTML/CSS',
//       certifications: user?.certifications || [
//         { name: 'AWS Certified', status: 'Completed', completionDate: '2023-01-15', comments: '' },
//         { name: 'Scrum Master', status: 'In Progress', completionDate: '', comments: 'Expected completion by Q3' }
//       ]
//     });

//     setAvailableSkills([
//       'React', 'JavaScript', 'HTML/CSS', 'Node.js', 'Python', 'TypeScript', 
//       'Docker', 'GraphQL', 'AWS', 'Git', 'SQL', 'MongoDB', 'Redux', 'Vue.js', 
//       'Angular', 'Express.js', 'Java', 'C#', 'PHP', 'Ruby', 'Swift', 'Kotlin'
//     ]);
//     setAvailableCerts(['AWS Certified', 'Scrum Master', 'PMP', 'Google Cloud', 'Azure Fundamentals', 'CISSP']);
    
//     // Initialize selected skills from user data
//     if (user?.skills) {
//       setSelectedSkills(user.skills.split(', '));
//     } else {
//       setSelectedSkills(['React', 'JavaScript', 'HTML/CSS']);
//     }
//   }, [user]);
  
//   // Close dropdown when clicking outside
//   useEffect(() => {
//     const handleClickOutside = (event) => {
//       if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
//         setDropdownOpen(false);
//       }
//     };
    
//     document.addEventListener('mousedown', handleClickOutside);
//     return () => {
//       document.removeEventListener('mousedown', handleClickOutside);
//     };
//   }, []);

//   const filteredSkills = availableSkills.filter(skill => 
//     skill.toLowerCase().includes(searchTerm.toLowerCase())
//   );

//   const toggleDropdown = () => {
//     setDropdownOpen(!dropdownOpen);
//     if (!dropdownOpen && inputRef.current) {
//       // Focus the input when opening the dropdown
//       inputRef.current.focus();
//     }
//   };

//   const toggleSkill = (skill) => {
//     let updatedSkills;
//     if (selectedSkills.includes(skill)) {
//       updatedSkills = selectedSkills.filter(s => s !== skill);
//     } else {
//       updatedSkills = [...selectedSkills, skill];
//     }
    
//     setSelectedSkills(updatedSkills);
//     setFormData(prev => ({
//       ...prev,
//       skills: updatedSkills.join(', ')
//     }));
    
//     // Keep focus on input after toggling a skill
//     if (inputRef.current) {
//       inputRef.current.focus();
//     }
//   };

//   const addSkill = (skill) => {
//     if (!selectedSkills.includes(skill)) {
//       const updatedSkills = [...selectedSkills, skill];
//       setSelectedSkills(updatedSkills);
//       setFormData(prev => ({
//         ...prev,
//         skills: updatedSkills.join(', ')
//       }));
//     }
//     setSearchTerm('');
    
//     // Keep focus on input after adding a skill
//     if (inputRef.current) {
//       inputRef.current.focus();
//     }
//   };

//   const removeSkill = (skillToRemove) => {
//     const updatedSkills = selectedSkills.filter(skill => skill !== skillToRemove);
//     setSelectedSkills(updatedSkills);
//     setFormData(prev => ({
//       ...prev,
//       skills: updatedSkills.join(', ')
//     }));
    
//     // Focus back on input after removing a skill
//     if (inputRef.current) {
//       inputRef.current.focus();
//     }
//   };

//   const handleSearchChange = (e) => {
//     setSearchTerm(e.target.value);
//     if (!dropdownOpen) setDropdownOpen(true);
//   };

//   // Add custom skill when pressing Enter if it doesn't exist in available options
//   const handleKeyDown = (e) => {
//     if (e.key === 'Enter' && searchTerm.trim() !== '') {
//       e.preventDefault();
      
//       // Check if the skill already exists in available options
//       const matchingSkill = availableSkills.find(
//         skill => skill.toLowerCase() === searchTerm.toLowerCase()
//       );
      
//       if (matchingSkill) {
//         // Toggle the existing skill with proper casing
//         toggleSkill(matchingSkill);
//       } else if (!selectedSkills.includes(searchTerm.trim())) {
//         // Add as new custom skill
//         const updatedSkills = [...selectedSkills, searchTerm.trim()];
//         setSelectedSkills(updatedSkills);
//         setFormData(prev => ({
//           ...prev,
//           skills: updatedSkills.join(', ')
//         }));
//         // Add to available skills for future use
//         setAvailableSkills(prev => [...prev, searchTerm.trim()]);
//       }
      
//       setSearchTerm('');
//     } else if (e.key === 'Backspace' && searchTerm === '' && selectedSkills.length > 0) {
//       // Remove the last skill when pressing backspace with empty search
//       const lastSkill = selectedSkills[selectedSkills.length - 1];
//       removeSkill(lastSkill);
//     }
//   };

//   const handleCertChange = (index, field, value) => {
//     const updatedCerts = [...formData.certifications];
//     updatedCerts[index][field] = value;
//     setFormData(prev => ({
//       ...prev,
//       certifications: updatedCerts
//     }));
//   };

//   const addNewCert = () => {
//     setFormData(prev => ({
//       ...prev,
//       certifications: [
//         ...prev.certifications,
//         { name: '', status: 'Yet to Start', completionDate: '', comments: '' }
//       ]
//     }));
//   };

//   const removeCert = (index) => {
//     const updatedCerts = formData.certifications.filter((_, i) => i !== index);
//     setFormData(prev => ({
//       ...prev,
//       certifications: updatedCerts
//     }));
//   };

//   const handleSave = () => {
//     console.log('Saving skillset:', formData);
//     setIsEditing(false);
//   };

//   const handleCancel = () => {
//     // Reset to user data
//     if (user?.skills) {
//       setSelectedSkills(user.skills.split(', '));
//     } else {
//       setSelectedSkills(['React', 'JavaScript', 'HTML/CSS']);
//     }
    
//     setFormData({
//       skills: user?.skills || 'React, JavaScript, HTML/CSS',
//       certifications: user?.certifications || [
//         { name: 'AWS Certified', status: 'Completed', completionDate: '2023-01-15', comments: '' },
//         { name: 'Scrum Master', status: 'In Progress', completionDate: '', comments: 'Expected completion by Q3' }
//       ]
//     });
//     setIsEditing(false);
//   };

//   // Handler to pass to parent for toggling section
//   const handleSectionToggle = () => {
//     // This will be handled by parent component
//   };

//   return (
//     <Accordion 
//       title="Skillset" 
//       isOpen={isSkillsetOpen}
//       onClick={handleSectionToggle}
//     >
//       <div className="form-section">
//         <div className="form-group inline-form-group">
//           <label>Skills</label>
//           {isEditing ? (
//             <div className="skills-input-container">
//               {/* Enhanced multi-select dropdown with checkboxes and inline skills */}
//               <div className="multi-select-dropdown" ref={dropdownRef}>
//                 <div 
//                   className={`dropdown-header ${dropdownOpen ? 'active' : ''}`}
//                   onClick={toggleDropdown}
//                 >
//                   <div className="inline-skills-container">
//                     {selectedSkills.map(skill => (
//                       <span key={skill} className="inline-skill-tag">
//                         {skill}
//                         <button 
//                           className="inline-remove-skill-btn"
//                           onClick={(e) => {
//                             e.stopPropagation();
//                             removeSkill(skill);
//                           }}
//                           aria-label={`Remove ${skill}`}
//                         >
//                           ×
//                         </button>
//                       </span>
//                     ))}
//                   </div>
//                 </div>

//                 <div id='dropdown-input'>
//                   <input 
//                     ref={inputRef}
//                     type="text" 
//                     placeholder={selectedSkills.length ? "Search to add more skills..." : "Search or add skills..."}
//                     value={searchTerm}
//                     onChange={handleSearchChange}
//                     onClick={(e) => {
//                       e.stopPropagation();
//                       setDropdownOpen(true);
//                     }}
//                     onKeyDown={handleKeyDown}
//                     className="inline-skill-search-input"
//                     aria-label="Search skills"
//                   />
//                   <span className={`dropdown-arrow ${dropdownOpen ? 'open' : ''}`}>▼</span>
//                 </div>
                
//                 {dropdownOpen && (
//                   <div className="dropdown-options-container">
//                     {filteredSkills.length > 0 ? (
//                       <div className="dropdown-options">
//                         {filteredSkills.map(skill => (
//                           <div 
//                             key={skill} 
//                             className={`dropdown-option checkbox-option ${selectedSkills.includes(skill) ? 'selected' : ''}`}
//                             onClick={() => toggleSkill(skill)}
//                           >
//                             <div className="skill-checkbox-container">
//                               <input 
//                                 type="checkbox" 
//                                 checked={selectedSkills.includes(skill)}
//                                 onChange={() => toggleSkill(skill)}
//                                 className="skill-checkbox"
//                                 id={`skill-${skill.replace(/\s+/g, '-').toLowerCase()}`}
//                               />
//                               <label 
//                                 htmlFor={`skill-${skill.replace(/\s+/g, '-').toLowerCase()}`}
//                                 className="skill-checkbox-label"
//                               >
//                                 {skill}
//                               </label>
//                             </div>
//                           </div>
//                         ))}
//                       </div>
//                     ) : (
//                       <div className="dropdown-options">
//                         <div className="dropdown-option no-results">
//                           {searchTerm.trim() !== '' ? (
//                             <>
//                               No matches found. Press <kbd>Enter</kbd> to add "{searchTerm}" as a new skill.
//                             </>
//                           ) : (
//                             "No more skills available"
//                           )}
//                         </div>
//                       </div>
//                     )}
                    
//                     {/* Skills Summary */}
//                     {selectedSkills.length > 0 && (
//                       <div className="skills-summary">
//                         <div className="skills-count">
//                           {selectedSkills.length} skill{selectedSkills.length !== 1 ? 's' : ''} selected
//                         </div>
//                         <button 
//                           type="button" 
//                           className="clear-all-skills-btn"
//                           onClick={() => {
//                             setSelectedSkills([]);
//                             setFormData(prev => ({ ...prev, skills: '' }));
//                           }}
//                         >
//                           Clear All
//                         </button>
//                       </div>
//                     )}
//                   </div>
//                 )}
//               </div>
//             </div>
//           ) : (
//             <input
//               type="text"
//               value={formData.skills}
//               readOnly
//               className="form-input"
//             />
//           )}
//         </div>

//         <div className="form-group certificates-section">
//           <label className="cert-section-label">Certifications</label>
//           <div className="certificates-content">
//             {isEditing ? (
//               <div className="certifications-grid">
//                 <table className="cert-table">
//                   <thead>
//                     <tr>
//                       <th>Name</th>
//                       <th>Status</th>
//                       <th>Completion Date</th>
//                       <th>Comments</th>
//                       <th>Actions</th>
//                     </tr>
//                   </thead>
//                   <tbody>
//                     {formData.certifications.map((cert, index) => (
//                       <tr key={index}>
//                         <td>
//                           <select
//                             value={cert.name}
//                             onChange={(e) => handleCertChange(index, 'name', e.target.value)}
//                             className="form-select"
//                           >
//                             <option value="">Select Certificate</option>
//                             {availableCerts.map(certName => (
//                               <option key={certName} value={certName}>{certName}</option>
//                             ))}
//                           </select>
//                         </td>
//                         <td>
//                           <select
//                             value={cert.status}
//                             onChange={(e) => handleCertChange(index, 'status', e.target.value)}
//                             className="form-select"
//                           >
//                             <option value="Completed">Completed</option>
//                             <option value="In Progress">In Progress</option>
//                             <option value="Yet to Start">Yet to Start</option>
//                           </select>
//                         </td>
//                         <td>
//                           <input
//                             type="date"
//                             value={cert.completionDate}
//                             onChange={(e) => handleCertChange(index, 'completionDate', e.target.value)}
//                             disabled={cert.status !== 'Completed'}
//                             className="form-input"
//                           />
//                         </td>
//                         <td>
//                           <input
//                             type="text"
//                             value={cert.comments}
//                             onChange={(e) => handleCertChange(index, 'comments', e.target.value)}
//                             className="form-input"
//                             placeholder="Any comments"
//                           />
//                         </td>
//                         <td>
//                           <button 
//                             onClick={() => removeCert(index)}
//                             className="btn-danger btn-sm"
//                           >
//                             Remove
//                           </button>
//                         </td>
//                       </tr>
//                     ))}
//                   </tbody>
//                 </table>
//                 <div className="add-cert-button-container">
//                   <button 
//                     onClick={addNewCert}
//                     className="btn-secondary btn-sm"
//                   >
//                     + Add Certificate
//                   </button>
//                 </div>
//               </div>
//             ) : (
//               <div className="certifications-display">
//                 {formData.certifications.length > 0 ? (
//                   <table className="cert-table">
//                     <thead>
//                       <tr>
//                         <th>Name</th>
//                         <th>Status</th>
//                         <th>Completion Date</th>
//                         <th>Comments</th>
//                       </tr>
//                     </thead>
//                     <tbody>
//                       {formData.certifications.map((cert, index) => (
//                         <tr key={index}>
//                           <td>{cert.name}</td>
//                           <td>
//                             <span className={`status-badge ${cert.status.toLowerCase().replace(' ', '-')}`}>
//                               {cert.status}
//                             </span>
//                           </td>
//                           <td>{cert.completionDate || '-'}</td>
//                           <td>{cert.comments || '-'}</td>
//                         </tr>
//                       ))}
//                     </tbody>
//                   </table>
//                 ) : (
//                   <p className="no-certs-message">No certifications added yet.</p>
//                 )}
//               </div>
//             )}
//           </div>
//         </div>

//         {isEditing ? (
//           <div className="form-actions">
//             <button type="button" className="btn-primary" onClick={handleSave}>
//               Save Changes
//             </button>
//             <button type="button" className="btn-secondary" onClick={handleCancel}>
//               Cancel
//             </button>
//           </div>
//         ) : (
//           <div className="form-actions">
//             <button 
//               type="button" 
//               className="btn-primary" 
//               onClick={() => setIsEditing(true)}
//             >
//               Edit 
//             </button>
//           </div>
//         )}
//       </div>
//     </Accordion>
//   );
// };

// export default Skillset;

// // import React, { useState, useEffect, useRef } from 'react';
// // import { useSkills, useCertifications } from '../../hooks/useSkill';
// // import Accordion from '../common/Accordion';
// // import '../../styles/dashboard.css';

// // const Skillset = ({ isSkillsetOpen }) => {
// //   const {
// //     skills: availableSkills,
// //     userSkills,
// //     loading: skillsLoading,
// //     updateUserSkills,
// //     addSkill,
// //     getCurrentUser
// //   } = useSkills();

// //   const {
// //     certifications: availableCerts,
// //     userCertifications,
// //     loading: certificationsLoading,
// //     addUserCertification,
// //     updateUserCertification,
// //     deleteUserCertification
// //   } = useCertifications();

// //   const [isEditing, setIsEditing] = useState(false);
// //   const [formData, setFormData] = useState({
// //     skills: '',
// //     certifications: []
// //   });

// //   // States for the enhanced dropdown
// //   const [selectedSkills, setSelectedSkills] = useState([]);
// //   const [searchTerm, setSearchTerm] = useState('');
// //   const [dropdownOpen, setDropdownOpen] = useState(false);
// //   const dropdownRef = useRef(null);
// //   const inputRef = useRef(null);

// //   // State for certificate dropdown
// //   const [certDropdownOpen, setCertDropdownOpen] = useState({});
// //   const [certSearchTerms, setCertSearchTerms] = useState({});

// //   const currentUser = getCurrentUser();
// //   const loading = skillsLoading || certificationsLoading;

// //   // Common certificate names for dropdown
// //   const commonCertifications = [
// //     'AWS Certified Solutions Architect',
// //     'Google Cloud Professional',
// //     'Microsoft Azure Fundamentals',
// //     'Certified ScrumMaster (CSM)',
// //     'Project Management Professional (PMP)',
// //     'CompTIA Security+',
// //     'Cisco Certified Network Associate (CCNA)',
// //     'Certified Information Systems Security Professional (CISSP)',
// //     'Oracle Certified Professional',
// //     'Salesforce Certified Administrator',
// //     'Docker Certified Associate',
// //     'Kubernetes Certified Administrator',
// //     'Red Hat Certified System Administrator',
// //     'VMware Certified Professional',
// //     'Certified Ethical Hacker (CEH)',
// //     'ITIL Foundation',
// //     'Six Sigma Green Belt',
// //     'Agile Certified Practitioner',
// //     'Tableau Desktop Specialist',
// //     'Power BI Data Analyst Associate'
// //   ];

// //   useEffect(() => {
// //     setSelectedSkills(userSkills || []);
// //     setFormData({
// //       skills: userSkills ? userSkills.join(', ') : '',
// //       certifications: userCertifications || []
// //     });
// //   }, [userSkills, userCertifications]);

// //   // Close dropdown when clicking outside
// //   useEffect(() => {
// //     const handleClickOutside = (event) => {
// //       if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
// //         setDropdownOpen(false);
// //       }
      
// //       // Close certificate dropdowns when clicking outside
// //       Object.keys(certDropdownOpen).forEach(key => {
// //         const dropdown = document.getElementById(`cert-dropdown-${key}`);
// //         if (dropdown && !dropdown.contains(event.target)) {
// //           setCertDropdownOpen(prev => ({ ...prev, [key]: false }));
// //         }
// //       });
// //     };
    
// //     document.addEventListener('mousedown', handleClickOutside);
// //     return () => {
// //       document.removeEventListener('mousedown', handleClickOutside);
// //     };
// //   }, [certDropdownOpen]);

// //   const filteredSkills = availableSkills.filter(skill => 
// //     skill.toLowerCase().includes(searchTerm.toLowerCase())
// //   );

// //   const toggleDropdown = () => {
// //     setDropdownOpen(!dropdownOpen);
// //     if (!dropdownOpen && inputRef.current) {
// //       // Focus the input when opening the dropdown
// //       inputRef.current.focus();
// //     }
// //   };

// //   const toggleSkill = (skill) => {
// //     let updatedSkills;
// //     if (selectedSkills.includes(skill)) {
// //       updatedSkills = selectedSkills.filter(s => s !== skill);
// //     } else {
// //       updatedSkills = [...selectedSkills, skill];
// //     }
    
// //     setSelectedSkills(updatedSkills);
// //     setFormData(prev => ({
// //       ...prev,
// //       skills: updatedSkills.join(', ')
// //     }));
    
// //     // Keep focus on input after toggling a skill
// //     if (inputRef.current) {
// //       inputRef.current.focus();
// //     }
// //   };

// //   const addSkillHandler = async (skill) => {
// //     if (!selectedSkills.includes(skill)) {
// //       const updatedSkills = [...selectedSkills, skill];
// //       setSelectedSkills(updatedSkills);
// //       setFormData(prev => ({
// //         ...prev,
// //         skills: updatedSkills.join(', ')
// //       }));
      
// //       if (!availableSkills.includes(skill)) {
// //         await addSkill(skill);
// //       }
// //     }
// //     setSearchTerm('');
    
// //     // Keep focus on input after adding a skill
// //     if (inputRef.current) {
// //       inputRef.current.focus();
// //     }
// //   };

// //   const removeSkill = (skillToRemove) => {
// //     const updatedSkills = selectedSkills.filter(skill => skill !== skillToRemove);
// //     setSelectedSkills(updatedSkills);
// //     setFormData(prev => ({
// //       ...prev,
// //       skills: updatedSkills.join(', ')
// //     }));
    
// //     // Focus back on input after removing a skill
// //     if (inputRef.current) {
// //       inputRef.current.focus();
// //     }
// //   };

// //   const handleSearchChange = (e) => {
// //     setSearchTerm(e.target.value);
// //     if (!dropdownOpen) setDropdownOpen(true);
// //   };

// //   // Add custom skill when pressing Enter if it doesn't exist in available options
// //   const handleKeyDown = (e) => {
// //     if (e.key === 'Enter' && searchTerm.trim() !== '') {
// //       e.preventDefault();
      
// //       // Check if the skill already exists in available options
// //       const matchingSkill = availableSkills.find(
// //         skill => skill.toLowerCase() === searchTerm.toLowerCase()
// //       );
      
// //       if (matchingSkill) {
// //         // Toggle the existing skill with proper casing
// //         toggleSkill(matchingSkill);
// //       } else if (!selectedSkills.includes(searchTerm.trim())) {
// //         // Add as new custom skill
// //         addSkillHandler(searchTerm.trim());
// //       }
      
// //       setSearchTerm('');
// //     } else if (e.key === 'Backspace' && searchTerm === '' && selectedSkills.length > 0) {
// //       // Remove the last skill when pressing backspace with empty search
// //       const lastSkill = selectedSkills[selectedSkills.length - 1];
// //       removeSkill(lastSkill);
// //     }
// //   };

// //   const handleCertChange = (index, field, value) => {
// //     const updatedCerts = [...formData.certifications];
// //     updatedCerts[index][field] = value;
// //     setFormData(prev => ({
// //       ...prev,
// //       certifications: updatedCerts
// //     }));
// //   };

// //   // Certificate dropdown functions
// //   const toggleCertDropdown = (index) => {
// //     setCertDropdownOpen(prev => ({
// //       ...prev,
// //       [index]: !prev[index]
// //     }));
// //   };

// //   const handleCertSearchChange = (index, value) => {
// //     setCertSearchTerms(prev => ({
// //       ...prev,
// //       [index]: value
// //     }));
// //     handleCertChange(index, 'name', value);
// //   };

// //   const selectCertification = (index, certName) => {
// //     handleCertChange(index, 'name', certName);
// //     setCertDropdownOpen(prev => ({ ...prev, [index]: false }));
// //     setCertSearchTerms(prev => ({ ...prev, [index]: '' }));
// //   };

// //   const getFilteredCertifications = (index) => {
// //     const searchTerm = certSearchTerms[index] || formData.certifications[index]?.name || '';
// //     return commonCertifications.filter(cert =>
// //       cert.toLowerCase().includes(searchTerm.toLowerCase())
// //     );
// //   };

// //   const addNewCert = () => {
// //     setFormData(prev => ({
// //       ...prev,
// //       certifications: [
// //         ...prev.certifications,
// //         { 
// //           id: `temp-${Math.random().toString(36).substr(2,9)}`,
// //           name: '', 
// //           status: 'Yet to Start', 
// //           completionDate: '', 
// //           comments: '' 
// //         }
// //       ]
// //     }));
// //   };

// //   const removeCert = async (index) => {
// //     const certToDelete = formData.certifications[index];
// //     if (certToDelete.id && !certToDelete.id.toString().startsWith('')) {
// //       try {
// //         await deleteUserCertification(currentUser.id, certToDelete.id);
// //       } catch (error) {
// //         console.error('Error deleting certification:', error);
// //       }
// //     }
    
// //     const updatedCerts = formData.certifications.filter((_, i) => i !== index);
// //     setFormData(prev => ({
// //       ...prev,
// //       certifications: updatedCerts
// //     }));
    
// //     // Clean up dropdown states
// //     setCertDropdownOpen(prev => {
// //       const newState = { ...prev };
// //       delete newState[index];
// //       return newState;
// //     });
// //     setCertSearchTerms(prev => {
// //       const newState = { ...prev };
// //       delete newState[index];
// //       return newState;
// //     });
// //   };

// //   const handleSave = async () => {
// //     try {
// //       await updateUserSkills(currentUser.id, selectedSkills);

// //       for (let cert of formData.certifications) {
// //         if (cert.name.trim()) {
// //           if (cert.id && !cert.id.toString().startsWith()) {
// //             await updateUserCertification(currentUser.id, cert.id, cert);
// //           } else {
// //             const { id, ...certData } = cert;
// //             await addUserCertification(currentUser.id, certData);
// //           }
// //         }
// //       }

// //       setIsEditing(false);
// //     } catch (error) {
// //       console.error('Error saving skillset:', error);
// //     }
// //   };

// //   const handleCancel = () => {
// //     // Reset to user data
// //     setSelectedSkills(userSkills || []);
// //     setFormData({
// //       skills: userSkills ? userSkills.join(', ') : '',
// //       certifications: userCertifications || []
// //     });
// //     setIsEditing(false);
// //     setSearchTerm('');
// //     setDropdownOpen(false);
// //     setCertDropdownOpen({});
// //     setCertSearchTerms({});
// //   };

// //   // Handler to pass to parent for toggling section
// //   const handleSectionToggle = () => {
// //     // This will be handled by parent component
// //   };

// //   if (loading) {
// //     return (
// //       <Accordion 
// //         title="Skillset" 
// //         isOpen={isSkillsetOpen}
// //         onClick={handleSectionToggle}
// //       >
// //         <div className="form-section">
// //           <div style={{
// //             display: 'flex',
// //             justifyContent: 'center',
// //             alignItems: 'center',
// //             padding: '40px',
// //             fontSize: '16px',
// //             color: '#666'
// //           }}>
// //             Loading skillset...
// //           </div>
// //         </div>
// //       </Accordion>
// //     );
// //   }

// //   return (
// //     <Accordion 
// //       title="Skillset" 
// //       isOpen={isSkillsetOpen}
// //       onClick={handleSectionToggle}
// //     >
// //       <div className="form-section">
// //         <div className="form-group inline-form-group">
// //           <label>Skills</label>
// //           {isEditing ? (
// //             <div className="skills-input-container">
// //               {/* Enhanced multi-select dropdown with checkboxes and inline skills */}
// //               <div className="multi-select-dropdown" ref={dropdownRef}>
// //                 <div 
// //                   className={`dropdown-header ${dropdownOpen ? 'active' : ''}`}
// //                   onClick={toggleDropdown}
// //                 >
// //                   <div className="inline-skills-container">
// //                     {selectedSkills.map(skill => (
// //                       <span key={skill} className="inline-skill-tag">
// //                         {skill}
// //                         <button 
// //                           className="inline-remove-skill-btn"
// //                           onClick={(e) => {
// //                             e.stopPropagation();
// //                             removeSkill(skill);
// //                           }}
// //                           aria-label={`Remove ${skill}`}
// //                         >
// //                           ×
// //                         </button>
// //                       </span>
// //                     ))}
// //                   </div>
// //                 </div>

// //                 <div id='dropdown-input'>
// //                   <input 
// //                     ref={inputRef}
// //                     type="text" 
// //                     placeholder={selectedSkills.length ? "Search to add more skills..." : "Search or add skills..."}
// //                     value={searchTerm}
// //                     onChange={handleSearchChange}
// //                     onClick={(e) => {
// //                       e.stopPropagation();
// //                       setDropdownOpen(true);
// //                     }}
// //                     onKeyDown={handleKeyDown}
// //                     className="inline-skill-search-input"
// //                     aria-label="Search skills"
// //                   />
// //                   <span className={`dropdown-arrow ${dropdownOpen ? 'open' : ''}`}>▼</span>
// //                 </div>
                
// //                 {dropdownOpen && (
// //                   <div className="dropdown-options-container">
// //                     {filteredSkills.length > 0 ? (
// //                       <div className="dropdown-options">
// //                         {filteredSkills.map(skill => (
// //                           <div 
// //                             key={skill} 
// //                             className={`dropdown-option checkbox-option ${selectedSkills.includes(skill) ? 'selected' : ''}`}
// //                             onClick={() => toggleSkill(skill)}
// //                           >
// //                             <div className="skill-checkbox-container">
// //                               <input 
// //                                 type="checkbox" 
// //                                 checked={selectedSkills.includes(skill)}
// //                                 onChange={() => toggleSkill(skill)}
// //                                 className="skill-checkbox"
// //                                 id={`skill-${skill.replace(/\s+/g, '-').toLowerCase()}`}
// //                               />
// //                               <label 
// //                                 htmlFor={`skill-${skill.replace(/\s+/g, '-').toLowerCase()}`}
// //                                 className="skill-checkbox-label"
// //                               >
// //                                 {skill}
// //                               </label>
// //                             </div>
// //                           </div>
// //                         ))}
// //                       </div>
// //                     ) : (
// //                       <div className="dropdown-options">
// //                         <div className="dropdown-option no-results">
// //                           {searchTerm.trim() !== '' ? (
// //                             <>
// //                               No matches found. Press <kbd>Enter</kbd> to add "{searchTerm}" as a new skill.
// //                             </>
// //                           ) : (
// //                             "No more skills available"
// //                           )}
// //                         </div>
// //                       </div>
// //                     )}
                    
// //                     {/* Skills Summary */}
// //                     {selectedSkills.length > 0 && (
// //                       <div className="skills-summary">
// //                         <div className="skills-count">
// //                           {selectedSkills.length} skill{selectedSkills.length !== 1 ? 's' : ''} selected
// //                         </div>
// //                         <button 
// //                           type="button" 
// //                           className="clear-all-skills-btn"
// //                           onClick={() => {
// //                             setSelectedSkills([]);
// //                             setFormData(prev => ({ ...prev, skills: '' }));
// //                           }}
// //                         >
// //                           Clear All
// //                         </button>
// //                       </div>
// //                     )}
// //                   </div>
// //                 )}
// //               </div>
// //             </div>
// //           ) : (
// //             <input
// //               type="text"
// //               value={formData.skills}
// //               readOnly
// //               className="form-input"
// //             />
// //           )}
// //         </div>

// //         <div className="form-group certificates-section">
// //           <label className="cert-section-label">Certifications</label>
// //           <div className="certificates-content">
// //             {isEditing ? (
// //               <div className="certifications-grid">
// //                 <table className="cert-table">
// //                   <thead>
// //                     <tr>
// //                       <th>Name</th>
// //                       <th>Status</th>
// //                       <th>Completion Date</th>
// //                       <th>Comments</th>
// //                       <th>Actions</th>
// //                     </tr>
// //                   </thead>
// //                   <tbody>
// //                     {formData.certifications.map((cert, index) => (
// //                       <tr key={cert.id || index}>
// //                         <td style={{minWidth: '250px'}}>
// //                           <div id={`cert-dropdown-${index}`} className="cert-dropdown-container">
// //                             <div className="cert-input-wrapper">
// //                               <input
// //                                 type="text"
// //                                 placeholder="Enter or search certification name"
// //                                 value={cert.name}
// //                                 onChange={(e) => handleCertSearchChange(index, e.target.value)}
// //                                 onFocus={() => setCertDropdownOpen(prev => ({ ...prev, [index]: true }))}
// //                                 className="form-input cert-name-input"
// //                               />
// //                               <button 
// //                                 type="button" 
// //                                 onClick={() => toggleCertDropdown(index)}
// //                                 className="cert-dropdown-btn"
// //                               >
// //                                 ▼
// //                               </button>
// //                             </div>
                            
// //                             {certDropdownOpen[index] && (
// //                               <div className="cert-dropdown-options">
// //                                 {getFilteredCertifications(index).map((certName, certIndex) => (
// //                                   <div
// //                                     key={certIndex}
// //                                     onClick={() => selectCertification(index, certName)}
// //                                     className="cert-dropdown-option"
// //                                   >
// //                                     {certName}
// //                                   </div>
// //                                 ))}
// //                                 {getFilteredCertifications(index).length === 0 && (
// //                                   <div className="cert-dropdown-option no-results">
// //                                     No matching certifications found
// //                                   </div>
// //                                 )}
// //                               </div>
// //                             )}
// //                           </div>
// //                         </td>
// //                         <td className='inner-content'>
// //                           <select
// //                             value={cert.status}
// //                             onChange={(e) => handleCertChange(index, 'status', e.target.value)}
// //                             className="form-select"
// //                           >
// //                             <option value="Completed">Completed</option>
// //                             <option value="In Progress">In Progress</option>
// //                             <option value="Yet to Start">Yet to Start</option>
// //                           </select>
// //                         </td>
// //                         <td>
// //                           <input
// //                             type="date"
// //                             value={cert.completionDate}
// //                             onChange={(e) => handleCertChange(index, 'completionDate', e.target.value)}
// //                             disabled={cert.status !== 'Completed'}
// //                             className="form-input"
// //                           />
// //                         </td>
// //                         <td>
// //                           <input
// //                             type="text"
// //                             value={cert.comments}
// //                             onChange={(e) => handleCertChange(index, 'comments', e.target.value)}
// //                             className="form-input"
// //                             placeholder="Any comments"
// //                           />
// //                         </td>
// //                         <td>
// //                           <button 
// //                             onClick={() => removeCert(index)}
// //                             className="btn-danger btn-sm"
// //                           >
// //                             Remove
// //                           </button>
// //                         </td>
// //                       </tr>
// //                     ))}
// //                   </tbody>
// //                 </table>
// //                 <div className="add-cert-button-container">
// //                   <button 
// //                     onClick={addNewCert}
// //                     className="btn-secondary btn-sm"
// //                   >
// //                     + Add Certificate
// //                   </button>
// //                 </div>
// //               </div>
// //             ) : (
// //               <div className="certifications-display">
// //                 {formData.certifications.length > 0 ? (
// //                   <table className="cert-table">
// //                     <thead>
// //                       <tr>
// //                         <th>Name</th>
// //                         <th>Status</th>
// //                         <th>Completion Date</th>
// //                         <th>Comments</th>
// //                       </tr>
// //                     </thead>
// //                     <tbody>
// //                       {formData.certifications.map((cert, index) => (
// //                         <tr key={cert.id || index}>
// //                           <td>{cert.name}</td>
// //                           <td>
// //                             <span className={`status-badge ${cert.status.toLowerCase().replace(' ', '-')}`}>
// //                               {cert.status}
// //                             </span>
// //                           </td>
// //                           <td>{cert.completionDate || '-'}</td>
// //                           <td>{cert.comments || '-'}</td>
// //                         </tr>
// //                       ))}
// //                     </tbody>
// //                   </table>
// //                 ) : (
// //                   <p className="no-certs-message">No certifications added yet.</p>
// //                 )}
// //               </div>
// //             )}
// //           </div>
// //         </div>

// //         {isEditing ? (
// //           <div className="form-actions">
// //             <button type="button" className="btn-primary" onClick={handleSave}>
// //               Save Changes
// //             </button>
// //             <button type="button" className="btn-secondary" onClick={handleCancel}>
// //               Cancel
// //             </button>
// //           </div>
// //         ) : (
// //           <div className="form-actions">
// //             <button 
// //               type="button" 
// //               className="btn-primary" 
// //               onClick={() => setIsEditing(true)}
// //             >
// //               Edit 
// //             </button>
// //           </div>
// //         )}
// //       </div>
// //     </Accordion>
// //   );
// // };

// // export default Skillset;