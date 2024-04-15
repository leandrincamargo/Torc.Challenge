import React from 'react';
import { Backdrop, CircularProgress } from '@mui/material';

interface LoadingProps {
  loading: boolean;
}
const LoadingOverlay: React.FC<LoadingProps> = ({ loading }) => {
  return (
    <Backdrop style={{ color: '#fff', zIndex: 1200 }} open={loading}>
      <CircularProgress color="inherit" />
    </Backdrop>
  );
};

export default LoadingOverlay;
