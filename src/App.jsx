
// App.jsx

// import React from 'react';
// import { Routes, Route } from 'react-router-dom';
// import { AuthProvider } from './context/AuthContext';
// import ProtectedRoute from './components/common/ProtectedRoute';
// import Login from './components/auth/Login';
// import SignUp from './components/auth/Signup';
// import ForgotPassword from './components/auth/ForgotPassword';
// import Unauthorized from './components/common/Unauthorized';
// import Calendar from './components/calendar/Calendar';
// import Proposals from './components/proposals/Proposals';
// import EmployeeDashboard from './components/employee/Dashboard';
// import EmployeeLayout from './components/employee/EmployeeLayout'; // NEW layout wrapper
// import './styles/main.css';

// function App() {
//   return (
//     <AuthProvider>
//       <Routes>
//         {/* Public Routes */}
//         <Route path="/login" element={<Login />} />
//         <Route path="/signup" element={<SignUp />} />
//         <Route path="/forgot-password" element={<ForgotPassword />} />
//         <Route path="/unauthorized" element={<Unauthorized />} />
//         <Route path="/test-employee" element={<EmployeeDashboard />} />

//         {/* Employee Routes with layout */}
//         <Route
//           path="/employee"
//           element={
//             <ProtectedRoute allowedRoles={['employee']}>
//               <EmployeeLayout />
//             </ProtectedRoute>
//           }
//         >
//           <Route path="dashboard" element={<EmployeeDashboard />} />
//           <Route path="calendar" element={<Calendar />} />
//           <Route path="proposals" element={<Proposals />} />
//         </Route>

//         {/* Manager Routes */}
//         <Route
//           path="/manager/*"
//           element={
//             <ProtectedRoute allowedRoles={['manager']}>
//               <div>Manager Dashboard</div>
//             </ProtectedRoute>
//           }
//         />

//         {/* Admin Routes */}
//         <Route
//           path="/admin/*"
//           element={
//             <ProtectedRoute allowedRoles={['admin']}>
//               <div>Admin Dashboard</div>
//             </ProtectedRoute>
//           }
//         />

//         {/* Default fallback */}
//         <Route path="*" element={<Login />} />
//       </Routes>
//     </AuthProvider>
//   );
// }

// export default App;


import React from 'react';
import { Routes, Route } from 'react-router-dom';
import { AuthProvider } from './context/AuthContext';
import ProtectedRoute from './components/common/ProtectedRoute';
import Login from './components/auth/Login';
import SignUp from './components/auth/Signup';
import ForgotPassword from './components/auth/ForgotPassword';
import EmployeeDashboard from './components/employee/Dashboard';
import Unauthorized from './components/common/Unauthorized';
import './styles/main.css';
import Calendar from './components/calendar/Calendar';
import Proposals from './components/proposals/Proposals';

function App() {
  return (
    <AuthProvider>
      <Routes>
        {/* Public Routes */}
        <Route path="/login" element={<Login />} />
        <Route path="/signup" element={<SignUp />} />
        <Route path="/forgot-password" element={<ForgotPassword />} />
        <Route path="/unauthorized" element={<Unauthorized />} />
        <Route path="/test-employee" element={<EmployeeDashboard />} />
        {/* <Route path="/calendar" element={<Calendar/>}/> */}
        {/* <Route path="/proposals" element={<Proposals/>}/>  */}
        {/* Employee Routes*/}
        <Route
          path="/employee/dashboard"
          element={
            <ProtectedRoute allowedRoles={['employee']}>
              <EmployeeDashboard />
            </ProtectedRoute>
          }
        />

        {/* Manager Routes */}
        <Route
          path="/manager/*"
          element={
            <ProtectedRoute allowedRoles={['manager']}>
              <div>Manager Dashboard</div>
            </ProtectedRoute>
          }
        />

        {/* Admin Routes */}
        <Route
          path="/admin/*"
          element={
            <ProtectedRoute allowedRoles={['admin']}>
              <div>Admin Dashboard</div>
            </ProtectedRoute>
          }
        />

        {/* Default Redirect */}
        <Route path="*" element={<Login />} />
      </Routes>
    </AuthProvider>
  );
}

export default App;