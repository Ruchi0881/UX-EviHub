import { createContext, useContext, useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { loginUser, registerUser } from '../services/authService';

export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const navigate = useNavigate();
  const [user, setUser] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const storedUser = localStorage.getItem('user');
    if (storedUser) {
      setUser(JSON.parse(storedUser));
    }
    setLoading(false);
  }, []);

  const login = async (credentials) => {
    try {
      const userData = await loginUser(credentials);
      setUser(userData);
      localStorage.setItem('user', JSON.stringify(userData));
      navigate('/employee/dashboard'); 
      return { success: true };
    } catch (error) {
      return { success: false, message: error.message };
    }
  };

  const signup = async (userData) => {
    try {
      const response = await registerUser(userData);
      navigate('/login');
      return { success: true, data: response };
    } catch (error) {
      return { success: false, message: error.message };
    }
  };

  const logout = () => {
    setUser(null);
    localStorage.removeItem('user');
    localStorage.removeItem('token');
    navigate('/login');
  };

  return (
    <AuthContext.Provider value={{ user, loading, login, signup, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => useContext(AuthContext);