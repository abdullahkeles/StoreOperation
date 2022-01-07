const utilitySate = {
    toString(state) {
        return state ? "Aktif" : "Pasif";
    },
    toColorString(state) {
        console.log(state)
        if (state){
            return 'success'
        }else{
            return 'grey'
        }
    }
}

export default utilitySate