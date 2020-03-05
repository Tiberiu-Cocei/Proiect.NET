import React from 'react';
import { Redirect } from 'react-router-dom';
import { getPersonId, delPersonId } from '../Authentificator/personIdHandler';
import { 
    getUserCurrentLocation, 
    getPointsOfInterestByCityName, 
    getCityNameByCoords,
} from './actions';
import ContactUs from '../ContactUs';
import Menu from './utils/menu';
import MapContainer from './utils/map';
// import { getUserCurrentLocation, getPointsOfInterestByCityName } from './actions';

import './index.css';


export default class UserHome extends React.Component{

    constructor(props){
        super(props);
        this.state = {
            location: {
                lat: null,
                lng: null,
                cityName: '',
            },
            pointsOfInterest: [],
            pointToAdd: {
                lat: null,
                lng: null,
                cityName: null,
            },
            destination: {
                lat: null,
                lng: null,
                addrr: '',
            },
            processedRouteArray: [],
        }
    }

    logOutUser = () => {
        delPersonId();
        this.forceUpdate();        
    }

    componentDidMount(){
        getUserCurrentLocation(this.updateUserLocation)
    }

    updateUserLocation = (lat, lng, cityName) => {
        this.setState({ location: { lat, lng, cityName } });
        getPointsOfInterestByCityName(cityName)
            .then(response => this.setState({ pointsOfInterest: response }));
    }

    setPointToAddCoords = async (lat, lng) => {
        const cityName = await getCityNameByCoords(lat, lng);
        this.setState({pointToAdd: {lat, lng, cityName }})
    }

    setDestination = (lat, lng, addrr) => {
        this.setState({destination: {lat, lng, addrr}});
    }

    processRoute = (data) => {
        console.log('data', data);
        let processedRouteArray = [];
        // process data here => processedroutearr = [{lat: .., lng: ..}, ...., {lat: .., lng: ..} ]
        this.setState({processedRouteArray});
    }
    
    render(){
        if(!getPersonId()){ return <Redirect to='/'/>; }
        return(
            <div className='user-home'>
                <div className='user-header'>
                    <button
                        className='btn btn-secondary btn-sm'
                        onClick={this.logOutUser}
                    >
                        Log Out
                    </button>
                </div>
                <div className='user-home-container'>
                    <Menu
                        points={this.state.pointsOfInterest}
                        pointToAdd={this.state.pointToAdd}
                        userLocation={this.state.location}
                        destination={this.state.destination}
                        sendRoute={this.processRoute}
                    />
                    <MapContainer
                        userLocation={this.state.location}
                        addPoint={this.setPointToAddCoords}
                        onDestClick={this.setDestination}
                        routes={this.state.processedRouteArray}
                    ></MapContainer>
                </div>
                <div className='footer'>
                    <div className='contact-us' style={{ flexDirection: 'row'}}>
                    &copy; 2020 - Smart City &nbsp;
                    <ContactUs/>
                    </div>
                </div>
            </div>
        );
    }

}