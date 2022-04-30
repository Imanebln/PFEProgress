import React from 'react';
import '../Todo/StylingTodo.css'
export default function TaskDone(props) {
  return <div>
  {/* <div>
  {props.optionText}
  <button onClick={(e) => {
      props.deleteOption(props.optionText);
    }}>remove</button>
  </div> */}
  <div className='taches'>
  <div className='tachetxt'>{props.optiondoneText}</div>

   <button className='remove' onClick={(e) => {
      props.deleteOptionDone(props.optiondoneText);
    }}>supprimer</button>  

  </div> 
  
 
  </div>;
}