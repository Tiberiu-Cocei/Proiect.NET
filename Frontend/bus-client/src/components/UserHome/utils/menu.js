import React from 'react';
import { getAddressByCoords, getCityRoutes } from '../actions';
import Points from '../utils/points';

export default class Menu extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            startPoint: '',
            endPoint: '',
        };
    }

    componentWillReceiveProps(nextProps) {
        console.log(nextProps)
        getAddressByCoords(nextProps.userLocation.lat, nextProps.userLocation.lng)
            .then((addrr) => {
                this.setState({startPoint: addrr, endPoint: nextProps.destination.addrr });
            });
    }

    pointsAreInvalid = () => {
        if(!this.state.startPoint || !this.state.endPoint) { return true }
    }

    searchSubmit = async (event) => {
        event.preventDefault();
        const startcoordonates = `${this.props.userLocation.lat}_${this.props.userLocation.lng}`;
        const endcoordonates = `${this.props.destination.lat}_${this.props.destination.lng}`;
        const { cityName } = this.props.userLocation;
        getCityRoutes(startcoordonates, endcoordonates, cityName)
            .then((resp) => this.props.sendRoute(resp))
    }
    
    render(){
        return(
        <div className='left-menu'>
            <form
                style={{width: '40%', marginRight: 15}}
                onSubmit={this.searchSubmit}
            >
                <label className='font-weight-bold form-label'>
                    Start point
                </label>
                    <input
                        type='text'
                        className='form-control'
                        style={{backgroundColor: 'white'}}
                        value={this.state.startPoint}
                        placeholder='Enter start adress'
                        readOnly={true}
                    />
                <label className='font-weight-bold form-label'>
                    End point
                </label>
                    <input
                        type='endPoint'
                        className='form-control'
                        style={{backgroundColor: 'white'}}
                        value={this.state.endPoint}
                        placeholder='Enter destination'
                        readOnly={true}
                    />
                <button
                    type='submit'
                    className='btn btn-primary btn-sm form-row'
                    style={{marginTop: 25}}
                    disabled={this.pointsAreInvalid()}
                >
                    Search
                </button>
            </form>
            <Points
                points={this.props.points}
                pointToAdd={this.props.pointToAdd}
                pointName={this.props.destination}
            />
        </div>
        );
    }

}