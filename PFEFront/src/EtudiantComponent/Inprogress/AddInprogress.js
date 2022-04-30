import React, { Component } from 'react';
import '../Todo/StylingTodo.css'
export default class AddInprogress extends Component {
    constructor(props){
        super(props);
        this.AddInprogress = this.AddInprogress.bind(this);
        this.state = {
            error: undefined
        }
    }
    AddInprogress(e){
        e.preventDefault();
        const option = e.target.elements.inprogress.value.trim();
        const error = this.props.AddInprogress(option);
        this.setState(() => ({ error }));
        e.target.elements.inprogress.value = "";
    }
  render() {
    return <div>
 {this.state.error && <p className='error'>{this.state.error}</p>}
    <form className='ajoutache' onSubmit={this.AddInprogress}>
          <input  type="text" name="inprogress" placeholder="Ajouter une tache" onFocus={(e) => e.target.placeholder = ""} 
    onBlur={(e) => e.target.placeholder = "Ajouter une tache"}></input>
          <button>Ajouter une tache</button>
          </form>
    </div>;
  }
}