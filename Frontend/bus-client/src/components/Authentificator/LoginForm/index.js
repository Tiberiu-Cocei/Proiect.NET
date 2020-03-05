import React from 'react';
import SimpleReactValidator from 'simple-react-validator';
import logo from '../../../logo.png'

import loginPerson from './actions';


export default class LoginForm extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            username: '',
            password: '',
        };
        this.validator = new SimpleReactValidator();
    }

    handleTextField = (event, param) =>{
        this.setState({[param]: event.target.value});
        this.validator.showMessageFor(param);
    }

    validateLogin = () => {
        let valid = false;
        if(this.validator.allValid()){
            valid = true;
        } else {
            this.forceUpdate();
        }
        return valid;
    }

    submitLogin = async (event) => {
        event.preventDefault();
        const  {username, password} = this.state;
        if(this.validateLogin()){
            const loggedIn = await loginPerson({username, password});
            this.props.updateModal(loggedIn);
        }
    }

    render(){
        return(
        <div className='authentif-form'>
            <img
                src={logo}
                className='App-logo'
                style={{marginBottom: 30}} 
                alt='logo'
            ></img>
            <form
                onSubmit={this.submitLogin}
                style={{width: 300}}
            >
                <label className='font-weight-bold form-label'>
                    Username
                </label>
                    <input
                        className='form-control'
                        type='text'
                        value={this.state.username}
                        placeholder='Enter username'
                        onChange={(event) => {this.handleTextField(event, 'username')}}
                    />
                    {this.validator.message('username', this.state.username, 'required|alpha_num|min:7|max:20')}
                <label className='font-weight-bold form-label'>
                    Password
                </label>
                    <input
                        className='form-control'
                        type='password'
                        value={this.state.password}
                        placeholder='Enter password'
                        onChange={(event) => {this.handleTextField(event, 'password')}}
                    />
                    {this.validator.message('password', this.state.password, 'required|alpha_num')}
                <button
                    type='submit'
                    className='btn btn-primary btn-sm form-row'
                    style={{marginTop: 25}}
                >
                    Log In
                </button>
                <button
                    type='button'
                    className='btn btn-secondary btn-sm form-row'
                    onClick={() => this.props.changeAuth('register')}
                >
                    Register
                </button>
            </form>
        </div>
        );
    }

}