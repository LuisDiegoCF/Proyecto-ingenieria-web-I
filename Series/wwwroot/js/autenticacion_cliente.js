(function () {
    // Pregunto si dentro de mi sesion tengo un usuario
    const userInSession = getUserInSession();
    // Si existe hago una redireccion a autenticacion_cliente
    if (userInSession) {
        window.location.href = 'catalogo_series.html';
        return;
    }

    document.body.style.display = "block";

    const urlParams = new URLSearchParams(window.location.search);
    const msg = urlParams.get("msg");
    if (msg && msg === "ok_user_saved") {
        document.getElementById("ok_user_saved").style.display = "block";
        setTimeout(() => {
            document.getElementById("ok_user_saved").style.display = "none";
        }, 3000)
    }

    // Un evento para el boton de ingresar
    document.querySelector("#btn-login").addEventListener("click", login);
})(); // Primero se declara la funcion y al final se ejecuta

async function login(e) {
    // Cuando hago login agrego al localstorage
    e.preventDefault();

    // accedo a los elementos del formulario
    const inputUserName = document.querySelector("#inputUsername");
    const inputPassword = document.querySelector("#inputPassword");

    const validationUserName = document.querySelector("#validation-username");
    const validationPassword = document.querySelector("#validation-password");
    const msgLogin = document.querySelector("#msg-error-login");
    msgLogin.style.display = "none"

    // Hacemos las validaciones correspondientes
    let hasError = false;

    if (inputUserName.value.trim() === "") {
        hasError = true;
        validationUserName.style.display = "block";
    } else {
        validationUserName.style.display = "none";
    }

    if (inputPassword.value.trim() === "") {
        hasError = true;
        validationPassword.style.display = "block";
    } else {
        validationPassword.style.display = "none";
    }
    // Si existe un error entonces no puedo continuar, entonces return = no continuo mas
    if (hasError) {
        return;
    }

    // Construyo el json con los datos que corresponde, este es el usuario userInput
    const userRequest = {
        "UserName": inputUserName.value,
        "Password": inputPassword.value,
        "TipoUsuario": "cliente"
    }
    // try para la operacion de obtener el login del usuario
    try {
        // Obtengo la respuesta a partir del fetch, adicional le paso un json donde el metodo es:
        const response = await fetch("api/usuario/autenticacion_cliente", {
            // Metodo POST
            "method": "POST",
            // que maneje el tema de la trandformacion en json, basicamente "envia en json y recibi en json"
            headers: {
                "Accept": "application/json",
                "Content-Type": 'application/json'
            },
            // el cuerpo de la peticion es "userRequest" necesitaria convertirlo a string
            body: JSON.stringify(userRequest)
        });
        // Si la respuesta == ok la puedo procesar
        if (response.ok) {
            // Dame esa respuesta del servidor que trajiste del JSON, esto es await el metodo tiene que ser una funcion async
            const userInSession = await response.json();
            setUserInSession(userInSession);
            //console.log(userInSession.tipoUsuario);
            if (userInSession.tipoUsuario == 'administrador') {
                window.location.href = 'admin_catalogo.html';
            } else {
                console.log("Entre a detalle de la serie");
                console.log(userInSession.TipoUsuario);
                window.location.href = 'catalogo_series.html';
            }
        } else {
            msgLogin.style.display = "block"
        }
    } catch (ex) {
        console.error(ex);
    }

}
