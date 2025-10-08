window.addEventListener("load", inicio);

let sistema = new Sistema();
sistema.precargaDeDatos();

function inicio(){
    document.querySelector("#btnIniciarSesion").addEventListener("click", realizarInicioSesion);
    document.querySelector("#btnCerrarSesion").addEventListener("click", realizarCierreDeSesion);
    document.querySelector("#btnCerrarSesionAdministrador").addEventListener("click", realizarCierreDeSesion);
    document.querySelector("#btnRegistro").addEventListener("click", realizarRegistro);
    document.querySelector("#selectProductosDisponibles").addEventListener("change", actualizarMuestraDeProducto);
    document.querySelector("#btnComprarProducto").addEventListener("click", comprar);
    document.querySelector("#checkProdEnOferta").addEventListener("click", actualizarSelectDeProductos);
    document.querySelector("#checkProdEnOferta").addEventListener("click", actualizarMuestraDeProducto);
    document.querySelector("#radioFiltrarMisComprasTodas").addEventListener("click", actualizarTablaMisCompras);
    document.querySelector("#radioFiltrarMisComprasAprobadas").addEventListener("click", actualizarTablaMisCompras);
    document.querySelector("#radioFiltrarMisComprasPendientes").addEventListener("click", actualizarTablaMisCompras);
    document.querySelector("#radioFiltrarMisComprasCanceladas").addEventListener("click", actualizarTablaMisCompras);
    document.querySelector("#radioFiltrarComprasDeUsuarioTodas").addEventListener("click", actualizarTablaComprasDeUsuario);
    document.querySelector("#radioFiltrarComprasDeUsuarioAprobadas").addEventListener("click", actualizarTablaComprasDeUsuario);
    document.querySelector("#radioFiltrarComprasDeUsuarioPendientes").addEventListener("click", actualizarTablaComprasDeUsuario);
    document.querySelector("#radioFiltrarComprasDeUsuarioCanceladas").addEventListener("click", actualizarTablaComprasDeUsuario);
    document.querySelector("#btnCrearProducto").addEventListener("click", validarCreacionDeNuevoProducto);
}

//Inicio/cierre de sesion, registro y validaciones
function realizarInicioSesion(){
    let userName = document.querySelector("#userName").value;
    let password = document.querySelector("#password").value;

    if(sistema.validarInicioSesionUsuario(userName, password)){
        actualizarComprador();
        mostrarYOcultarPanel("#sectionComprador");
    }else if(sistema.validarInicioSesionAdministrador(userName, password)){
        actualizarAdministrador();
        mostrarYOcultarPanel("#sectionAdministrador");
    }else{
        alert("No se encontraron los datos")
    }

    document.querySelector("#formIniciarSesion").reset();
}

function realizarCierreDeSesion(){
    sistema.cierreDeSesion();
    reestablecerInputs();
    mostrarYOcultarPanel("#sectionInicial");
}

function realizarRegistro(){
    let nombre = document.querySelector("#registroDeNombre").value;
    let apellido = document.querySelector("#registroDeApellido").value;
    let userName = document.querySelector("#registroDeUserName").value;
    let password = document.querySelector("#registroDeContraseña").value;
    let numeroDeTarjeta = document.querySelector("#registroDeNumeroDeTarjeta").value;
    let cvc = parseInt(document.querySelector("#registroDeCVC").value);
    let tarjetaSinGuiones = numeroDeTarjeta.replaceAll("-", "");

    if(nombre == "" || apellido == "" || userName == "" || password == "" || numeroDeTarjeta == "" || cvc == ""){
        alert("Todos los campos son obligatorios")
    }else if(sistema.existeComprador(userName) || sistema.existeAdministrador(userName)){
        alert("Error, vuelva a verificar los datos")
    }else if(!passwordValida(password)){
        let errores = "";
        errores += "La contraseña tiene que tener al menos 5 caracteres. <br>"
        errores += "La contraseña debe tener mínimo una mayuscúla. <br>"
        errores += "La contraseña debe tener mínimo una minúscula. <br>"
        errores += "La contraseña debe tener mínimo un número. <br>"
        document.querySelector("#pContraseniaValida").innerHTML = errores;
    }else if(!numeroDeTarjetaValida(numeroDeTarjeta)){
        alert("La tarjeta no es válida");
    }else if(!algoritmoLuhn(tarjetaSinGuiones)){
        alert("La tarjeta no se pudo verificar.");
    }else if(cvc < 100 || cvc > 999){
        alert("Ingrese un CVC válido");
    }else{
        sistema.agregarComprador(nombre, apellido, userName, password, numeroDeTarjeta, cvc);
        document.querySelector("#formRegistrar").reset();
        alert("Registro con exito")
    }
    
}

function passwordValida(password){
    let resp = false;
    let cantMayus = 0;
    let cantMinus = 0;
    let cantNumeros = 0;

    for (let i = 0; i < password.length; i++) {
        if(password.charCodeAt(i) >= 65 && password.charCodeAt(i) <= 90){
            cantMayus++;
        }else if(password.charCodeAt(i) >= 97 && password.charCodeAt(i) <= 122){
            cantMinus++;
        }else if(password.charCodeAt(i) >= 48 && password.charCodeAt(i) <= 57){
            cantNumeros++;
        }
    }

    
    if(!(password.length < 5 || cantMayus < 1 || cantMinus < 1 || cantNumeros < 1)){
        resp = true;
    }

    return resp;
}

function numeroDeTarjetaValida(numeroDeTarjeta){
    let valida = false;
    let cantNumeros = 0;
    let cantGuiones = 0;

    for (let i = 0; i < numeroDeTarjeta.length; i++) {
        if(numeroDeTarjeta.charCodeAt(i) >= 48 && numeroDeTarjeta.charCodeAt(i) <= 57){
            cantNumeros++
        }else if(numeroDeTarjeta.charAt(i) == "-"){
            cantGuiones++;
        }
    }

    if(!(numeroDeTarjeta.length != 19 || cantNumeros != 16 || cantGuiones != 3)){
        valida = true;
    }

    return valida;
}

function validarCreacionDeNuevoProducto(){
    let nombre = document.querySelector("#nombreCrearProducto").value;
    let valuePrecio = document.querySelector("#precioCrearProducto").value;
    valuePrecio = valuePrecio.replaceAll(",", ".");
    let precio = parseFloat(valuePrecio);
    let descripcion = document.querySelector("#descripcionCrearProducto").value;
    let img = document.querySelector("#imagenCrearProducto").value;
    let stock = parseInt(document.querySelector("#stockCrearProducto").value);
    let texto = ""; 

    if(isNaN(precio) || isNaN(stock) || nombre.length == 0 || descripcion.length == 0  || img.length == 0  ){
        texto += "Todos los campos son obligatorios";
    }else if(precio <= 0 || stock <= 0){
        texto += "El precio y el stock deben ser mayores a 0";
    }else{
        sistema.agregarProducto(nombre, precio, descripcion, img, stock);
        document.querySelector("#formCrearProducto").reset();
        alert("Producto creado con éxito")
        texto = "";
    }

    document.querySelector("#pErroresCrearProducto").innerHTML = texto;
    mostrarTablaDeTodosLosProductos();
}

//Actualizar usuario
function actualizarComprador(){
    actualizarSelectDeProductos();
    actualizarMuestraDeProducto();
    actualizarTablaMisCompras();
    mostrarSaldo();
    mostrarMontoDeComprasAprobadas();
}

function actualizarSelectDeProductos(){
    let productos = sistema.obtenerListadoDeProductos();
    let texto = "";
    if(document.querySelector("#checkProdEnOferta").checked ){
        for (let i = 0; i < productos.length; i++) {
            let objProducto = productos[i];
            if(objProducto.oferta){
                texto += `<option value="${objProducto.id}">${objProducto.nombre} - $${objProducto.precio} - En oferta</option>`
            }
        }
        
    }else{
        for (let i = 0; i < productos.length; i++) {
            let objProducto = productos[i];
            if(objProducto.oferta == true){
                texto += `<option value="${objProducto.id}">${objProducto.nombre} - $${objProducto.precio} - En oferta</option>`
            }else{
                texto += `<option value="${objProducto.id}">${objProducto.nombre} - $${objProducto.precio}</option>`
            }
        }
    }
    actualizarMuestraDeProducto();
    document.querySelector("#selectProductosDisponibles").innerHTML = texto;
}

function actualizarMuestraDeProducto(){
    let producto = document.querySelector("#selectProductosDisponibles").value;
    let lista = sistema.obtenerListadoDeProductos();
    let texto = "";
    for (let i = 0; i < lista.length; i++) {
        let objProducto = lista[i];
        if(producto == objProducto.id){
            texto = `<h3>${objProducto.nombre}</h3>
                        <img src="${objProducto.imagen}" alt="Imagen del producto">
                        <p>${objProducto.descripcion}</p>
                        <p>Precio unitario: $${objProducto.precio}</p>`
        }
    }
    document.querySelector("#muestraDelProductoSeleccionado").innerHTML = texto;
}

function actualizarTablaMisCompras(){
    let lista;
    if(document.querySelector("#radioFiltrarMisComprasTodas").checked){
        lista = sistema.obtenerMisCompras("Todas");
    }else if(document.querySelector("#radioFiltrarMisComprasAprobadas").checked){
        lista = sistema.obtenerMisCompras("Aprobada");
    }else if(document.querySelector("#radioFiltrarMisComprasPendientes").checked){
        lista = sistema.obtenerMisCompras("Pendiente");
    }else if(document.querySelector("#radioFiltrarMisComprasCanceladas").checked){
        lista = sistema.obtenerMisCompras("Cancelada");
    }

    mostrarTabla(lista);
}

function mostrarSaldo(){
    document.querySelector("#parrafoSaldoDelComprador").innerHTML = `Su saldo actual es de $${sistema.obtenerSaldoComprador().toFixed(2)}`;
}

function mostrarMontoDeComprasAprobadas(){
    document.querySelector("#parrafoDeComprasAprobadas").innerHTML = `Monto total de compras aprobadas: $${sistema.calcularMontoDeComprasAprobadas().toFixed(2)}.`
}

// Actualizar administrador

function actualizarAdministrador(){
    actualizarTablaComprasDeUsuario();
    mostrarTablaDeTodosLosProductos();
    mostrarInformeDeGanancias();
}

function actualizarTablaComprasDeUsuario(){
    let lista;
    if(document.querySelector("#radioFiltrarComprasDeUsuarioTodas").checked){
        lista = sistema.obtenerListadoDeCompras();
    }else if(document.querySelector("#radioFiltrarComprasDeUsuarioAprobadas").checked){
        lista = sistema.obtenerComprasDeUsuario("Aprobada");
    }else if(document.querySelector("#radioFiltrarComprasDeUsuarioPendientes").checked){
        lista = sistema.obtenerComprasDeUsuario("Pendiente");
    }else if(document.querySelector("#radioFiltrarComprasDeUsuarioCanceladas").checked){
        lista = sistema.obtenerComprasDeUsuario("Cancelada");
    }

    mostrarTablaDeAdministrador(lista);
}

function mostrarTablaDeTodosLosProductos(){
    let texto = "";

    for (let i = 0; i < sistema.listaDeProductos.length; i++) {
        let objProducto = sistema.listaDeProductos[i];
        texto += `<tr>
                    <td>${objProducto.nombre}</td>
                    <td>${objProducto.precio.toFixed(2)}</td>
                    <td>${objProducto.stock}</td>
                    <td><input type="number" id="${objProducto.id}-stockProducto" class="stock"><input type="button" value="Modificar" id="${objProducto.id}" class="modificarStock"></td>
        `
        if(objProducto.estado){
            texto += `<td>Activo</td>`
            texto += `<td><input type="button" value="Pausar" id="${objProducto.id}-estadoProducto" class="pausar"></td>`

        }else{
            texto += `<td>Pausado</td>`
            texto += `<td><input type="button" value="Activar" id="${objProducto.id}-estadoProducto" class="activar"></td>`

        }
        if(objProducto.oferta){
            texto += `<td>Si</td>`
            texto += `<td><input type="button" value="Quitar oferta" id="${objProducto.id}-ofertaProducto" class="quitarOferta"></td>`
        }else{
            texto += `<td>No</td>`
            texto += `<td><input type="button" value="Agregar oferta" id="${objProducto.id}-ofertaProducto" class="agregarOferta"></td>`
        }
    }
    document.querySelector("#tablaDeTodosLosProductos").innerHTML = texto;
    let listaDeBotonesParaModificarStock = document.querySelectorAll(".modificarStock");
    for (let i = 0; i < listaDeBotonesParaModificarStock.length; i++) {
        let botonActual = listaDeBotonesParaModificarStock[i];
        botonActual.addEventListener("click", modificarStockDinamico)
    }
    let listaDeBotonesParaPausarEstado = document.querySelectorAll(".pausar");
    for (let i = 0; i < listaDeBotonesParaPausarEstado.length; i++) {
        let botonActual = listaDeBotonesParaPausarEstado[i];
        botonActual.addEventListener("click", pausarEstadoDinamico)
    }
    let listaDeBotonesParaActivarEstado = document.querySelectorAll(".activar");
    for (let i = 0; i < listaDeBotonesParaActivarEstado.length; i++) {
        let botonActual = listaDeBotonesParaActivarEstado[i];
        botonActual.addEventListener("click", activarEstadoDinamico)
    }
    let listaDeBotonesParaAgregarOferta = document.querySelectorAll(".agregarOferta");
    for (let i = 0; i < listaDeBotonesParaAgregarOferta.length; i++) {
        let botonActual = listaDeBotonesParaAgregarOferta[i];
        botonActual.addEventListener("click", agregarOfertaDinamico)
    }
    let listaDeBotonesParaQuitarOferta = document.querySelectorAll(".quitarOferta");
    for (let i = 0; i < listaDeBotonesParaQuitarOferta.length; i++) {
        let botonActual = listaDeBotonesParaQuitarOferta[i];
        botonActual.addEventListener("click", quitarOfertaDinamico)
    }   
}

function mostrarInformeDeGanancias(){
    let texto = "";
    let listaDeProductos = sistema.obtenerListadoDeTodosLosProductos()

    for (let i = 0; i < listaDeProductos.length; i++) {
        let objProducto = listaDeProductos[i];
        if(objProducto.cantidadDeVendidos > 0){
            texto += `Se ha vendido ${objProducto.cantidadDeVendidos} de ${objProducto.nombre} <br>`;
        }
        
    }
    

    texto += `<strong>Ganancias totales:</strong> $${sistema.obtenerMontoTotalDeComprasAprobadas().toFixed(2)}`;
    document.querySelector("#pInformeDeGanancias").innerHTML = texto;
}



// funcionalidades
function comprar(){
    let idProducto = document.querySelector("#selectProductosDisponibles").value;
    let cantidad = parseInt(document.querySelector("#cantProducto").value);

    if(isNaN(cantidad) || cantidad <= 0){
        alert("Debe ingresar una cantidad")
    }else{
        sistema.comprarProducto(idProducto, cantidad);
        actualizarComprador();
        alert("Compra realizada exitosamente, aguarde a que un administrador la apruebe.");
    }
}

function cancelarCompraDinamico(){
    let id = parseInt(this.id);
    sistema.cancelarCompra(id);
    actualizarTablaMisCompras();
}

function aprobarCompraDinamico(){
    let id = parseInt(this.id);
    sistema.procesarCompra(id);
    actualizarTablaComprasDeUsuario();
    mostrarTablaDeTodosLosProductos(); 
    mostrarInformeDeGanancias();
}

function modificarStockDinamico(){
    let id = this.id
    let cantidad = parseInt(document.querySelector(`#${this.id}-stockProducto`).value);
    if(isNaN(cantidad) || cantidad < 0){
        alert("Debe ingresar un valor válido de stock")
    }else{
        sistema.actualizarStock(id, cantidad);
    }
    mostrarTablaDeTodosLosProductos();
}

function pausarEstadoDinamico(){
    let id = this.id
    let idProducto = id.substring(0, id.indexOf("-"))
    sistema.modificarEstado(idProducto);
    mostrarTablaDeTodosLosProductos();
}

function activarEstadoDinamico(){
    let id = this.id
    let idProducto = id.substring(0, id.indexOf("-"))
    sistema.modificarEstado(idProducto);
    mostrarTablaDeTodosLosProductos();
}

function agregarOfertaDinamico(){
    let id = this.id
    let idProducto = id.substring(0, id.indexOf("-"))
    sistema.modificarOferta(idProducto);
    mostrarTablaDeTodosLosProductos();
}

function quitarOfertaDinamico(){
    let id = this.id
    let idProducto = id.substring(0, id.indexOf("-"))
    sistema.modificarOferta(idProducto);
    mostrarTablaDeTodosLosProductos();
}

// Mostrar datos
function mostrarTabla(lista){
    let texto = "";
    
    for (let i = 0; i < lista.length; i++) {
        let objCompra = lista[i];
        texto += `<tr>
                        <td>${objCompra.producto.nombre}</td>
                        <td>$${objCompra.montoTotal().toFixed(2)}</td>
                        <td>${objCompra.cantidad}</td>
                        <td>${objCompra.estado}</td>`
        if(objCompra.estado === "Pendiente"){
            texto += `<td><input type="button" value="Cancelar" id="${objCompra.id}-estadoCompra" class="cancelar"></td>`
        }
        
    }
    document.querySelector("#tablaDeMisCompras").innerHTML = texto;

    let listaDeBotonesParaCancelar = document.querySelectorAll(".cancelar");
    for (let i = 0; i < listaDeBotonesParaCancelar.length; i++) {
        let botonActual = listaDeBotonesParaCancelar[i];
        botonActual.addEventListener("click", cancelarCompraDinamico);
    }
}

function mostrarTablaDeAdministrador(lista){
    let texto = "";
    
    for (let i = 0; i < lista.length; i++) {
        let objCompra = lista[i];
        texto += `<tr>
                        <td>${objCompra.comprador.userName}</td>
                        <td>${objCompra.producto.nombre}</td>
                        <td>$${objCompra.montoTotal().toFixed(2)}</td>
                        <td>${objCompra.cantidad}</td>
                        <td>${objCompra.estado}</td>`
        if(objCompra.estado === "Pendiente"){
            texto += `<td><input type="button" value="Aprobar" id="${objCompra.id}-estadoCompra" class="aprobar"></td>`
        }
        
    }
    document.querySelector("#tablaDeComprasDeUsuarios").innerHTML = texto;

    let listaDeBotonesParaAprobar = document.querySelectorAll(".aprobar");
    for (let i = 0; i < listaDeBotonesParaAprobar.length; i++) {
        let botonActual = listaDeBotonesParaAprobar[i];
        botonActual.addEventListener("click", aprobarCompraDinamico);
    }
}

function reestablecerInputs(){
    document.querySelector("#checkProdEnOferta").checked = false;
    document.querySelector("#cantProducto").value = "";
    document.querySelector("#radioFiltrarMisComprasTodas").checked = true;
    document.querySelector("#radioFiltrarComprasDeUsuarioTodas").checked = true;
}

function mostrarYOcultarPanel(idPanel) {
    document.querySelector("#sectionInicial").style.display = "none";
    document.querySelector("#sectionComprador").style.display = "none";
    document.querySelector("#sectionAdministrador").style.display = "none";
    document.querySelector(idPanel).style.display = "block";
}

// Algoritmo de Luhn

function algoritmoLuhn(pNumero) {
  /*Se estara iterando numero a numero, desde el final del string hasta el primer caracter, se estarán
    sumando y sustituyendo por duplicado cuando sea par, ya que sería el segundo nro. */
  let suma = 0;
  let digitoVerificadorX = Number(pNumero.charAt(pNumero.length - 1));
  let contador = 0; //para saber cuando estamos en los segundos, lo pares.
  let haynro = true;
  let i = pNumero.length - 2; //el penúltimo.


  //Mientras los numeros sea mayor o igual a 0 se estara tomando cada caracter
  while (i >= 0 && haynro) {
    //Obtener el numero
    let caracter = pNumero.charAt(i);
    //Valida que el número sea válido
    if (!isNaN(caracter)) {
      let num = Number(caracter);
      //Duplicando cada segundo dígito
      if (contador % 2 == 0) {
        num = duplicarPar(num); //porque si es mayor a 9 se deben sumar.
      }
      suma += num;
    } else {
      haynro = false;
    }
    i--;
    contador++;
  }
  let digitoVerificadorValido = checkDigito(suma, digitoVerificadorX);
  let modulodelasumaValiado = checkModulo(suma, digitoVerificadorX);
  return digitoVerificadorValido && modulodelasumaValiado;

}

function duplicarPar(pNum) {
  pNum = pNum * 2;
  if (pNum > 9) {
    /*Si el resultado del multiplicación es mayor a 9 entonces lo descomponemos y sumamos. 
     Como el numero sera x>=10 && x<=19
     Entonces es 1+(num % 10) 1 más el resto de dividir entre 10.*/
    pNum = 1 + (pNum % 10);
  }
  return pNum;
}

function checkDigito(pSuma, pDigito) {
  /* 1. Calcular la suma de los dígitos (67).
2. Multiplicar por 9 (603).
3. Tomar el último dígito (3).
4. El resultado es el dígito de chequeo.*/
  let total = 9 * pSuma;
  let ultimoNro = total % 10
  return ultimoNro === pDigito;
}

function checkModulo(pSuma, pDigito) {
  /*
  Si el total del módulo 10 es igual a O (si el total termina en cero), entonces el número es válido 
de acuerdo con la fórmula Luhn, de lo contrario no es válido.
  */
  let total = pSuma + pDigito;
  let validacionFinal = false;
  if (total % 10 === 0 && total !== 0) {
    validacionFinal = true;
  }
  return validacionFinal;
}