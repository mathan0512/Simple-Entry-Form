
import './App.css';
import {Home} from './Home';
import {Department} from './Department';
import {User} from './User';
import {Navigation} from './Navigation';
import {BrowserRouter,Route,Switch} from 'react-router-dom'

function App() {
  return (
<BrowserRouter>

    <div className="container">
     <h3 className="m-3 d-flex justify-content-center">
       React Web API Application
     </h3>
     <Navigation/>

     <Switch>
       <Route path='/' component={Home} exact/>
       <Route path='/department' component={Department} exact/>
       <Route path='/User' component={User} exact/>
     </Switch>
    </div>
    </BrowserRouter>
  );
}

export default App;
