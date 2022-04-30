/* eslint-disable jsx-a11y/alt-text */
import React, { Component } from 'react'
import TasksDone from './TasksDone'
import AddDone from './AddDone'
export default class Done extends Component {
  componentDidMount() {
    try {
      const json = localStorage.getItem('optionsdone');
      const optionsdone = JSON.parse(json);

      if (optionsdone) {
        this.setState(() => ({ optionsdone }));
      }
    } catch (e) {
      // Do nothing at all
    }
  }
  componentDidUpdate(prevProps, prevState) {
    if (prevState.optionsdone.length !== this.state.optionsdone.length) {
      const json = JSON.stringify(this.state.optionsdone);
      localStorage.setItem('optionsdone', json);
    }
  }
//DELETE OPTIONS:
deleteOptionsDone(){
    this.setState(()=>({ optionsdone: []}));
  
}
  //TAKE THE OPTION TEXT OF THE NEW OPTION ADD:
  AddDone(done){
    if(!done){
        return 'Entrer un texte valide';
    }
    else if(this.state.optionsdone.indexOf(done) > -1){
        return 'tache existante';
    }
    this.setState((prevState) => {
        return{
            optionsdone : prevState.optionsdone.concat([done])
        };
    });
}
//DELETE ONE OPTION:
deleteOptionDone(doneRemove){
    this.setState((prevState) => {
        return{
            optionsdone : prevState.optionsdone.filter(
                (done)=> {return doneRemove !== done}
            )
        };
    });
}

  constructor(props){
    super(props);
    this.state = {
            optionsdone : [],
    };
    this.deleteOptionsDone = this.deleteOptionsDone.bind(this);
    this.AddDone = this.AddDone.bind(this);
    this.deleteOptionDone = this.deleteOptionDone.bind(this);
}
  render() {
    return (
        <div>
          <TasksDone optionsdone = {this.state.optionsdone} deleteOptionsDone = {this.deleteOptionsDone} deleteOptionDone = {this.deleteOptionDone}/>
           <AddDone AddDone = {this.AddDone}/>
   
       

      {/* <div className='mylists'>
          <div className='todo'>
          <h5>To Do</h5>
          <div className='taches'>
            les taches a réaliser...
          </div>
          <div className='taches'>
            les taches a réaliser...
          </div>
          <form className='ajoutache' onSubmit={this.ajoutTache}>
          <input placeholder='ajouter tache '></input>
          <button>Ajouter tache</button>
          </form>
          </div>
          <div className='inprogress'>
            <h5>In Progress</h5>
            <div className='taches'>
            les taches a réaliser...
            </div>
            
            <form className='ajoutache'>
            <input type="text" name="opt" placeholder='ajouter tache' onFocus={(e) => e.target.placeholder = ""}  onBlur={(e) => e.target.placeholder = "Add an Option"}></input>
            <button>Ajouter tache</button>
            </form>
          
            </div>
          <div className='testing'>
            <h5>Testing</h5>
            <div className='taches'>
            les taches a réaliser...
            </div>
            <form className='ajoutache'>
            <input placeholder='ajouter tache '></input>
            <button>Ajouter tache</button>
            </form>
          </div>
          <div className='done'>
            <h5>Done</h5>
            <div className='taches'>
            </div>
            <form  className='ajoutache'>
            <input type="text" name="opt" placeholder='ajouter tache' onFocus={(e) => e.target.placeholder = ""}  onBlur={(e) => e.target.placeholder = "Add an Option"}></input>
            <button>Ajouter tache</button>
            </form>
          </div>
        </div> */}
    </div>
    )
  }
}
