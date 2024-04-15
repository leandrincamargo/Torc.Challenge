import React from 'react';
import { Route, Routes, BrowserRouter } from 'react-router-dom';
import Home from './pages/Home/index';

const WebsiteRoutes = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route Component={Home} path="/" />
      </Routes>
    </BrowserRouter>
  );
};

export default WebsiteRoutes;
