import React from 'react';
import './App.css';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
import Main from './components/Main'; 
import UserHome from './components/UserHome';


export default class App extends React.Component {
  
  render(){
    return (
      <div className="App">
        <BrowserRouter>
          <Switch>
            <Route path={'/'} exact component={Main}/>
            <Route path={'/home'} exact component={UserHome}/>
            <Route path={'/'} render={() => <div> 404 not found</div>}/>
          </Switch>
        </BrowserRouter>
      </div>
    );
  }

}
