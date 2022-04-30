import React from 'react';
import './StylingTodo.css';
import { useState, createContext } from 'react';
export const UserContext = createContext();
export default function TaskTodo(props) {
  

  return <div>
      <div className='taches'>
  <div className='tachetxt'>{props.optiontodoText}</div>

   <button className='remove' onClick={(e) => {
      props.deleteOptionTodo(props.optiontodoText);
    }}>supprimer</button>  
  </div>
  
  </div>;
}




