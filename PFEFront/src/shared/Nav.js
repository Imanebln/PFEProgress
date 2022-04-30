import React from "react";
import { NavLink } from "react-router-dom";
import { Button } from "reactstrap";

const Nav = () => {
    const handleLogout = () => {
        sessionStorage.removeItem("token");
        // sessionStorage.removeItem("user");
        window.location.href = "/";
      };
	return (
		<nav className="navbar navbar-expand-lg navbar-dark bg-dark mb-4 ">
			<div className="container">
				<ul className="navbar-nav mr-auto">
					<NavLink className="navbar-brand" hrefLang="https://henok.us" to="/Dashboard">
						PFEProgress
					</NavLink>
					
					<li className="nav-item">
						<NavLink
							className="nav-link"
							activeClassName="active"
							to={'/Etudiant'}
						>
							Espace Etudiant
						</NavLink>
					</li>
                    {/* <li className="nav-item">
                    <Button class="btn-nav"
                            onClick={handleLogout}>Logout</Button>

                    </li> */}
                    
					
				</ul>
			</div>
		</nav>
	);
};

export default Nav;
