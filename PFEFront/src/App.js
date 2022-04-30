import React from 'react';
import { useState } from 'react'; 
import './App.css';  
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/css/bootstrap.css';
import Login2 from "./components/Login/Login2";  
import { BrowserRouter as Router,Routes, Switch, Route, Link } from 'react-router-dom';   
import Dashboard from "./components/Dashboard/Dashboard";  
import Home from './components/Home/Home';
import EtudiantsListe from './components/Crud/EtudiantsListe';
import EncadrantsListe from './components/Crud/EncadrantsListe';
import AjouterEncadrant from './components/Crud/AjouterEncadrant';
import AjouterEtudiant from './components/Crud/AjouterEtudiant';
import Navbar from './shared/Navbar';
import Nav from './shared/Nav';
import Footer from './shared/Footer';
import LoginToken from './components/Login/LoginToken';
import { useNavigate } from 'react-router-dom';
import Etudiant from './EtudiantComponent/Etudiant';
import { Button } from 'reactstrap';

function setToken(userToken) {
  sessionStorage.setItem('token', JSON.stringify(userToken));
  window.location.href = "/Dashboard";
}

function getToken() {
  const tokenString = sessionStorage.getItem('token');
  const userToken = JSON.parse(tokenString);
  return userToken?.token
}


function App() {  
  // const navigate = useNavigate();
  // const [token, setToken] = useState();
  const token = getToken();
  if(!token) {
    return (
      <>
      {/* <Navbar/> */}
      <Nav/>
      <LoginToken setToken={setToken} />
      {/* <Routes>
        <Route path="/Etudiant" component={Etudiant} element={<Etudiant/>}/>
     </Routes> */}
     
      <div className='footer'>
     <Footer/>
     </div>

    </>
    )
  }
  //else if(token) {
  //   console.log("hello world!!!!!");
  // }

  return (  
      <>
      
      <Navbar />
     
      <Routes>
          <Route path='/Navbar' element={<Navbar/>} />
          <Route path='/Nav' element={<Nav/>} />
          <Route path='/Footer' element={<Footer/>} />
          <Route path='/LoginToken' element={<LoginToken/>} />  
          <Route path='/Login2' component={Login2} element={<Login2/>} />     
          <Route path='/Dashboard' component={Dashboard} element={<Dashboard/>}/>  
          <Route path="/EncadrantsListe" component={EncadrantsListe} element={<EncadrantsListe/>} />
          <Route path='/' component={LoginToken} element={<LoginToken/>} />
          <Route path="/EtudiantsListe" component={EtudiantsListe} element={<EtudiantsListe/>}/>
          <Route path="/AjouterEncadrant" component={AjouterEncadrant} element={<AjouterEncadrant/>}/>
          <Route path="/AjouterEtudiant" component={AjouterEtudiant} element={<AjouterEtudiant/>}/>
          <Route path="/Etudiant" component={Etudiant} element={<Etudiant/>}/>
          
      </Routes> 
     <div className='footer'>
     <Footer/>
     </div>
       </>
  );  
}  
  
export default App; 