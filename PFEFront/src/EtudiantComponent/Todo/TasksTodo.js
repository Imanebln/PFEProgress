import React from 'react';
import TaskTodo from './TaskTodo'
export default function TasksTodo(props) {
  return <div>

  <div className='todo'>
          <h5>To Do</h5>
        <button onClick={props.deleteOptionsTodo} className="removeAll">Tout supprimer</button>
        {
            props.optionstodo.length === 0 && <p className="msg"> Pas de taches à afficher , Ajouter une... </p>
        }
      <div className='list'> 
      {
            props.optionstodo.map((optiontodo)=> <TaskTodo deleteOptionTodo={props.deleteOptionTodo} key={optiontodo} optiontodoText={optiontodo} moveOptionTodo={props.moveOptionTodo}></TaskTodo> )
      }
      </div> 
          </div>
        </div>;
}