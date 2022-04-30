import React, { Component } from 'react';
import './StylingTodo.css'
export default class AddTodo extends Component {
    constructor(props){
        super(props);
        this.AddTodo = this.AddTodo.bind(this);
        this.state = {
            error: undefined
        }
    }
    AddTodo(e){
        e.preventDefault();
        const option = e.target.elements.todo.value.trim();
        const error = this.props.AddTodo(option);
        this.setState(() => ({ error }));
        e.target.elements.todo.value = "";
    }
  render() {
    return <div>
 {this.state.error && <p className='error'>{this.state.error}</p>}
    <form className='ajoutache' onSubmit={this.AddTodo}>
          <input  type="text" name="todo" placeholder="Ajouter une tache" onFocus={(e) => e.target.placeholder = ""} 
    onBlur={(e) => e.target.placeholder = "Ajouter une tache"}></input>
          <button>Ajouter une tache</button>
          </form>
    </div>;
  }
}