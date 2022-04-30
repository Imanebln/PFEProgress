import React, { Component } from 'react';
import '../Todo/StylingTodo.css'
export default class AddTesting extends Component {
    constructor(props){
        super(props);
        this.AddTesting = this.AddTesting.bind(this);
        this.state = {
            error: undefined
        }
    }
    AddTesting(e){
        e.preventDefault();
        const option = e.target.elements.testing.value.trim();
        const error = this.props.AddTesting(option);
        this.setState(() => ({ error }));
        e.target.elements.testing.value = "";
    }
  render() {
    return <div>
 {this.state.error && <p className='error'>{this.state.error}</p>}
    <form className='ajoutache' onSubmit={this.AddTesting}>
          <input type="text" name="testing" placeholder="Ajouter une tache" onFocus={(e) => e.target.placeholder = ""} 
    onBlur={(e) => e.target.placeholder = "Ajouter une tache"}></input>
          <button>Ajouter une tache</button>
          </form>
    </div>;
  }
}