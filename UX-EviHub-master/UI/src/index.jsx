import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import reportWebVitals from './reportWebVitals';
import './styles/main.css';

// Add font awesome for icons
import { library } from '@fortawesome/fontawesome-svg-core';
import { 
  faSearch, 
  faUser, 
  faSignOutAlt, 
  faBriefcase, 
  faTasks, 
  faBirthdayCake, 
  faFileAlt,
  faChevronDown,
  faChevronUp
} from '@fortawesome/free-solid-svg-icons';

library.add(
  faSearch, 
  faUser, 
  faSignOutAlt, 
  faBriefcase, 
  faTasks, 
  faBirthdayCake, 
  faFileAlt,
  faChevronDown,
  faChevronUp
);

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);

reportWebVitals();