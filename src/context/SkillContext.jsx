// context/skillContext.jsx
import React, { createContext, useContext, useState, useEffect } from 'react';
import {
  getAvailableSkills,
  getUserSkills,
  updateUserSkills
} from '../services/skillService';

const SkillContext = createContext();

export const SkillProvider = ({ children }) => {
  const [skills, setSkills] = useState([]);
  const [userSkills, setUserSkills] = useState('');
  const [loading, setLoading] = useState(false);

  const fetchAvailableSkills = async () => {
    try {
      setLoading(true);
      console.log('Fetching available skills...');
      const data = await getAvailableSkills();
      console.log('Available skills response:', data);
      
      // Handle different response structures
      let skillsArray = [];
      if (Array.isArray(data)) {
        // If data is directly an array
        skillsArray = data.map(item => 
          typeof item === 'string' ? item : (item.name || item.skillName || item.title || '')
        );
      } else if (data && Array.isArray(data.skills)) {
        // If data has a skills property
        skillsArray = data.skills.map(item => 
          typeof item === 'string' ? item : (item.name || item.skillName || item.title || '')
        );
      } else if (data && data.data && Array.isArray(data.data)) {
        // If data is wrapped in a data property
        skillsArray = data.data.map(item => 
          typeof item === 'string' ? item : (item.name || item.skillName || item.title || '')
        );
      }
      
      // Filter out empty strings
      skillsArray = skillsArray.filter(skill => skill && skill.trim() !== '');
      
      console.log('Processed skills array:', skillsArray);
      setSkills(skillsArray);
    } catch (err) {
      console.error('Error fetching skills:', err);
      console.error('Error details:', err.response?.data || err.message);
      // Set empty array on error to prevent UI issues
      setSkills([]);
    } finally {
      setLoading(false);
    }
  };

  const fetchUserSkills = async (userId) => {
    try {
      setLoading(true);
      console.log('Fetching user skills for userId:', userId);
      const data = await getUserSkills(userId);
      console.log('User skills response:', data);
      
      // Handle different response structures
      let userSkillsString = '';
      if (typeof data === 'string') {
        userSkillsString = data;
      } else if (data && typeof data.skills === 'string') {
        userSkillsString = data.skills;
      } else if (data && Array.isArray(data.skills)) {
        userSkillsString = data.skills.join(', ');
      } else if (Array.isArray(data)) {
        userSkillsString = data.join(', ');
      }
      
      console.log('Processed user skills:', userSkillsString);
      setUserSkills(userSkillsString);
    } catch (err) {
      console.error('Error fetching user skills:', err);
      console.error('Error details:', err.response?.data || err.message);
      // Set empty string on error
      setUserSkills('');
    } finally {
      setLoading(false);
    }
  };

  const saveUserSkills = async (userId, updatedSkills) => {
    try {
      console.log('Saving user skills:', { userId, updatedSkills });
      const response = await updateUserSkills(userId, updatedSkills);
      console.log('Save skills response:', response);
      setUserSkills(updatedSkills);
      return response;
    } catch (err) {
      console.error('Error updating user skills:', err);
      console.error('Error details:', err.response?.data || err.message);
      throw err; // Re-throw to let the component handle the error
    }
  };

  return (
    <SkillContext.Provider
      value={{
        skills,
        userSkills,
        loading,
        fetchAvailableSkills,
        fetchUserSkills,
        saveUserSkills,
      }}
    >
      {children}
    </SkillContext.Provider>
  );
};

export const useSkillContext = () => {
  const context = useContext(SkillContext);
  if (!context) {
    throw new Error('useSkillContext must be used within a SkillProvider');
  }
  return context;
};

// import React, { createContext, useContext, useState, useEffect } from 'react';
// import {
//   getAvailableSkills,
//   getUserSkills,
//   updateUserSkills
// } from '../services/skillService';

// const SkillContext = createContext();

// export const SkillProvider = ({ children }) => {
//   const [skills, setSkills] = useState([]);
//   const [userSkills, setUserSkills] = useState('');
//   const [loading, setLoading] = useState(false);

//   const fetchAvailableSkills = async () => {
//     setLoading(true);
//     try {
//       const data = await skillService.getAvailableSkills();
//       setSkills(data);
//     } catch (err) {
//       console.error('Error fetching skills:', err);
//     } finally {
//       setLoading(false);
//     }
//   };

//   const fetchUserSkills = async (userId) => {
//     setLoading(true);
//     try {
//       const data = await skillService.getUserSkills(userId);
//       setUserSkills(data);
//     } catch (err) {
//       console.error('Error fetching user skills:', err);
//     } finally {
//       setLoading(false);
//     }
//   };

//   const saveUserSkills = async (userId, updatedSkills) => {
//     try {
//       await skillService.updateUserSkills(userId, updatedSkills);
//       setUserSkills(updatedSkills);
//     } catch (err) {
//       console.error('Error updating user skills:', err);
//     }
//   };

//   // useEffect(()=>{
//   //   getUserSkills();
//   // },[]);

//   return (
//     <SkillContext.Provider
//       value={{
//         skills,
//         userSkills,
//         loading,
//         fetchAvailableSkills,
//         fetchUserSkills,
//         saveUserSkills,
//       }}
//     >
//       {children}
//     </SkillContext.Provider>
//   );
// };

// export const useSkillContext = () => useContext(SkillContext);