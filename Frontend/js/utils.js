// obtengo el usuario en sesion
function getUserInSession() {
    const userInSession = localStorage.getItem('userInSession');
    if (!userInSession)
        return null;
    let user = null;
    try {
        user = JSON.parse(userInSession);
    } catch (e) {
        console.error("Error al obtener el usuario")
    }
    return user;
}

// mando el usuario en sesion al local storage
function setUserInSession(user) {
    if (user) {
        // si existe lo agrego
        // userInSession nombre del valor a guardar en el localstorage, json convertido a string para poder guardar en dentro del local storage
        localStorage.setItem('userInSession', JSON.stringify(user));
    } else {
        // si no existe lo voy a borrar
        localStorage.removeItem('userInSession');
    }

}

// elimino el usuario en sesion del localstorage
function salir() {
    setUserInSession(null);
    window.location.href = "index.html";
}