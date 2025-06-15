import axios from 'axios';
import { API_BASE_URL } from '../utils/constants';

// Get all employee birthdays
export const getEmployeeBirthdays = async () => {
  try {
    const response = await axios.get(`${API_BASE_URL}/employees/birthdays`, {
      headers: {
        Authorization: `Bearer ${localStorage.getItem('token')}`
      }
    });
    return response.data;
  } catch (error) {
    console.error('Error fetching employee birthdays:', error);
    throw error;
  }
};

// Get birthdays for a specific month
export const getBirthdaysByMonth = async (month) => {
  try {
    const response = await axios.get(`${API_BASE_URL}/employees/birthdays/month/${month}`, {
      headers: {
        Authorization: `Bearer ${localStorage.getItem('token')}`
      }
    });
    return response.data;
  } catch (error) {
    console.error(`Error fetching employee birthdays for month ${month}:`, error);
    throw error;
  }
};

// Get upcoming birthdays (next 30 days)
export const getUpcomingBirthdays = async () => {
  try {
    const response = await axios.get(`${API_BASE_URL}/employees/birthdays/upcoming`, {
      headers: {
        Authorization: `Bearer ${localStorage.getItem('token')}`
      }
    });
    return response.data;
  } catch (error) {
    console.error('Error fetching upcoming employee birthdays:', error);
    throw error;
  }
};