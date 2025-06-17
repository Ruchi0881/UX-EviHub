import React, { createContext, useContext, useState } from 'react';
import {
  getAvailableCertifications,
  getUserCertifications,
  addCertificationProgress,
  updateCertificationProgress,
  deleteCertificationProgress
} from '../services/certificateService';

const CertificationContext = createContext();

export const CertificationProvider = ({ children }) => {
  const [availableCerts, setAvailableCerts] = useState([]);
  const [userCerts, setUserCerts] = useState([]);
  const [loading, setLoading] = useState(false);

  const fetchAvailableCertifications = async () => {
    try {
      setLoading(true);
      console.log('Fetching available certifications...');
      const data = await getAvailableCertifications();
      console.log('Available certifications response:', data);
      
      // Handle different response structures
      let certsArray = [];
      if (Array.isArray(data)) {
        // If data is directly an array
        certsArray = data.map(item => 
          typeof item === 'string' ? item : (item.name || item.certificationName || item.title || item.certificateName || '')
        );
      } else if (data && Array.isArray(data.certifications)) {
        // If data has a certifications property
        certsArray = data.certifications.map(item => 
          typeof item === 'string' ? item : (item.name || item.certificationName || item.title || item.certificateName || '')
        );
      } else if (data && data.data && Array.isArray(data.data)) {
        // If data is wrapped in a data property
        certsArray = data.data.map(item => 
          typeof item === 'string' ? item : (item.name || item.certificationName || item.title || item.certificateName || '')
        );
      }
      
      // Filter out empty strings
      certsArray = certsArray.filter(cert => cert && cert.trim() !== '');
      
      console.log('Processed certifications array:', certsArray);
      setAvailableCerts(certsArray);
    } catch (err) {
      console.error('Error fetching certification list:', err);
      console.error('Error details:', err.response?.data || err.message);
      // Set empty array on error to prevent UI issues
      setAvailableCerts([]);
    } finally {
      setLoading(false);
    }
  };

  const fetchUserCertifications = async (empId) => {
    try {
      setLoading(true);
      console.log('Fetching user certifications for empId:', empId);
      const data = await getUserCertifications(empId);
      console.log('User certifications response:', data);
      
      // Handle different response structures
      let userCertsArray = [];
      if (Array.isArray(data)) {
        userCertsArray = data;
      } else if (data && Array.isArray(data.certifications)) {
        userCertsArray = data.certifications;
      } else if (data && data.data && Array.isArray(data.data)) {
        userCertsArray = data.data;
      }
      
      // Ensure each certification has the required structure
      userCertsArray = userCertsArray.map(cert => ({
        id: cert.id || `temp-${Date.now()}-${Math.random()}`,
        name: cert.name || cert.certificationName || cert.title || '',
        status: cert.status || 'Yet to Start',
        completionDate: cert.completionDate || cert.dateCompleted || '',
        comments: cert.comments || cert.notes || ''
      }));
      
      console.log('Processed user certifications:', userCertsArray);
      setUserCerts(userCertsArray);
    } catch (err) {
      console.error('Error fetching user certifications:', err);
      console.error('Error details:', err.response?.data || err.message);
      // Set empty array on error
      setUserCerts([]);
    } finally {
      setLoading(false);
    }
  };

  const saveCertification = async (cert) => {
    try {
      console.log('Saving certification:', cert);
      let response;
      
      if (cert.id?.startsWith('temp-')) {
        // Remove temp ID for new certifications
        const { id, ...certData } = cert;
        response = await addCertificationProgress(certData);
      } else {
        response = await updateCertificationProgress(cert);
      }
      
      console.log('Save certification response:', response);
      return response;
    } catch (err) {
      console.error('Error saving certification:', err);
      console.error('Error details:', err.response?.data || err.message);
      throw err; // Re-throw to let the component handle the error
    }
  };

  const saveUserCerts = async (empId, certifications) => {
    try {
      console.log('Saving user certifications:', { empId, certifications });
      
      // Process each certification
      const savePromises = certifications.map(async (cert) => {
        // Ensure cert has empId
        const certWithEmpId = {
          ...cert,
          empId: empId,
         // In case your API uses different field names
        };
        
        return await saveCertification(certWithEmpId);
      });
      
      const results = await Promise.all(savePromises);
      console.log('All certifications saved:', results);
      
      // Update local state
      setUserCerts(certifications);
      return results;
    } catch (err) {
      console.error('Error saving user certifications:', err);
      throw err;
    }
  };

  const removeCertification = async (id) => {
    try {
      console.log('Deleting certification with id:', id);
      await deleteCertificationProgress(id);
      setUserCerts((prev) => prev.filter((cert) => cert.id !== id));
      console.log('Certification deleted successfully');
    } catch (err) {
      console.error('Error deleting certification:', err);
      console.error('Error details:', err.response?.data || err.message);
      throw err;
    }
  };

  // Alias for backward compatibility
  const fetchAvailableCerts = fetchAvailableCertifications;
  const fetchUserCerts = fetchUserCertifications;

  return (
    <CertificationContext.Provider
      value={{
        availableCerts,
        userCerts,
        loading,
        fetchAvailableCertifications,
        fetchUserCertifications,
        fetchAvailableCerts, // Alias
        fetchUserCerts, // Alias
        saveCertification,
        saveUserCerts, // New method for batch save
        removeCertification
      }}
    >
      {children}
    </CertificationContext.Provider>
  );
};

export const useCertificationContext = () => {
  const context = useContext(CertificationContext);
  if (!context) {
    throw new Error('useCertificationContext must be used within a CertificationProvider');
  }
  return context;
};

// import React, { createContext, useContext, useState } from 'react';
// import {
//   getAvailableCertifications,
//   getUserCertifications,
//   addCertificationProgress,
//   updateCertificationProgress,
//   deleteCertificationProgress
// } from '../services/certificateService';

// const CertificationContext = createContext();

// export const CertificationProvider = ({ children }) => {
//   const [availableCerts, setAvailableCerts] = useState([]);
//   const [userCerts, setUserCerts] = useState([]);
//   const[loading, setLoading]=useState(false);

//   const fetchAvailableCertifications = async () => {
//     setLoading(true);
//     try {
//       const data = await certService.getAvailableCertifications();
//       setAvailableCerts(data);
//     } catch (err) {
//       console.error('Error fetching certification list:', err);
//     } finally{
//         setLoading(false);
//     }
//   };

//   const fetchUserCertifications = async (empId) => {
//     setLoading(true);
//     try {
//       const data = await certService.getUserCertifications(empId);
//       setUserCerts(data);
//     } catch (err) {
//       console.error('Error fetching user certifications:', err);
//     } finally{
//         setLoading(false);
//     }
//   };

//   const saveCertification = async (cert) => {
//     try {
//       if (cert.id?.startsWith('temp-')) {
//         const saved=await certService.addCertificationProgress(cert);
//         setUserCerts(prev=>[...prev.filter(c=>c.id!==cert.id),saved]);
//       } else {
//         await updateCertificationProgress(cert);
//         setUserCerts(prev=>
//             prev.map(c=>(c.id===cert.id?{...c,...cert}:c))
//         );
//       }
//     } catch (err) {
//       console.error('Error saving certification:', err);
//     }
//   };

//   const removeCertification = async (id) => {
//     try {
//       await certService.deleteCertificationProgress(id);
//       setUserCerts((prev) => prev.filter((cert) => cert.id !== id));
//     } catch (err) {
//       console.error('Error deleting certification:', err);
//     }
//   };

//   return (
//     <CertificationContext.Provider
//       value={{
//         availableCerts,
//         userCerts,
//         loading,
//         fetchAvailableCertifications,
//         fetchUserCertifications,
//         saveCertification,
//         removeCertification
//       }}
//     >
//       {children}
//     </CertificationContext.Provider>
//   );
// };

// export const useCertificationContext = () => useContext(CertificationContext);
