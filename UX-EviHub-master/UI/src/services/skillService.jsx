import axios from 'axios';

const API_BASE_URL = 'http://localhost:7218/api';

  // Get all skills
 export const getAllSkills= async () => {
    try {
      const response = await axios.get(`${API_BASE_URL}/GetAllSkills`);
      return response.data;
    } catch (error) {
      console.error('Error fetching skills:', error);
      throw error;
    }
  }

  // Add a new skill
 export const addSkill= async (skillDto) => {
    try {
      const response = await axios.post(`${API_BASE_URL}`, skillDto);
      return response.data;
    } catch (error) {
      console.error('Error adding skill:', error);
      throw error;
    }
  }

  // Update skill by ID
  export const updateSkill= async (id, skillDto) => {
    try {
      const response = await axios.put(`${API_BASE_URL}/${id}`, skillDto);
      return response.data;
    } catch (error) {
      console.error(`Error updating skill with ID ${id}:`, error);
      throw error;
    }
  }

  // Get skill by ID
  export const getSkillById= async (id) => {
    try {
      const response = await axios.get(`${API_BASE_URL}/skills/${id}`);
      return response.data;
    } catch (error) {
      console.error(`Error fetching skill with ID ${id}:`, error);
      throw error;
    }
  }

  // Delete skill by ID
  export const deleteSkill= async (id) => {
    try {
      const response = await axios.delete(`${API_BASE_URL}/${id}`);
      return response.status === 204;
    } catch (error) {
      console.error(`Error deleting skill with ID ${id}:`, error);
      throw error;
    }
  }

  
