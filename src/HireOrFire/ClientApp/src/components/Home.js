import React, { Component } from 'react';

export class Home extends Component {
  state = {
    Applicants: [{}]
  }
  // static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hire or Fire</h1>
          <p>I am the home page </p>
      </div>
    );
  }
}
