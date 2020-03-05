import axios from 'axios';
import config from '../../../config/index';

const registerPerson = async (body) => {
    return axios.post(`${config.serverURL}/Person`, body)
        .then((response) => {
            if(response.status === 201 && response.data){ return true; }
            return false;
        })
        .catch((err) => {
            console.log('registerPerson', err);
            return false;
        });
}

export default registerPerson;