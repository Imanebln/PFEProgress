import React, { Component } from 'react';
import '../Todo/StylingTodo.css'
export default class AddDone extends Component {
    constructor(props){
        super(props);
        this.AddDone = this.AddDone.bind(this);
        this.state = {
            error: undefined
        }
    }
    AddDone(e){
        e.preventDefault();
        const option = e.target.elements.done.value.trim();
        const error = this.props.AddDone(option);
        this.setState(() => ({ error }));
        e.target.elements.done.value = "";
    }
  render() {
    return <div>
 {this.state.error && <p className='error'>{this.state.error}</p>}
    <form className='ajoutache' onSubmit={this.AddDone}>
          <input type="text" name="done" placeholder="Ajouter une tache" onFocus={(e) => e.target.placeholder = ""} 
    onBlur={(e) => e.target.placeholder = "Ajouter une tache"}></input>
          <button>Ajouter une tache</button>
          </form>
    </div>;
  }
}