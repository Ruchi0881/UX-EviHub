import React from 'react';
import { format, isSameDay, isSameMonth } from 'date-fns';
import '../../styles/calendar.css';

const BirthdayList = ({ employees, loading, selectedDate, currentMonth }) => {
  // Filter employees based on selected date or current month
  const filteredEmployees = employees.filter(employee => {
    const birthDate = new Date(employee.birthDate);
    // If a specific date is selected, show only that day's birthdays
    if (isSameDay(selectedDate, new Date())) {
      return (
        birthDate.getDate() === selectedDate.getDate() &&
        birthDate.getMonth() === selectedDate.getMonth()
      );
    }
    // Otherwise show all birthdays in the current month
    return birthDate.getMonth() === currentMonth.getMonth();
  });

  // Sort employees by their birthday date
  const sortedEmployees = [...filteredEmployees].sort((a, b) => {
    const dateA = new Date(a.birthDate);
    const dateB = new Date(b.birthDate);
    return dateA.getDate() - dateB.getDate();
  });

  if (loading) {
    return <div className="birthday-list-loading">Loading employee data...</div>;
  }

  return (
    <div className="birthday-list-container">
      <h2>
        {isSameDay(selectedDate, new Date())
          ? "Today's Birthdays"
          : `Birthdays in ${format(currentMonth, 'MMMM')}`}
      </h2>
      {sortedEmployees.length > 0 ? (
        <ul className="birthday-list">
          {sortedEmployees.map(employee => {
            const birthDate = new Date(employee.birthDate);
            const fullYear = birthDate.getFullYear();
            const age = new Date().getFullYear() - fullYear;
            
            return (
              <li key={employee.id} className="birthday-item">
                <div className="birthday-avatar">
                  {employee.avatar ? (
                    <img src={employee.avatar} alt={`${employee.name}'s avatar`} />
                  ) : (
                    <div className="avatar-placeholder">
                      {employee.name.charAt(0)}
                    </div>
                  )}
                </div>
                <div className="birthday-details">
                  <h3>{employee.name}</h3>
                  <p className="birthday-date">
                    {format(birthDate, 'MMMM d')} ({age} years)
                  </p>
                  <p className="birthday-department">{employee.department}</p>
                </div>
              </li>
            );
          })}
        </ul>
      ) : (
        <p className="no-birthdays">No birthdays found for this period</p>
      )}
    </div>
  );
};

export default BirthdayList;