import React from 'react';
import { Redirect } from 'react-router-dom';
import { setPersonId, getPersonId } from '../Authentificator/personIdHandler';
import Authentificator from '../Authentificator';
import ContactUs from '../ContactUs';

export default class Main extends React.Component{

    handleSuccessLogin = (respData) => { 
        setPersonId(respData.id); 
        this.forceUpdate(); 
    }

    render(){
        if(getPersonId()){ return <Redirect to='/home'/>; }

        return(
        <div className='main'>
            <div className='main main-auth'>
                <Authentificator
                    handleSuccessLogin={(respData) => this.handleSuccessLogin(respData)}
                ></Authentificator>
            </div>
            <div className='main main-description'>
                <h3>Everyone, everywhere, everyday.</h3>
                <h1>Smart City, an app that<br/>takes you away.</h1>
                <div className='contact-us'>
                    <div className='contact-us-bar'></div>
                    <ContactUs/>
                </div>
            </div>
        </div>
        );
    }

}