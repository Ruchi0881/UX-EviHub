

import api from './api';

 // services/authService.js

export const loginUser = async (credentials) => {
try {
const response = await api.post('https://localhost:7218/api/Auth/login', {
email: credentials.Email, // <-- HERE map Email to email for backend
password: credentials.password
});
return response.data;
} catch (error) {
throw new Error(error.response?.data?.message || 'Login failed');
}
};


export const registerUser = async (userData) => {
try {
const response = await api.post('https://localhost:7218/api/Auth/signup', userData);
return response.data;
} catch (error) {
throw new Error(error.response?.data?.message || 'Registration failed');
}
};

export const forgotPassword = async (email) => {
try {
const response = await api.post('/auth/forgot-password', { email });
return response.data;
} catch (error) {
throw new Error(error.response?.data?.message || 'Password reset failed');
}
};

export const logoutUser = async () => {
try {
await api.post('/auth/logout');
} catch (error) {
console.error('Logout error:', error);
}
};
