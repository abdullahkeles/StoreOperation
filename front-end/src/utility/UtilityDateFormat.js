const utilityDateFormat = {
    toLocaleDateString(_date) {
        const dt = new Date(_date);
        const options = {weekday: 'long', year: 'numeric', month: 'long', day: 'numeric'};
        return dt.toLocaleDateString('tr-TR', options);
    }
}

export default utilityDateFormat