/* eslint-disable jsx-a11y/alt-text */
import React, { Component } from 'react'
import TasksTodo from './TasksTodo'
import AddTodo from './AddTodo'
export default class Todo extends Component {
  componentDidMount() {
    try {
      const json = localStorage.getItem('optionstodo');
      const optionstodo = JSON.parse(json);

      if (optionstodo) {
        this.setState(() => ({ optionstodo }));
      }
    } catch (e) {
      // Do nothing at all
    }
  }
  componentDidUpdate(prevProps, prevState) {
    if (prevState.optionstodo.length !== this.state.optionstodo.length) {
      const json = JSON.stringify(this.state.optionstodo);
      localStorage.setItem('optionstodo', json);
    }
  }
//DELETE OPTIONS:
deleteOptionsTodo(){
    this.setState(()=>({ optionstodo: []}));
  
}

  //TAKE THE OPTION TEXT OF THE NEW OPTION ADD:
  AddTodo(todo){
    if(!todo){
        return 'Entrer un texte valide';
    }
    else if(this.state.optionstodo.indexOf(todo) > -1){
        return 'tache existante';
    }
    this.setState((prevState) => {
        return{
            optionstodo: prevState.optionstodo.concat([todo])
        };
    });
}
//DELETE ONE OPTION:
deleteOptionTodo(todoRemove){
    this.setState((prevState) => {
        return{
            optionstodo: prevState.optionstodo.filter(
                (todo)=> {return todoRemove !== todo}
            )
        };
    });
}

  constructor(props){
    super(props);
    this.state = {
            optionstodo : [],
    };
    this.deleteOptionsTodo = this.deleteOptionsTodo.bind(this);
    this.AddTodo = this.AddTodo.bind(this);
    this.deleteOptionTodo = this.deleteOptionTodo.bind(this);
}
  render() {
    return (
        <div>
          <TasksTodo optionstodo = {this.state.optionstodo} deleteOptionsTodo = {this.deleteOptionsTodo} deleteOptionTodo = {this.deleteOptionTodo} />
           <AddTodo AddTodo = {this.AddTodo}/>
    </div>
    )
  }
}
