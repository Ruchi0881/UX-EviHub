import { useSkillContext } from '../context/skillContext';

export const useSkills = () => {
  const {
    skills,
    userSkills,
    loading,
    fetchAvailableSkills,
    fetchUserSkills,
    saveUserSkills
  } = useSkillContext();

  return {
    skills,
    userSkills,
    loading,
    fetchAvailableSkills,
    fetchUserSkills,
    saveUserSkills
  };
};


// import { useState, useEffect, useContext } from 'react';
// import { SkillContext } from '../context/SkillContext';
// import { skillService, certificationService } from '../services/skillService';

// export const useSkills = () => {
//   const context = useContext(SkillContext);
  
//   if (!context) {
//     // Fallback if context is not available
//     const [skills, setSkills] = useState([]);
//     const [userSkills, setUserSkills] = useState([]);
//     const [loading, setLoading] = useState(false);
//     const [error, setError] = useState(null);

//     const getCurrentUser = () => {
//       return JSON.parse(localStorage.getItem('user') || '{}');
//     };

//     const fetchAllSkills = async () => {
//       setLoading(true);
//       try {
//         const data = await skillService.getAllSkills();
//         setSkills(data);
//         setError(null);
//       } catch (err) {
//         setError(err.message);
//         console.error('Error fetching skills:', err);
//       } finally {
//         setLoading(false);
//       }
//     };

//     const fetchUserSkills = async (userId) => {
//       setLoading(true);
//       try {
//         const data = await skillService.getUserSkills(userId);
//         setUserSkills(data.skills || []);
//         setError(null);
//       } catch (err) {
//         setError(err.message);
//         console.error('Error fetching user skills:', err);
//       } finally {
//         setLoading(false);
//       }
//     };

//     const updateUserSkills = async (userId, skillsList) => {
//       setLoading(true);
//       try {
//         const updatedData = await skillService.updateUserSkills(userId, skillsList);
//         setUserSkills(skillsList);
//         setError(null);
//         return updatedData;
//       } catch (err) {
//         setError(err.message);
//         console.error('Error updating user skills:', err);
//         throw err;
//       } finally {
//         setLoading(false);
//       }
//     };

//     const addSkill = async (skillName) => {
//       setLoading(true);
//       try {
//         const newSkill = await skillService.addSkill(skillName);
//         setSkills(prev => [...prev, skillName]);
//         setError(null);
//         return newSkill;
//       } catch (err) {
//         setError(err.message);
//         console.error('Error adding skill:', err);
//         throw err;
//       } finally {
//         setLoading(false);
//       }
//     };

//     useEffect(() => {
//       const currentUser = getCurrentUser();
//       if (currentUser.id) {
//         fetchAllSkills();
//         fetchUserSkills(currentUser.id);
//       }
//     }, []);

//     return {
//       skills,
//       userSkills,
//       loading,
//       error,
//       fetchAllSkills,
//       fetchUserSkills,
//       updateUserSkills,
//       addSkill,
//       getCurrentUser
//     };
//   }
  
//   return context;
// };

// export const useCertifications = () => {
//   const context = useContext(SkillContext);
  
//   if (!context) {
//     // Fallback if context is not available
//     const [certifications, setCertifications] = useState([]);
//     const [userCertifications, setUserCertifications] = useState([]);
//     const [loading, setLoading] = useState(false);
//     const [error, setError] = useState(null);

//     const getCurrentUser = () => {
//       return JSON.parse(localStorage.getItem('user') || '{}');
//     };

//     const fetchAllCertifications = async () => {
//       setLoading(true);
//       try {
//         const data = await certificationService.getAllCertifications();
//         setCertifications(data);
//         setError(null);
//       } catch (err) {
//         setError(err.message);
//         console.error('Error fetching certifications:', err);
//       } finally {
//         setLoading(false);
//       }
//     };

//     const fetchUserCertifications = async (userId) => {
//       setLoading(true);
//       try {
//         const data = await certificationService.getUserCertifications(userId);
//         setUserCertifications(data);
//         setError(null);
//       } catch (err) {
//         setError(err.message);
//         console.error('Error fetching user certifications:', err);
//       } finally {
//         setLoading(false);
//       }
//     };

//     const addUserCertification = async (userId, certificationData) => {
//       setLoading(true);
//       try {
//         const newCertification = await certificationService.addUserCertification(userId, certificationData);
//         setUserCertifications(prev => [...prev, newCertification]);
//         setError(null);
//         return newCertification;
//       } catch (err) {
//         setError(err.message);
//         console.error('Error adding user certification:', err);
//         throw err;
//       } finally {
//         setLoading(false);
//       }
//     };

//     const updateUserCertification = async (userId, certificationId, certificationData) => {
//       setLoading(true);
//       try {
//         const updatedCertification = await certificationService.updateUserCertification(
//           userId, 
//           certificationId, 
//           certificationData
//         );
//         setUserCertifications(prev => 
//           prev.map(cert => cert.id === certificationId ? updatedCertification : cert)
//         );
//         setError(null);
//         return updatedCertification;
//       } catch (err) {
//         setError(err.message);
//         console.error('Error updating user certification:', err);
//         throw err;
//       } finally {
//         setLoading(false);
//       }
//     };

//     const deleteUserCertification = async (userId, certificationId) => {
//       setLoading(true);
//       try {
//         await certificationService.deleteUserCertification(userId, certificationId);
//         setUserCertifications(prev => prev.filter(cert => cert.id !== certificationId));
//         setError(null);
//       } catch (err) {
//         setError(err.message);
//         console.error('Error deleting user certification:', err);
//         throw err;
//       } finally {
//         setLoading(false);
//       }
//     };

//     const updateCertificationStatus = async (userId, certificationId, status) => {
//       setLoading(true);
//       try {
//         const updatedCertification = await certificationService.updateCertificationStatus(
//           userId, 
//           certificationId, 
//           status
//         );
//         setUserCertifications(prev => 
//           prev.map(cert => 
//             cert.id === certificationId 
//               ? { ...cert, status, updatedAt: updatedCertification.updatedAt }
//               : cert
//           )
//         );
//         setError(null);
//         return updatedCertification;
//       } catch (err) {
//         setError(err.message);
//         console.error('Error updating certification status:', err);
//         throw err;
//       } finally {
//         setLoading(false);
//       }
//     };

//     useEffect(() => {
//       const currentUser = getCurrentUser();
//       if (currentUser.id) {
//         fetchAllCertifications();
//         fetchUserCertifications(currentUser.id);
//       }
//     }, []);

//     return {
//       certifications,
//       userCertifications,
//       loading,
//       error,
//       fetchAllCertifications,
//       fetchUserCertifications,
//       addUserCertification,
//       updateUserCertification,
//       deleteUserCertification,
//       updateCertificationStatus,
//       getCurrentUser
//     };
//   }
  
//   return {
//     certifications: context.certifications,
//     userCertifications: context.userCertifications,
//     loading: context.loading,
//     error: context.error,
//     fetchAllCertifications: context.fetchAllCertifications,
//     fetchUserCertifications: context.fetchUserCertifications,
//     addUserCertification: context.addUserCertification,
//     updateUserCertification: context.updateUserCertification,
//     deleteUserCertification: context.deleteUserCertification,
//     updateCertificationStatus: context.updateCertificationStatus,
//     getCurrentUser: context.getCurrentUser
//   };
// };