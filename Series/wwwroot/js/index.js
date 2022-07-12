(function () {
    // Pregunto si dentro de mi sesion tengo un usuario
    const userInSession = getUserInSession();
    // Si existe hago una redireccion a autenticacion_cliente
    if (userInSession) {
        window.location.href = 'catalogo_series.html';
        return;
    }
    document.body.style.display = "block";

    // Un evento para el boton de ingresar
    document.querySelector("#btn_sesion").addEventListener("click", login);
    document.querySelector("#btn_suscripcion").addEventListener("click", suscribir);
})(); // Primero se declara la funcion y al final se ejecuta

function login(e) {
    e.preventDefault();
    window.location.href = 'autenticacion_cliente.html';
}

function suscribir(e) {
    e.preventDefault();
    window.location.href = 'registro_cliente.html';
}