import React from 'react';
import { SocialIcon } from 'react-social-icons';

export default class ContactUs extends React.Component{
    render(){
        return(
        <div>
            <div className='contact-icon'>
                <SocialIcon
                    bgColor='black'
                    style={{ height: 30, width: 30 }}
                    url="https://github.com/Marcel1123/.Net-Project"/>
            </div>
            <div className='contact-icon'>
                <SocialIcon
                    bgColor='#000dff'
                    style={{ height: 30, width: 30 }}
                    url="https://www.facebook.com/groups/2382611902059020/"/>
            </div>
            <div className='contact-icon'>
                <SocialIcon
                    bgColor='#ff0000'
                    style={{ height: 30, width: 30 }}
                    url="https://drive.google.com/drive/folders/1o4-FawuIjUFbfYUNZ2VBnWijmC1wKMqX?fbclid=IwAR3JZ8bH6JzDyIlsSJz6M9SvILHKHFel9etvTmwuJ3V2fx6aD5t8Q8i0w5o"/>
            </div>
        </div>
        );
    }

}