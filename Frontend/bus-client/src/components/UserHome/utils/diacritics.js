const removeDiacritics = (word) => {
    const diacritics = ['ă', 'î', 'â', 'ș', 'ț'];
    const replacers = ['a', 'i', 'a', 's', 't'];
    diacritics.forEach((_, index) => {
        word = word.replace(diacritics[index], replacers[index]);
    });
    return word;
}

export default removeDiacritics;