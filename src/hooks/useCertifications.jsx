import { useCertificationContext } from '../context/certificationContext';

export const useCertifications = () => {
  const {
    availableCerts,
    userCerts,
    loading,
    fetchAvailableCertifications,
    fetchUserCertifications,
    fetchAvailableCerts,
    fetchUserCerts,
    saveUserCerts,
    saveCertification,
    removeCertification
  } = useCertificationContext();

  return {
    availableCerts,
    userCerts,
    loading,
    fetchAvailableCertifications,
    fetchUserCertifications,
    fetchAvailableCerts,
    fetchUserCerts,
    saveUserCerts,
    saveCertification,
    removeCertification
  };
};