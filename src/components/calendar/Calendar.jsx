import React, { useState, useEffect } from 'react';
import { format, addMonths, subMonths, startOfMonth, endOfMonth, eachDayOfInterval, getDay } from 'date-fns';
import BirthdayList from './BirthdayList';
import '../../styles/calendar.css';

const Calendar = () => {
  const [currentMonth, setCurrentMonth] = useState(new Date());
  const [selectedDate, setSelectedDate] = useState(new Date());
  const [employees, setEmployees] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    // Fetch employees data with birthday information
    const fetchEmployees = async () => {
      try {
        // Mock data for demonstration - replace with actual API call
        const response = await fetch('/api/employees');
        const data = await response.json();
        setEmployees(data);
        setLoading(false);
      } catch (error) {
        console.error('Error fetching employee data:', error);
        setLoading(false);
      }
    };

    fetchEmployees();
  }, []);

  const nextMonth = () => {
    setCurrentMonth(addMonths(currentMonth, 1));
  };

  const prevMonth = () => {
    setCurrentMonth(subMonths(currentMonth, 1));
  };

  const renderHeader = () => {
    return (
      <div className="calendar-header">
        <div className="calendar-navigation">
          <button onClick={prevMonth}>&lt;</button>
          <h2>{format(currentMonth, 'MMMM yyyy')}</h2>
          <button onClick={nextMonth}>&gt;</button>
        </div>
      </div>
    );
  };

  const renderDays = () => {
    const days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
    return (
      <div className="days-header">
        {days.map(day => (
          <div className="day-name" key={day}>
            {day}
          </div>
        ))}
      </div>
    );
  };

  const renderCells = () => {
    const monthStart = startOfMonth(currentMonth);
    const monthEnd = endOfMonth(monthStart);
    const startDate = monthStart;
    const endDate = monthEnd;

    const dateFormat = 'd';
    const rows = [];

    const days = eachDayOfInterval({
      start: startDate,
      end: endDate
    });

    // Get birthdays for current month
    const monthBirthdays = employees.filter(employee => {
      const birthDate = new Date(employee.birthDate);
      return birthDate.getMonth() === currentMonth.getMonth();
    });

    let cells = [];
    let day = 1;
    let startingDayIndex = getDay(monthStart);

    // Create empty cells for days before the first day of month
    for (let i = 0; i < startingDayIndex; i++) {
      cells.push(<div key={`empty-${i}`} className="day empty"></div>);
    }

    // Create cells for each day of the month
    days.forEach(date => {
      const dayStr = format(date, dateFormat);
      const dayEmployees = monthBirthdays.filter(emp => {
        const birthDate = new Date(emp.birthDate);
        return birthDate.getDate() === parseInt(dayStr);
      });
      
      const hasBirthday = dayEmployees.length > 0;

      cells.push(
        <div
          key={date.toString()}
          className={`day ${hasBirthday ? 'has-birthday' : ''}`}
          onClick={() => setSelectedDate(date)}
        >
          <span className={format(date, 'MM/dd/yyyy') === format(selectedDate, 'MM/dd/yyyy') ? 'selected' : ''}>
            {dayStr}
          </span>
          {hasBirthday && <div className="birthday-indicator"></div>}
        </div>
      );
      
      // When we reach the end of a row
      if (cells.length === 7) {
        rows.push(
          <div className="row" key={day}> 
            {cells}
          </div>
        );
        cells = [];
      }
      day++;
    });

    // Add remaining cells to the last row
    if (cells.length > 0) {
      while (cells.length < 7) {
        cells.push(<div key={`empty-end-${cells.length}`} className="day empty"></div>);
      }
      rows.push(
        <div className="row" key={day}>
          {cells}
        </div>
      );
    }

    return <div className="calendar-body">{rows}</div>;
  };

  return (
    <div className="calendar-container">
      <h1>Employee Birthdays</h1>
      <div className="calendar">
        {renderHeader()}
        {renderDays()}
        {renderCells()}
      </div>
      <BirthdayList
        employees={employees}
        loading={loading}
        selectedDate={selectedDate}
        currentMonth={currentMonth}
      />
    </div>
  );
};

export default Calendar;