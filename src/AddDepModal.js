import React from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';

export class AddDepModal extends React.Component{
    constructor(props){
        super(props);
    this.handleSubmit=this.handleSubmit.bind(this);
        
    }
     //REACT_APP_API= http://localhost:5000/api/
//REACT_APP_PHOTOPATH=http://localhost:5000/Snaps/
      //
    handleSubmit(event){
        event.preventDefault();
        fetch("http://localhost:5000/api/department",{
           // process.env.REACT_APP_API+'department'
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
     
            body:JSON.stringify({
               // DepartmentId:0,
                DepartName:event.target.DepartName.value
            })
        })
        //console.log(event);
        // .then(res=>res.json())
        // .then((result)=>{
        //     alert(result);
        // },
        // (error)=>{
        //     alert('Failed');
        // })
    }
    render(){
        return (
            <div className="container">

<Modal
{...this.props}
size="lg"
aria-labelledby="contained-modal-title-vcenter"
centered
>
    <Modal.Header clooseButton>
        <Modal.Title id="contained-modal-title-vcenter">
            Add Department
        </Modal.Title>
    </Modal.Header>
    <Modal.Body>

        <Row>
            <Col sm={6}>
                <Form onSubmit={this.handleSubmit}>
                    <Form.Group controlId="DepartName">
                        <Form.Label>DepartmentName</Form.Label>
                        <Form.Control type="text" name="DepartName" required 
                        placeholder="DepartName"/>
                    </Form.Group>
                    <Form.Group>
        <Button variant="primary" type="submit">
            Add Department
        </Button>
    </Form.Group>
                  
                </Form>
            </Col>
        </Row>
    </Modal.Body>
    
    <Modal.Footer>
        <Button variant="danger" onClick={this.props.onHide}>Close</Button>
       
      
    </Modal.Footer>

</Modal>

            </div>
        )
    }

}