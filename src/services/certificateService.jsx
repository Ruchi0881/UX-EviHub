
import axios from 'axios';

const API_BASE = 'https://localhost:7218/api';

// Add request interceptor for debugging
axios.interceptors.request.use(
  (config) => {
    console.log('Certification API Request:', {
      method: config.method,
      url: config.url,
      data: config.data,
      headers: config.headers
    });
    return config;
  },
  (error) => {
    console.error('Certification API Request Error:', error);
    return Promise.reject(error);
  }
);

// Add response interceptor for debugging
axios.interceptors.response.use(
  (response) => {
    console.log('Certification API Response:', {
      status: response.status,
      data: response.data,
      url: response.config.url
    });
    return response;
  },
  (error) => {
    console.error('Certification API Response Error:', {
      status: error.response?.status,
      data: error.response?.data,
      message: error.message,
      url: error.config?.url
    });
    return Promise.reject(error);
  }
);

export const getAvailableCertifications = async () => {
  try {
    const response = await axios.get(`${API_BASE}/certification`);
    return response.data;
  } catch (error) {
    console.error('Error in getAvailableCertifications:', error);
    throw error;
  }
};

export const getUserCertifications = async (empId) => {
  try {
    const response = await axios.get(`${API_BASE}/certificationprogress/employee/${empId}`);
    return response.data;
  } catch (error) {
    console.error('Error in getUserCertifications:', error);
    throw error;
  }
};

export const addCertificationProgress = async (data) => {
  try {
    console.log('Adding certification progress with data:', data);
    const response = await axios.post(`${API_BASE}/certificationprogress`, data);
    return response.data;
  } catch (error) {
    console.error('Error in addCertificationProgress:', error);
    throw error;
  }
};

export const updateCertificationProgress = async (data) => {
  try {
    console.log('Updating certification progress with data:', data);
    const response = await axios.put(`${API_BASE}/certificationprogress`, data);
    return response.data;
  } catch (error) {
    console.error('Error in updateCertificationProgress:', error);
    throw error;
  }
};

export const deleteCertificationProgress = async (id) => {
  try {
    console.log('Deleting certification progress with id:', id);
    const response = await axios.delete(`${API_BASE}/certificationprogress/${id}`);
    return response.data;
  } catch (error) {
    console.error('Error in deleteCertificationProgress:', error);
    throw error;
  }
};

// import axios from 'axios';

// const API_BASE = 'https://localhost:7218/api';

// export const getAvailableCertifications = async () => {
//   const response = await axios.get(`${API_BASE}/certification`);
//   return response.data;
// };

// export const getUserCertifications = async (empId) => {
//   const response = await axios.get(`${API_BASE}/certificationprogress/employee/${empId}`);
//   return response.data;
// };

// export const addCertificationProgress = async (data) => {
//   const response = await axios.post(`${API_BASE}/certificationprogress`, data);
//   return response.data;
// };

// export const updateCertificationProgress = async (data) => {
//   const response = await axios.put(`${API_BASE}/certificationprogress`, data);
//   return response.data;
// };

// export const deleteCertificationProgress = async (id) => {
//   const response = await axios.delete(`${API_BASE}/certificationprogress/${id}`);
//   return response.data;
// };
