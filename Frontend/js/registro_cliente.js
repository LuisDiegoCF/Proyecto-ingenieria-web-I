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
    document.querySelector("#btn_aceptar").addEventListener("click", saveUser); 
    document.querySelector("#btn_iniciarS").addEventListener("click", login);
})(); // Primero se declara la funcion y al final se e

function login(e) {
    e.preventDefault();
    window.location.href = 'autenticacion_cliente.html';
}

async function saveUser(e) {
    e.preventDefault();
    const nombreCompleto = document.querySelector("#inputNombres").value;
    const userName = document.querySelector("#inputUser").value;
    const password = document.querySelector("#inputPassword").value.trim();


    const validacionNombre = document.querySelector("#validation-nombre");
    const validacionUser = document.querySelector("#validation-user");
    const validationpassword = document.querySelector("#validation-password");

    const validationUserName = document.querySelector("#validation-userName");

    let hasError = false;
    if (nombreCompleto === "") {
        hasError = true;
        validacionNombre.style.display = "block";
    } else {
        validacionNombre.style.display = "none";
    }
    if (userName === "") {
        hasError = true;
        validacionUser.style.display = "block";
    } else {
        validacionUser.style.display = "none";
    }
    if (password === "") {
        hasError = true;
        validationpassword.style.display = "block";
    } else {
        validationpassword.style.display = "none";
    }
    if (hasError) {
        return;
    }

    // genero el usuario, construyo el json
    const newUser = {
        "NombreCompleto": nombreCompleto,
        "UserName": userName,
        "Password": password,
        "TipoUsuario": "cliente"
    }

    // try para la operacion de obtener el login del usuario
    try {
        // Obtengo la respuesta a partir del fetch, adicional le paso un json donde el metodo es:
        const response = await fetch("api/registro", {
            // Metodo POST
            "method": "POST",
            // que maneje el tema de la trandformacion en json, basicamente "envia en json y recibi en json"
            headers: {
                "Accept": "application/json",
                "Content-Type": 'application/json'
            },
            // el cuerpo de la peticion es "userRequest" necesitaria convertirlo a string
            body: JSON.stringify(newUser)
        });
        // Si la respuesta == ok la puedo procesar

        if (!response.ok) {
            validationUserName.style.display = "block";
            Console.log(response.error);
        } else {
            validationUserName.style.display = "none";
        }

        const data = await response.json();
        if (!data) {
            Console.log(response.error);
        }
        window.location.href = "autenticacion_cliente.html?msg=ok_user_saved";
    } catch (ex) {
        console.error(ex);
    }
}