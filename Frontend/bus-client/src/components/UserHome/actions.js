import axios from 'axios';
import Geocode from "react-geocode";
import removeDiacritics from './utils/diacritics';
import config from '../../config/index';


Geocode.setApiKey("AIzaSyCdQ25z8fj5hfTRMONCWin8zY08ZRuFQC0");
Geocode.setLanguage("en");
Geocode.setRegion("ro");
// Geocode.enableDebug();

export const getCityNameByCoords = (lat, lng) => {
    return Geocode.fromLatLng(lat, lng)
        .then(response => {
            try {
                let cityName = response.results[0].address_components[2].long_name;
                cityName = removeDiacritics(cityName);
                return cityName;
            } catch (err) {
                console.log('Failed to get the city name!', err)
                return 'UndefinedCity';
            }
        });
}

export const getAddressByCoords = (lat, lng) => {
    return Geocode.fromLatLng(lat, lng)
        .then((response) => {
            const address = response.results[0].formatted_address;
            return address;
        }, err => { console.error('getAddressByCoords', err);
  });
}

export const getUserCurrentLocation = async (callBackUpdate) => {
    return new Promise(function (resolve, reject) {
        callBackUpdate(47.1419182, 27.5841246, 'Iasi');
        axios.post("https://www.googleapis.com/geolocation/v1/geolocate?key=AIzaSyCdQ25z8fj5hfTRMONCWin8zY08ZRuFQC0")
            .then(response => {
                const { lat, lng } = response.data.location;
                Geocode.fromLatLng(lat, lng)
                    .then(response => {
                        try {
                            let cityName = response.results[0].address_components[2].long_name;
                            cityName = removeDiacritics(cityName);
                            callBackUpdate(lat, lng, cityName);
                        } catch (err) {
                            console.log('Failed to get the city name!', err)
                            callBackUpdate(0, 0, 'UndefinedCity')
                        }
                    });
            });
    });
}

export const getPointsOfInterestByCityName = async (cityName) => {
    return axios.get(`${config.serverURL}/PointOfInterest/${cityName}`)
        .then((response) => {
            if(response.status === 200 && response.data) { 
                return response.data;
            }
            return false;
        })
        .catch((err) => {
            console.log('getPointsOfInterestByCityName', err);
            return false;
        });
}

export const addPointOfInterest = async (data) => {
    return axios.post(`${config.serverURL}/PointOfInterest`, data)
        .then((response) => {
            if(response.data) { 
                return response.data;
            }
            return false;
        })
        .catch((err) => {
            console.log('addPointOfInterest', err);
            return false;
        });
}

export const deletePointOfInterest = async (id) => {
    return axios.delete(`${config.serverURL}/PointOfInterest/${id}`)
        .then((response) => {
            if(response.data) { 
                return response.data;
            }
            return false;
        })
        .catch((err) => {
            console.log('deletePointOfInterest', err);
            return false;
        });
}

export const getCityRoutes = (startcoordonates, endcoordonates, cityName) => {
    return axios(`${config.serverURL}/Cities/${startcoordonates.replace('.',',')}/${endcoordonates.replace('.',',')}/${cityName}`)
        .then((response) => {
            if(response.data) { 
                console.log(response.data, 'dasd')
                return response.data;
            }
            return false;
        })
        .catch((err) => {
            console.log('getCityRoutes', err);
            return false;
        });
}