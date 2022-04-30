import { Table, Button, Row } from 'reactstrap';
import Modal from 'react-bootstrap/Modal';
import axios from "axios";
import React, { useState, useEffect } from "react";
import { useNavigate, useParams  } from "react-router-dom";

function ModalView(props) {

    const [encadrant,setEncadrant]= useState({});
    // const { id } = useParams();
    
    useEffect(()=>{
        setEncadrant(props.encadrant)
    })
   
//   useEffect(() => {

//       console.log("sa;am",props.id)
//       if(props.id) {
//         axios.get(`https://localhost:7004/api/Encadrants/${props.id}`).then(res => {
//             console.log(res);
//             // setEncadrant(res.data);
      

//     })}
//   }, [props.id])
console.log(props.encadrant.id);
    return (
      
      <Modal
        {...props}
        size="lg"
        aria-labelledby="contained-modal-title-vcenter"
        centered
      >
        <Modal.Header closeButton>
          <Modal.Title id="contained-modal-title-vcenter">
            Details
          </Modal.Title>
        </Modal.Header>
        
        <Modal.Body>
        
            {encadrant.id}
            <Button className="butt" color="primary" onClick="">Modifier</Button>

          <p>
            <form>
                <div  className="form-group">
                    <label>Nom</label>
                    <input name="nom"
						        type="text"
						        value={encadrant.nom}
					        	className="form-control" disabled/>
                </div>

                <div  className="form-group">
                <label>Prenom</label>
                <input name="prenom"
                    type="text"
                    value={encadrant.prenom}
                    className="form-control" disabled/>
                </div>

                <div  className="form-group">
                <label>Email</label>
                <input name="email"
                    type="text"
                    value={encadrant.email}
                    className="form-control" disabled/>
                </div>
                
            </form>
          
          </p>
          
        </Modal.Body>
        
        <Modal.Footer>
          <Button onClick={props.onHide}>Close</Button>
        </Modal.Footer>
      </Modal>
    );
  }
  
export default ModalView;
