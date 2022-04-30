import React from 'react';
import '../Todo/StylingTodo.css'
export default function TaskTesting(props) {
  return <div>
  {/* <div>
  {props.optionText}
  <button onClick={(e) => {
      props.deleteOption(props.optionText);
    }}>remove</button>
  </div> */}
  <div className='taches'>
  <div className='tachetxt'>{props.optiontestingText}</div>

   <button className='remove' onClick={(e) => {
      props.deleteOptionTesting(props.optiontestingText);
    }}>supprimer</button>  

  </div> 
  
 
  </div>;
}