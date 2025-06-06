import { createContext, useContext, useState, useEffect } from 'react';

const UserContext = createContext();

export const UserProvider = ({ children }) => {
  const [currentUser, setCurrentUser] = useState(null);
  const [loading, setLoading] = useState(true);

  const updateUser = (userData) => {
    setCurrentUser(userData);
    localStorage.setItem('user', JSON.stringify(userData));
  };

  useEffect(() => {
    const storedUser = localStorage.getItem('user');
    if (storedUser) {
      setCurrentUser(JSON.parse(storedUser));
    }
    setLoading(false);
  }, []);

  return (
    <UserContext.Provider value={{ currentUser, loading, updateUser }}>
      {children}
    </UserContext.Provider>
  );
};

export const useUser = () => useContext(UserContext);