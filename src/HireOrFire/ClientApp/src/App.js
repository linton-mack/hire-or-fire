import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout/Layout';
import { Home } from './components/Home';
import { AllData } from './components/AllData';
import { Counter } from './components/Counter';
import { FiredData } from './components/FiredData';
import { HiredData } from './components/HiredData';

import './custom.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
        <Route path="/counter" component={Counter} />
        <Route path="/all" component={AllData} />
        <Route path="/hired" component={HiredData} />
        <Route path="/fired" component={FiredData} />
      </Layout>
    );
  }
}
