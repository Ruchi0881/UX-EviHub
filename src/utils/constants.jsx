export const API_BASE_URL = import.meta.env.VITE_API_BASE_URL;

export const ROLES = {
  ADMIN: 'admin',
  MANAGER: 'manager',
  EMPLOYEE: 'employee'
};

export const GENDER_OPTIONS = [
  { value: 'male', label: 'Male' },
  { value: 'female', label: 'Female' },
  { value: 'other', label: 'Other' }
];

export const DESIGNATION_OPTIONS = [
  'Software Engineer',
  'Senior Software Engineer',
  'Team Lead',
  'Project Manager',
  'HR Manager',
  'Product Manager',
  'QA Engineer',
  'UI/UX Designer'
];

export const SKILLS = [
  'React',
  'JavaScript',
  'TypeScript',
  'Node.js',
  'Python',
  'Java',
  'C#',
  'HTML/CSS',
  'SQL',
  'AWS',
  'Azure',
  'Docker',
  'Kubernetes'
];

export const CERTIFICATIONS = [
  'AWS Certified',
  'Microsoft Certified',
  'Google Cloud Certified',
  'Scrum Master',
  'PMP',
  'Oracle Certified'
];
