(async function () {
    // Pregunto si dentro de mi sesion tengo un usuario
    const userInSession = getUserInSession();
    // Si existe hago una redireccion a autenticacion_cliente
    if (!userInSession) {
        window.location.href = 'index.html';
        return;
    }
    document.body.style.display = "block";



    // Un evento para el boton de salir 
    document.querySelector("#btn_salir").addEventListener("click", function (e) {
        // en el caso de que el elemento sea "a" es para evitar que vaya a una direccion de enlace
        e.preventDefault();
        salir();
    });

    document.querySelector("#btn_favoritos").addEventListener("click", function (e) {
        // en el caso de que el elemento sea "a" es para evitar que vaya a una direccion de enlace
        e.preventDefault();
        cargarSeriesFavoritas();
    });

    await cargarSeries();
})(); // Primero se declara la funcion y al final se e

async function saveSerie() {

}

async function cargarSeriesFavoritas() {

}

async function cargarSeries() {
    const response = await fetch(`/api/series`);
    if (!response.ok) {
        return;
    }

    const listOfSeries = await response.json();
    mostrarSeries(listOfSeries);

}

function mostrarSeries(listOfSeries) {
    const seriesHtml = document.getElementById("lista_series");
    if (listOfSeries.length === 0) {
        seriesHtml.innerHTML =
            `<div style="color:red";>
                Oops no se encontraron series.
            </div>`;
        return;
    }
    let html = "";
    for (let i in listOfSeries) {
        const obj = listOfSeries[i];
        html += getSeriesInHtml(obj);
    }
    seriesHtml.innerHTML = html;
}

function getSeriesInHtml(obj) {
    return `<div class="item__serie">
                <a href="detalle_serie.html?id=${obj.serieId}">
                    <img class="img__serie" src="./img/jurassic/fondo.jpg" alt="">
                    <h3 class="titulo__serie">${obj.nombreSerie}</h3>
                 </a>
           </div>`
}