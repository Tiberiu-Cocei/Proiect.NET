import React from 'react';
import { getAddressByCoords } from '../actions';

import {Map, InfoWindow, Marker, GoogleApiWrapper} from 'google-maps-react';
  
const mapStyle = {
    width: 'calc(100% - 20px)' ,
    height: 'calc(100% - 8vh - 20px)',
    marginBottom: 'calc(7vh + 5px)',
};

export class MapContainer extends React.Component {

  constructor(props){
    super(props);
    this.state = {
      pointOfIntMarker: {},
    }
    this.onClick = this.onClick.bind(this);
  }

  onClick = (t, map, coord) => {
      const { latLng } = coord;
      const lat = latLng.lat();
      const lng = latLng.lng();

      this.setState(() => {
        return {
          pointOfIntMarker: {
              title: "",
              name: "",
              position: { lat, lng }
            }
          };
      });
      this.props.addPoint(lat, lng)
  }

  onMarkerClick = async (event) => {
    const { lat, lng } = event.position;
    const addrr = await getAddressByCoords(lat, lng);
    this.props.onDestClick(lat, lng, addrr);
  }
  
  render() {
    const { lat, lng } = this.props.userLocation;
    console.log('Map-> routes: ', this.props.routes)
    return (
        <Map 
          google={this.props.google}
          containerStyle={mapStyle}
          gestureHandling='cooperative'
          initialCenter={{ lat: lat, lng: lng }}
          center={{ lat: lat, lng: lng }}
          zoom={16}
          onClick={this.onClick}
          >
          <Marker
            name={'Current location'}
            position={{ lat: lat, lng: lng }}
            onClick={(event) => this.onMarkerClick(event)}
          />  
            <Marker
              title={this.state.pointOfIntMarker.title}
              name={this.state.pointOfIntMarker.name}
              position={this.state.pointOfIntMarker.position}
              onClick={(event) => this.onMarkerClick(event)}
            />
          <InfoWindow onClose={this.onInfoWindowClose}>
              <div>
                {/* <h1>{this.state.selectedPlace.name}</h1> */}
              </div>
          </InfoWindow>
        </Map>
    );
  }
}
 
export default GoogleApiWrapper({
  apiKey: ('AIzaSyCFIiFXUc2AM1SaUU8cbsShdoY1NAiH8_s') //apiKey creation: Dec 17, 2019
})(MapContainer)