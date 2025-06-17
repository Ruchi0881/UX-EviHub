import axios from 'axios';

const API_BASE = 'https://localhost:7218/api';

// Add request interceptor for debugging
axios.interceptors.request.use(
  (config) => {
    console.log('API Request:', {
      method: config.method,
      url: config.url,
      data: config.data,
      headers: config.headers
    });
    return config;
  },
  (error) => {
    console.error('API Request Error:', error);
    return Promise.reject(error);
  }
);

// Add response interceptor for debugging
axios.interceptors.response.use(
  (response) => {
    console.log('API Response:', {
      status: response.status,
      data: response.data,
      url: response.config.url
    });
    return response;
  },
  (error) => {
    console.error('API Response Error:', {
      status: error.response?.status,
      data: error.response?.data,
      message: error.message,
      url: error.config?.url
    });
    return Promise.reject(error);
  }
);

export const getAvailableSkills = async () => {
  try {
    const response = await axios.get(`${API_BASE}/skills`);
    return response.data;
  } catch (error) {
    console.error('Error in getAvailableSkills:', error);
    throw error;
  }
};

export const getUserSkills = async (userId) => {
  try {
    const response = await axios.get(`${API_BASE}/users/${userId}/skills`);
    return response.data;
  } catch (error) {
    console.error('Error in getUserSkills:', error);
    throw error;
  }
};

export const updateUserSkills = async (userId, skills) => {
  try {
    const payload = { skills };
    console.log('Updating user skills with payload:', payload);
    const response = await axios.put(`${API_BASE}/users/${userId}/skills`, payload);
    return response.data;
  } catch (error) {
    console.error('Error in updateUserSkills:', error);
    throw error;
  }
};

// import axios from 'axios';

// const BASE_URL = 'https://localhost:7218/Skills';

// export const getAvailableSkills = async () => {
//   const response = await axios.get(`${BASE_URL}/GetAllSkills`);
//   return response.data;
// };

// export const getUserSkills = async (userId) => {
//   const response = await axios.get(`${BASE_URL}/employee/${userId}`);
//   return response.data;
// };

// export const updateUserSkills = async (userId, skills) => {
//   const skillIds=skills.map(skill=>skill.skillId);
//   await axios.put(`${BASE_URL}/employee`, { 
//     empId: userId,
//     skillIds: skillIds
//    });
// };