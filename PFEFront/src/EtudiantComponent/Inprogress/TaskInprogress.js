import React from 'react';
import '../Todo/StylingTodo.css'
export default function TaskInprogress(props) {
  return <div>
  <div className='taches'>
  <div className='tachetxt'>{props.optioninprogressText}</div>

   <button className='remove' onClick={(e) => {
      props.deleteOptionInprogress(props.optioninprogressText);
    }}>supprimer</button>  
  </div> 
  
 
  </div>;
}