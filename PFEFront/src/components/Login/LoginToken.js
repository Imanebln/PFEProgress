import React from 'react';
import PropTypes from 'prop-types';
import { useState } from 'react'; 
import { useNavigate } from 'react-router-dom';
import swal from 'sweetalert';
import { Button, Card, CardBody, CardGroup, Col, Container, Form, Input, 
  InputGroup, InputGroupAddon, InputGroupText, Row } from 'reactstrap';

async function loginUser(credentials) {
    return fetch('https://localhost:7004/api/Authenticate/login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(credentials)
    })
      .then(data => data.json())
   }

export default function LoginToken({ setToken }) {

  const [username, setUserName] = useState();
  const [password, setPassword] = useState();

  const handleSubmit = async e => {
    e.preventDefault();
    const token = await loginUser({
      username,
      password
    });
    // if ('accessToken' in token) {
    //   swal("Success", token.message, "success", {
    //     buttons: false,
    //     timer: 2000,
    //   })
    //   .then((value) => {
    //     localStorage.setItem('accessToken', token['accessToken']);
    //     localStorage.setItem('user', JSON.stringify(token['user']));
    //     window.location.href = "/profile";
    //   });
    // } else {
    //   swal("Failed", token.message, "error");
    // }
    setToken(token);
    // if(setToken(token)){
    //   console.log("hello world!!!!!");
    //   this.props.history.push("/Dashboard");
    // }
    // else{
    //   console.log("error !!!!!");
    // }
    // setToken(token);

    
  }

  return(
    <div className="app flex-row align-items-center">
    <Container>
    <Row className="justify-content-center">
                        <Col md="9" lg="7" xl="6">
                            <CardGroup>
                                <Card className="p-2">
                                    <CardBody>
    
    
      <form onSubmit={handleSubmit}>
      <div class="row" 
                                            className="mb-2 pageheading">
                                                <div class="col-sm-12">
                                                    Login
                             </div>
                             </div>

        <InputGroup className="mb-3">
          <Input placeholder="Enter Username" type="text" onChange={e => setUserName(e.target.value)} />
          </InputGroup>
       
        <InputGroup className="mb-3">
          <Input  placeholder="Enter Password" type="password" onChange={e => setPassword(e.target.value)} />
          </InputGroup>
        
        <div>
          <Button color="success" block>Login</Button>
        </div>
      </form>
      </CardBody>
      </Card>
      </CardGroup>
      </Col>
      </Row>
      </Container>
      </div>

    
  )
}
LoginToken.propTypes = {
    setToken: PropTypes.func.isRequired
  }