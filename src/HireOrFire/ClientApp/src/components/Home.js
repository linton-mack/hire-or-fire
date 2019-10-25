import React, {Component} from 'react';

export class Home extends Component {
    state = {applicants: [], loading: true, applicant: null};

    componentDidMount() {
        this.populateApplicantsData();
    }

    async populateHiredList() {
        let hiredApplicant = {
            id: this.state.applicant.id,
            name: this.state.applicant.name,
            hired: true,
            skip: this.state.applicant.skip
        };

        const response = await fetch('applicants/hired', {
            method: 'POST', // *GET, POST, PUT, DELETE, etc.
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(hiredApplicant) // body data type must match "Content-Type" header
        });
        return response; // parses JSON response into native JavaScript objects
    }

    hiredButton = () => {
        this.setState(prevState => ({
            applicant: (prevState.applicant.hired = true)
        }));

        this.populateHiredList();

        this.setAgain();
        // console.log(this.state);
    };

    setAgain = () => {
        this.setState(prevState => ({
            applicant: prevState.applicants.find(
                applicant => applicant.hired === false && applicant.skip === false
            )
        }));
    };

    renderApplicantsTable = applicant => {
        console.log(this.state);
        if (applicant === undefined) {
            return <p>No applicants here fool!</p>;
        } else {
            return (
                <div>
                    <table className="table table-striped" aria-labelledby="tabelLabel">
                        <thead>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Hired</th>
                        </tr>
                        </thead>
                        <tbody>
                        <tr key={applicant.id}>
                            <td>{applicant.id}</td>
                            <td>{applicant.name}</td>
                            <td>{applicant.hired.toString()}</td>
                        </tr>
                        </tbody>
                    </table>
                    <button onClick={() => this.hiredButton()}>Hire this bad boy</button>
                    <button onClick={this.handleclick}>Skip on this fool</button>
                </div>
            );
        }
    };

    render() {
        const applicant = this.state.applicants.find(
            applicant => applicant.hired === false && applicant.skip === false
        );
        let contents = this.state.loading ? (
            <p>
                <em>Loading...</em>
            </p>
        ) : (
            this.renderApplicantsTable(applicant)
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
        const myman = data.find(
            applicant => applicant.hired === false && applicant.skip === false
        );
        this.setState({applicants: data, loading: false, applicant: myman});
        // console.log(this.state);
    }
}
