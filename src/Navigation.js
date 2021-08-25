
import {NavLink} from 'react-router-dom';
import React,{Component} from 'react';
import { Navbar,Nav } from 'react-bootstrap';

export class Navigation extends Component{

    render()
    {

        return(
      <Navbar bg="light" expand="large">
            <Navbar.Toggle aria-controls="basic-navbar-nav"/>
            <Navbar.Collapse id="basic-navbar-nav">
                <Nav>
                <NavLink className="d-inline p-2 bd-dark text-dark" to="/">
                    Home
                </NavLink>
                <NavLink className="d-inline p-2 bd-dark text-dark" to="/department">
                    Department
                </NavLink>
                <NavLink className="d-inline p-2 bd-dark text-dark" to="/User">
                    User Master
                </NavLink>
                </Nav>
                </Navbar.Collapse>
      </Navbar>

        );
    }
}
