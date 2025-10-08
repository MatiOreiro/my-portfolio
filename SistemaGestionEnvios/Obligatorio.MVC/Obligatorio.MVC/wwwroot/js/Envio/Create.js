document.querySelector("#Dto_TipoEnvio").addEventListener('change', MostrarDatosPropiosDelTipoEnvio);
MostrarDatosPropiosDelTipoEnvio();


function MostrarDatosPropiosDelTipoEnvio() {

    let tipoSel = document.querySelector("#Dto_TipoEnvio").value;
    console.log(tipoSel);

    if (tipoSel == "comun") {
        document.querySelector("#opcionesUrgente").style.display = "none";
        document.querySelector("#opcionesComun").style.display = "block";
    } else {
        document.querySelector("#opcionesUrgente").style.display = "block";
        document.querySelector("#opcionesComun").style.display = "none";
    }

}