// set/unset person id into browser localStorage
const localItem = 'smartCityPersonId';

const setPersonId = (id) => {
    localStorage.setItem(localItem, id);
}

const getPersonId = () => {
    return localStorage.getItem(localItem);
}

const delPersonId = () => {
    localStorage.removeItem(localItem);
}

module.exports = {
    setPersonId,
    getPersonId,
    delPersonId,
};
