/* eslint-disable jsx-a11y/alt-text */
import React from 'react'
import {useState} from 'react';
import Done from './Done/Done'
import Inprogress from './Inprogress/Inprogress'
import profile from './profile.png'
import  './Styling.css'
import Testing from './Testing/Testing'
import Todo from './Todo/Todo'

export default function Etudiant() {
	const [selectedFile, setSelectedFile] = useState();
	const [isFilePicked, setIsFilePicked] = useState(false);
  const changeHandler = (event) => {
		setSelectedFile(event.target.files[0]);

	};

	const handleSubmission = () => {
	};
  return (
    <div> 
      <div>
      <nav className='mynav'>
     <div className='left'><p>PFE Progress</p></div>
     <div className='right'>
      <img src={profile}></img>
      <div className='menu'>
      <ul>
      <li>
      Informations
      </li>
      <li>
      Déconnexion
      </li>
      </ul>
      </div>
     </div>
    </nav>
    
    <div className='mylists'>
      <div className='list1'><Todo></Todo></div>
      <div className='list2'><Inprogress></Inprogress></div>
      <div className='list3'><Testing></Testing></div>
      <div className='list4'><Done></Done></div>
    </div>

   

  </div></div>
  )
}
