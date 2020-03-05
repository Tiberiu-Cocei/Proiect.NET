import React from 'react';
import SimpleReactValidator from 'simple-react-validator';
import logo from '../../../logo.png'

import registerPerson from './actions';



export default class RegisterForm extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            firstName: '',
            lastName: '',
            username: '',
            email: '',
            password: '',       
        };
        this.validator = new SimpleReactValidator();
    }

    handleTextField = (event, param) => {
        this.setState({[param]: event.target.value});
        this.validator.showMessageFor(param);
    }

    validateRegister = () => {
        let valid = false;
        if(this.validator.allValid()){
            valid = true;
        } else {
            this.forceUpdate();
        }
        return valid;
    }

    submitRegister = async (event) => {
        event.preventDefault();
        const { firstName, lastName, email, username, password } = this.state;
        if(this.validateRegister()){
            const registered = await registerPerson({firstName, lastName, email, username, password});
            this.props.updateModal(registered)
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
                onSubmit={this.submitRegister}
                style={{width: 300}}
            >
                <label className='font-weight-bold form-label'>
                    First Name
                </label>
                    <input
                        className='form-control'
                        type='text'
                        value={this.state.firstName}
                        placeholder='Enter firstName'
                        onChange={(event) => this.handleTextField(event, 'firstName')}
                    />
                    {this.validator.message('firstName', this.state.firstName, 'required|alpha')}
                <label className='font-weight-bold form-label'>
                    Last name
                </label>
                    <input
                        className='form-control'
                        type='text'
                        value={this.state.lastName}
                        placeholder='Enter lastName'
                        onChange={(event) => this.handleTextField(event, 'lastName')}
                    />
                    {this.validator.message('lastName', this.state.lastName, 'required|alpha')}
                <label className='font-weight-bold form-label'>
                    Username
                </label>
                    <input
                        className='form-control'
                        type='text'
                        value={this.state.username}
                        placeholder='Enter username'
                        onChange={(event) => this.handleTextField(event, 'username')}
                    />
                    {this.validator.message('username', this.state.username, 'required|alpha_num|min:7|max:20')}
                <label className='font-weight-bold form-label'>
                    Email
                </label>
                    <input
                        className='form-control'
                        type='text'
                        value={this.state.email}
                        placeholder='Enter email'
                        onChange={(event) => this.handleTextField(event, 'email')}
                    />
                    {this.validator.message('email', this.state.email, 'required|email')}
                <label className='font-weight-bold form-label'>
                    Password
                </label>
                    <input
                        className='form-control'
                        type='password'
                        value={this.state.password}
                        placeholder='Enter password'
                        onChange={(event) => this.handleTextField(event, 'password')}
                    />
                    {this.validator.message('password', this.state.password, 'required|alpha_num')}
                <button
                    type='submit'
                    className='btn btn-primary btn-sm form-row'
                    style={{marginTop: 25}}
                >
                    Register
                </button>
                <button
                    type='button'
                    className='btn btn-secondary btn-sm form-row'
                    onClick={() => this.props.changeAuth('login')}
                >
                    Log In
                </button>
            </form>
        </div>
        );
    }

}