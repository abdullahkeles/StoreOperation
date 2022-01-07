const LocalStorageHelper = {

    //object is expected
    setLocalStorage(params) {
        for (const [key, value] of Object.entries(params)) {
            localStorage.setItem(key, value)
        }
    },
    //array is expected
    removeLocalStorage(params) {
        for (const [key] of Object.entries(params)) {
            localStorage.removeItem(key)
        }
    }
}

export default LocalStorageHelper