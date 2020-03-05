import React from 'react';
import { getPersonId } from '../../Authentificator/personIdHandler';
import { addPointOfInterest, deletePointOfInterest } from '../actions';


export default class Points extends React.Component{
    constructor(props) {
        super(props);
        this.state = {
            selectedPoint: null,
            points: this.props.points || [],
            pointToAdd: {
                lat: null,
                lng: null,
                cityName: '',
            },
            pointToAddName: '',
            pointToAddDescr: '',
            modalIsOpen: false,
        }
    }

    handleTextField = (event, param) =>{
        this.setState({[param]: event.target.value});
    }

    componentWillReceiveProps(nextProps) {
        this.setState({
            points: nextProps.points || [],
            pointToAdd: nextProps.pointToAdd || {lat: null, lng: null, cityName: ''},
            pointToAddName: nextProps.pointName.addrr || '',
        });
    }

    handlePointClick = (pointId, index) => {
        const { points } = this.state;
        const pointsLi = document.getElementsByClassName('point-li')
        for(let i = 0; i < points.length; i++){
            if(i !== index){ pointsLi[i].style.backgroundColor = 'white'; }
        }
        const targetPoint = document.getElementById(`int-point-${index}`);
        if(targetPoint.style.backgroundColor === 'rgb(153, 202, 255)') {
            targetPoint.style.backgroundColor = 'white';
            this.setState({selectedPoint: null})
        } else { 
            targetPoint.style.backgroundColor = 'rgb(153, 202, 255)'; 
            this.setState({selectedPoint: {pointId, index}})
        }
    }

    openPointModal = () => {
        this.setState({modalIsOpen: true})
    }

    addPoint = async (event) => {
        event.preventDefault();
        const {lat: latitude, lng: longitude, cityName } = this.state.pointToAdd;
        const {pointToAddName: name, pointToAddDescr: description} = this.state;
        const personId = getPersonId();
        let data = { 
            coordinates: { longitude, latitude },
            name,
            description,
            personId,
            cityName,
        };
        addPointOfInterest(data)
            .then((resp) => {
                let pointsCopy = this.state.points;
                pointsCopy.push(resp);
                this.setState({points: pointsCopy, modalIsOpen: false})
            });
    }

    deletePoint = () => {
        const { selectedPoint } = this.state;
        deletePointOfInterest(selectedPoint.pointId)
            .then((resp) => {
                let pointsCopy = this.state.points;
                pointsCopy.splice(selectedPoint.index, 1);
                this.setState({points: pointsCopy})
            })
        
    }


    render(){
    const { points } = this.state;
        return(
            <div className='points-container'>
                <div className='table-responsive points'>
                {points.map((point, index) => {
                    return(
                        <div 
                            key={`int-point-${index}`} 
                            id={`int-point-${index}`}
                            className='point-li form-control'
                            onClick={() => this.handlePointClick(point.id, index)}
                            >
                            {`${point.name} - ${point.description} (${point.cityName})`}
                        </div>
                    );
                })}
                </div>
                <div className='points-buttons'>
                    <button 
                        className='btn btn-primary btn-sm' 
                        style={{minWidth: '30%'}}
                        onClick={this.openPointModal}
                        disabled={!this.state.pointToAdd.lat || !this.state.pointToAdd.lng}
                    >
                        Add Point
                    </button>
                    <button 
                        className='btn btn-secondary btn-sm' 
                        style={{minWidth: '30%'}}
                        onClick={this.deletePoint}
                        disabled={!this.state.selectedPoint}
                    >
                        Remove Point
                    </button>
                </div>
                {this.state.modalIsOpen &&
                <div className='point-modal' style={{ zIndex:5}}>
                    <form onSubmit={this.addPoint}>
                        <label className='font-weight-bold form-label'>
                            Add As Point Of Interest
                        </label>
                            <input
                                type='text'
                                className='form-control'
                                style={{backgroundColor: 'white'}}
                                value={this.state.pointToAddName}
                                placeholder='Address'
                                readOnly={true}
                            />
                            <input
                                className='form-control'
                                type='endPoint'
                                value={this.state.pointToAddDescr}
                                placeholder='Enter a description'
                                onChange={(event) => {this.handleTextField(event, 'pointToAddDescr')}}
                            />
                        <div className='points-buttons'>   
                            <button
                                type='submit'
                                style={{maxWidth: 160}}
                                className='btn btn-primary btn-sm form-row'
                                disabled={!this.state.pointToAdd.lat || !this.state.pointToAdd.lng || !this.state.pointToAddName}
                            >
                                Submit
                            </button>
                            <button
                                style={{maxWidth: 160}}
                                className='btn btn-secondary btn-sm form-row'
                                onClick={() => this.setState({modalIsOpen: false})}
                            >
                                Cancel
                            </button>
                        </div>
                    </form>
                </div>
                }
            </div>
        );
    }
}
