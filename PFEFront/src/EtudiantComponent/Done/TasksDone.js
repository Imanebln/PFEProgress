import React from 'react';
import TaskDone from './TaskDone'
export default function TasksDone(props) {
  return <div>
  {/* <button onClick={props.deleteOptions}>Remove  All</button>
        {props.options.length === 0 && <p> No options to show , Add ones </p>}
       <div>{
            props.options.map((option)=> <Task deleteOption={props.deleteOption} key={option} optionText={option}></Task> )
        }
        </div> 
  </div> */}

  <div className='todo'>
          <h5>Done</h5>
        <button onClick={props.deleteOptionsDone} className="removeAll">Tout supprimer</button>
        {
            props.optionsdone.length === 0 && <p className="msg"> Pas de taches à afficher , Ajouter une... </p>
        }
      <div className='list'> 
      {
            props.optionsdone.map((optiondone)=> <TaskDone deleteOptionDone={props.deleteOptionDone} key={optiondone} optiondoneText={optiondone}></TaskDone> )
      }
      </div> 
          </div>
        </div>;
}