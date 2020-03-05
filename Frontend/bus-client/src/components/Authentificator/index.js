import React from 'react';
import LoginForm from './LoginForm';
import RegisterForm from './RegisterForm';
import verified from '../../images/verified.jpg';
import wrong from '../../images/wrong.jpg';


export default class Authentificator extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            auth: 'login',
            showModal: false,
            modalMessage: '',
            modalImg: wrong,
        };
    }

    hideModal = () => {
        setTimeout(() => {
                this.setState({showModal: false})
            }, 2000);
    }
    handleLoginResponse = (resp) => {
        if(resp === false){
            this.setState({
                modalMessage: 'Login failed! Wrong username or password!',
                showModal: true,
                modalImg: wrong,
                }, () => { this.hideModal(); });
        } else {
            this.props.handleSuccessLogin(resp);
        }
    }

    handleRegisterResponse = (resp) => {
        let msg = 'Something went wrong!';
        let auth = 'register';
        let img = wrong;
        if(resp){
            msg = 'User successfully created!';
            auth = 'login';
            img = verified;
        }
        this.setState({modalMessage: msg, showModal: true, modalImg: img, auth}, () => { this.hideModal(); });
    }

    render(){
        return(
        <>
            {this.state.showModal &&
                <div className='register-modal'>
                    <img src={this.state.modalImg} alt=''/>
                    {this.state.modalMessage}
                </div>
            }
            {this.state.auth === 'login' &&
                <LoginForm
                    changeAuth={(val) => this.setState({auth: val})}
                    updateModal={resp => this.handleLoginResponse(resp)}
                >
                </LoginForm>}
            {this.state.auth === 'register' &&
                <RegisterForm
                    changeAuth={val => this.setState({auth: val})}
                    updateModal={resp => {this.handleRegisterResponse(resp)}}
                >
                </RegisterForm>
            }
        </>
        );
    }

}