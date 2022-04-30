import React, { useState } from "react";
import { post } from "axios";
import { useNavigate } from "react-router-dom";
import {Link} from "react-router-dom";
import EtudiantsListe from "./EtudiantsListe";
import {toast} from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
toast.configure();

function AjouterEtudiant(props) {

	function getToken() {
		const tokenString = sessionStorage.getItem('token');
		const userToken = JSON.parse(tokenString);
		return userToken?.token
	  }
    
    const initialState = {
		nom: "",
		prenom: "",
		email: "",
		username:""
		// emailEncadrant:"",
		// nomSociete:"",
		// tech:"",
		// ville:"",
		// sujet:"",
		// passwordHash: "GI123.",
	};
	const [etudiant, setEtudiant] = useState(initialState);

	const navigate = useNavigate();

    function handleSubmit(event) {
		event.preventDefault();
		//if (!crud.companyName || !crud.email) return;
		async function postCrud() {
			try {
				const response = await post("https://localhost:7004/api/Authenticate/add-etudiant", etudiant,{headers: {"Authorization" : `Bearer ${getToken()}`}});
				
				
			} catch (error) {
				console.log("error", error);
			}
            finally{
                navigate("/EtudiantsListe");
            }
		}
		postCrud();
	}

    function handleChange(event) {
		setEtudiant({ ...etudiant, [event.target.name]: event.target.value });
	}

	function handleCancel() {
        navigate("/EtudiantsListe");
        
    }

	

	return (
		<div className="container" style={{ maxWidth: "400px" }}>
			<h2>Ajouter un Etudiant</h2>
			<hr />
            <form onSubmit={handleSubmit}>
			<div className="form-group">
					<label>Username</label>
					<input
						name="username"
						type="text"
						required
						value={etudiant.username}
						onChange={handleChange}
						className="form-control"
					/>
				</div>
				<div className="form-group">
					<label>Nom</label>
					<input
						name="nom"
						type="text"
						required
						value={etudiant.nom}
						onChange={handleChange}
						className="form-control"
					/>
				</div>
				<div className="form-group">
					<label>Prenom</label>
					<input
						name="prenom"
						type="text"
						required
						value={etudiant.prenom}
						onChange={handleChange}
						className="form-control"
					/>
				</div>
				<div className="form-group">
					<label>Email</label>
					<input
						name="email"
						type="email"
						pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,63}$"
						required
						value={etudiant.email}
						onChange={handleChange}
						className="form-control"
					/>
				</div>
				<br></br>
				{/* <div className="form-group">
					<label>Email Encadrant</label>
					<input
						name="emailEncadrant"
						type="email"
						pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,63}$"
						required
						value={etudiant.emailEncadrant}
						onChange={handleChange}
						className="form-control"
					/>
				</div>
				<div className="form-group">
					<label>Sujet</label>
					<input
						name="sujet"
						type="text"
						required
						value={etudiant.sujet}
						onChange={handleChange}
						className="form-control"
					/>
				</div>
				<br/>
				<div className="form-group">
					<label>Nom de societe</label>
					<input
						name="nomSociete"
						type="text"
						required
						value={etudiant.nomSociete}
						onChange={handleChange}
						className="form-control"
					/>
				</div>
				<br>
				</br>
				<div className="form-group">
					<label>Ville</label>
					<input
						name="ville"
						type="text"
						required
						value={etudiant.ville}
						onChange={handleChange}
						className="form-control"
					/>
				</div>
				<br/>
				<div className="form-group">
					<label>technologie utilise</label>
					<input
						name="tech"
						type="text"
						required
						value={etudiant.technologiesUtilisees}
						onChange={handleChange}
						className="form-control"
					/>
				</div> */}
				<br/>
				<div className="btn-group">
					<input type="submit" value="Submit" className="btn btn-primary" />
					<button
						type="button"
						onClick={handleCancel}						
                        className="btn btn-secondary"
					>
						Cancel
					</button>
				</div>
				
			</form>
			
		</div>
	);
}

export default AjouterEtudiant;