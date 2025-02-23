import { Component } from "react";

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      employees: []  // Stores list of strings
    };
  }

  API_URL = "https://localhost:7244";  // Change this if your API runs on a different port

  componentDidMount() {
    this.fetchEmployees();
  }

  async fetchEmployees() {
    fetch(this.API_URL + "/api/employee")  // Ensure this matches your C# endpoint
      .then(response => {
        if (!response.ok) throw new Error("Network response was not OK");
        return response.json();
      })
      .then(data => {
        console.log("API Response:", data);  // Debugging step
        this.setState({ employees: data });
      })
      .catch(error => console.error("Fetch error:", error));
  }

  render() {
    const { employees } = this.state;

    return (
      <div>
        <h2>Employee List234234243234</h2>

        {employees.length > 0 ? (
          employees.map((employee, index) => (
            <p key={index}>
              <b>* {employee}</b>
            </p>
          ))
        ) : (
          <p>Loading...</p>
        )}
      </div>
    );
  }
}

export default App;
