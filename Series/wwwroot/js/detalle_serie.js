(async function () {
    // Pregunto si dentro de mi sesion tengo un usuario
    const userInSession = getUserInSession();
    // Si existe hago una redireccion a autenticacion_cliente
    if (!userInSession) {
        window.location.href = 'index.html';
        return;
    }
    document.body.style.display = "block";

    const urlParams = new URLSearchParams(window.location.search);
    const serieId = urlParams.get("id");

    await cargarDatosSeries(serieId);


    // Un evento para el boton de salir 
    document.querySelector("#btn_salir").addEventListener("click", function (e) {
        // en el caso de que el elemento sea "a" es para evitar que vaya a una direccion de enlace
        e.preventDefault();
        salir();
    });

    
    document.querySelector("#btn_catalogo").addEventListener("click", function (e) {
        e.preventDefault();
        // en el caso de que el elemento sea "a" es para evitar que vaya a una direccion de enlace
        window.location.href = 'catalogo_series.html';
    });
    // Un evento para el boton de ingresar
    //document.querySelector("#btn-login").addEventListener("click", login);
})(); // Primero se declara la funcion y al final se ejecuta

async function cargarDatosSeries(serieId) {
    const response = await fetch(`api/series/${serieId}`);
    console.log(response);
    if (!response.ok) {
        alert("Error al cargar el contacto");
        return;
    } else {
        console.log("todo bien");
        console.log(response.json());
    }

    const serie = await response.json();
    cargarDatosSeries(serie);
}

function cargarDatosSeries(serie) {
    console.log(titulo);
    console.log(descripcion);
    console.log(serie);
    const miniatura = document.querySelector("#miniatura");
    const tituloSerie = document.querySelector("#titulo");
    const descripcionSerie = document.querySelector("#descripcion");
    let titulo = serie.nombreSerie
    let descripcion = serie.descripcion
    tituloSerie.innerHTML = titulo;
    descripcionSerie.innerHTML = descripcion;
}