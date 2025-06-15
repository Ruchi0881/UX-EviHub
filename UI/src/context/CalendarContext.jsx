import React, { createContext, useState, useEffect } from 'react';

// Create context
export const CalendarContext = createContext();

export const CalendarProvider = ({ children }) => {
  const [employees, setEmployees] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchEmployees = async () => {
      try {
        // Replace with actual API call
        const response = await fetch('/api/employees');
        
        if (!response.ok) {
          throw new Error('Failed to fetch employee data');
        }
        
        const data = await response.json();
        setEmployees(data);
        setLoading(false);
      } catch (error) {
        console.error('Error fetching employee data:', error);
        setError(error.message);
        setLoading(false);
      }
    };

    fetchEmployees();
  }, []);

  // Filter employees with birthdays in a specific month
  const getBirthdaysInMonth = (month) => {
    return employees.filter(employee => {
      if (!employee.birthDate) return false;
      const birthDate = new Date(employee.birthDate);
      return birthDate.getMonth() === month;
    });
  };

  // Filter employees with birthdays on a specific date
  const getBirthdaysOnDate = (date) => {
    return employees.filter(employee => {
      if (!employee.birthDate) return false;
      const birthDate = new Date(employee.birthDate);
      return (
        birthDate.getDate() === date.getDate() &&
        birthDate.getMonth() === date.getMonth()
      );
    });
  };

  // Calculate age of employee
  const calculateAge = (birthDate) => {
    const today = new Date();
    const birth = new Date(birthDate);
    let age = today.getFullYear() - birth.getFullYear();
    const monthDiff = today.getMonth() - birth.getMonth();
    
    if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < birth.getDate())) {
      age--;
    }
    
    return age;
  };

  return (
    <CalendarContext.Provider
      value={{
        employees,
        loading,
        error,
        getBirthdaysInMonth,
        getBirthdaysOnDate,
        calculateAge
      }}
    >
      {children}
    </CalendarContext.Provider>
  );
};

export default CalendarContext;