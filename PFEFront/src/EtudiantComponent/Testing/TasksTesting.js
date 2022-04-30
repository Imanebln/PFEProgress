import React from 'react';
import TaskTesting from './TaskTesting'
export default function TasksTesting(props) {
  return <div>
  {/* <button onClick={props.deleteOptions}>Remove  All</button>
        {props.options.length === 0 && <p> No options to show , Add ones </p>}
       <div>{
            props.options.map((option)=> <Task deleteOption={props.deleteOption} key={option} optionText={option}></Task> )
        }
        </div> 
  </div> */}

  <div className='todo'>
          <h5>Testing</h5>
        <button onClick={props.deleteOptionsTesting} className="removeAll">Tout supprimer</button>
        {
            props.optionstesting.length === 0 && <p className="msg"> Pas de taches à afficher , Ajouter une... </p>
        }
      <div className='list'> 
      {
            props.optionstesting.map((optiontesting)=> <TaskTesting deleteOptionTesting={props.deleteOptionTesting} key={optiontesting} optiontestingText={optiontesting}></TaskTesting> )
      }
      </div> 
          </div>
        </div>;
}