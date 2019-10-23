import React, { Component } from 'react';

export class HiredData extends Component {
  static displayName = HiredData.name;

  constructor(props) {
    super(props);
    this.state = { applicants: [], loading: true };
  }

  componentDidMount() {
    this.populateApplicantsData();
  }

  static renderApplicantsTable(applicants) {
    return (
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Hired</th>
          </tr>
        </thead>
        <tbody>
          {applicants.map(applicant => (
            <tr key={applicant.id}>
              <td>{applicant.id}</td>
              <td>{applicant.name}</td>
              <td>{applicant.hired.toString()}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }
  
  render() {
    const hired = this.state.applicants.filter(applicant => applicant.hired === true)
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      HiredData.renderApplicantsTable(hired)
    );

    return (
      <div>
        <h1 id="tabelLabel">All of the Applicants</h1>
        <p>I wonder who you will hire?</p>
        {contents}
      </div>
    );
  }

  async populateApplicantsData() {
    const response = await fetch('applicants/all');
    const data = await response.json();
    this.setState({ applicants: data, loading: false });
    console.log(this.state)
  }
}
