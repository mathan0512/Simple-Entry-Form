import React from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';

export class EditDepModal extends React.Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event){
        event.preventDefault();
        //console.log(event.target.DepartmentId.value);
        //console.log(event.target.DepartName.value);
        fetch("http://localhost:5000/api/department/",{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                DepartmentId:event.target.DepartmentId.value,
                DepartName:event.target.DepartName.value
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result);
        },
        (error)=>{
            alert('Failed');
        })


       
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
    <Modal.Header>
        <Modal.Title id="contained-modal-title-vcenter">
            Edit Department
        </Modal.Title>
    </Modal.Header>
    <Modal.Body>

        <Row>
            <Col sm={6}>
                <Form onSubmit={this.handleSubmit}>
                <Form.Group controlId="DepartmentId">
                        <Form.Label>DepartmentId</Form.Label>
                        <Form.Control type="text" name="DepartmentId" required
                        disabled
                        defaultValue={this.props.depid} 
                        placeholder="DepartmentName"/>
                    </Form.Group>

                    <Form.Group controlId="DepartmentName">
                        <Form.Label>DepartmentName</Form.Label>
                        <Form.Control type="text" name="DepartmentName" required 
                        defaultValue={this.props.depname}
                        placeholder="DepartmentName"/>
                    </Form.Group>

                    <Form.Group>
                        <Button variant="primary" type="submit">
                            Update Department
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