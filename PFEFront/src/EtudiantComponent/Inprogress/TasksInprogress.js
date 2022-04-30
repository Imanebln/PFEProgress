import React from 'react';
import TaskInprogress from './TaskInprogress'
import TaskTodo from '../Todo/TaskTodo';
import TasksTodo from '../Todo/TasksTodo';

export default function TasksInprogress(props) {

  return <div>
  <div className='todo'>
          <h5>In Progress</h5>
        <button onClick={props.deleteOptionsInprogress} className="removeAll">Tout supprimer</button>
        {
            props.optionsinprogress.length === 0 && <p className="msg"> Pas de taches à afficher , Ajouter une... </p>
        }
      <div className='list'> 
      {
            props.optionsinprogress.map((optioninprogress)=>{ 
              <TaskInprogress deleteOptionInprogress={props.deleteOptionInprogress} key={optioninprogress} optioninprogressText={optioninprogress}></TaskInprogress> 
            } )
      }

      </div> 
          </div>
        </div>;
}