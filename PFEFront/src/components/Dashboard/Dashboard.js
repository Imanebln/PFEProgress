import React, { Component } from 'react';
import '../../App.css';
import { Button, Card, CardBody, CardGroup, Col, Container, Form, 
         Input, InputGroup, InputGroupAddon, InputGroupText, Row } from 'reactstrap';

export default function Dashboard() {

    const user = JSON.parse(sessionStorage.getItem('user'));

    const handleLogout = () => {
        sessionStorage.removeItem("token");
        // sessionStorage.removeItem("user");
        window.location.href = "/";
        console.log("Hy" + user);
      };
    
    
      console.log("Hy " + user);


 
        return (
            <div class="row" className="mb-2 pageheading">
                <div class="col-sm-12">
                    Welcome to CHEF DE FILIERE Space 
             </div>
             
             {/* <p> Welcome {user.username}</p> */}
             {/* <Button onClick={handleLogout}>Logout</Button> */}
             
             
            </div>
        );
}