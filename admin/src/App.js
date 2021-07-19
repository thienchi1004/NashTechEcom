import React from 'react';
import './App.css';
import Navbar from './components/Navbar';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import Products from './pages/Products';
import Categories from './pages/Categories';
import Users from './pages/Users';

function App() {
  return (
    <>
      <Router>
        <Navbar />
        <Switch>
          <Route path='/products' exact component={Products} />
          <Route path='/categories' component={Categories} />
          <Route path='/users' component={Users} />
        </Switch>
      </Router>
    </>
  );
}

export default App;