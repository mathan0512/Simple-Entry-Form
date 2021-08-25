import React,{Component} from 'react';
import {Table} from 'react-bootstrap';

import {Button,ButtonToolbar} from 'react-bootstrap';
import {AddDepModal} from './AddDepModal';
import {EditDepModal} from './EditDepModal';

export class Department extends Component{

    constructor(props){
        super(props);
        this.state={deps:[], addModalShow:false, editModalShow:false}
    }
   refreshList(){
        // fetch(process.env.REACT_APP_API+'department')
        //console.log(process.env.REACT_APP_API+'department');
        fetch("http://localhost:5000/api/department")
        // .then(response => {console.log('response api');
        //     console.log(response)})
         .then(response=>response.json())
         .then(data=>{
             console.log(data);
             this.setState({deps:data});
         });


        // fetch(process.env.REACT_APP_API+'department',{
        //     method:'GET',
        //     headers:{
        //         'Accept':'application/json',
        //         'Content-Type':'application/json'
        //     }
            
        // })
        // .then(response=>response.json())
        // .then(data=>{
        //     this.setState({deps:data});
        // });

    }
  

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(){
        this.refreshList();
    }

    deleteDep(depid){
        if(window.confirm('Are you sure?')){
            fetch("http://localhost:5000/api/department/"+depid,{
                //process.env.REACT_APP_API+'department/'
                method:'DELETE',
                header:{'Accept':'application/json',
            'Content-Type':'application/json'}
            })
        }
    }
    render(){
        const {deps, depid,depname}=this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        let editModalClose=()=>this.setState({editModalShow:false});
        console.log("DATA");
        console.log(deps);
        return(
            <div >
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>DepartmentId</th>
                        <th>DepartmentName</th>
                        <th>Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {deps.map(dep=>
                            <tr key={dep.Departmentid}>
                                <td>{dep.Departmentid}</td>
                                <td>{dep.Departname}</td>
                                <td>
<ButtonToolbar>
    <Button className="mr-2" variant="info"
    onClick={()=>this.setState({editModalShow:true,
        depid:dep.Departmentid,depname:dep.Departname})}>
            Edit
        </Button>

        <Button className="mr-2" variant="danger"
    onClick={()=>this.deleteDep(dep.Departmentid)}>
            Delete
        </Button>

        <EditDepModal show={this.state.editModalShow}
        onHide={editModalClose}
        depid={depid}
        depname={depname}/>
</ButtonToolbar>

                                </td>

                            </tr>)}
                    </tbody>

                </Table>

                <ButtonToolbar>
                    <Button variant='primary'
                    onClick={()=>this.setState({addModalShow:true})}>
                    Add Department</Button>

                    <AddDepModal show={this.state.addModalShow}
                    onHide={addModalClose}/>
                </ButtonToolbar>
            </div>
        )
    }
}