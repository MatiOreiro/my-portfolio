class Sistema{
    constructor(){
        this.listaDeCompradores = [];
        this.listaDeAdministradores = [];
        this.listaDeProductos = [];
        this.listaDeCompras = [];
        this.usuarioLogueado = null;
    }
    
    // Precarga de datos
    precargaDeDatos(){
        // Precarga de compradores
        this.listaDeCompradores.push(new Comprador("Nahuel", "Acosta", "nahuelinho", "Goat33", "4506-1234-1891-2024", "132"))
        this.listaDeCompradores.push(new Comprador("Kylian", "Mbappe", "kmbappe", "Madrid7", "1111-1111-1111-1111", "123"))
        this.listaDeCompradores.push(new Comprador("Leo", "Fernandez", "elmanya", "Peñarol1891", "1111-1111-1111-1891", "111"))
        this.listaDeCompradores.push(new Comprador("Lionel", "Messi", "elmessias", "Leo10", "1888-1111-2011-1111", "777"))
        this.listaDeCompradores.push(new Comprador("Cristiano", "Ronaldo", "comandante", "CRis7", "1111-2018-1111-2017", "123"))

        // Precarga de Administradores
        this.listaDeAdministradores.push(new Administrador("Sebastian", "Hohl", "sebahohl", "Sh1891"))
        this.listaDeAdministradores.push(new Administrador("Matias", "Oreiro", "matioreiro", "Mo1891"))
        this.listaDeAdministradores.push(new Administrador("Guillermo", "Vieira", "giveira", "Idolo2024"))
        this.listaDeAdministradores.push(new Administrador("Giancarlo", "Federico", "giancarlo", "Tipazo11"))
        this.listaDeAdministradores.push(new Administrador("Diego", "Aguirre", "lafiera", "Lider1891"))

        // Precarga de productos
        this.listaDeProductos.push(new Producto("Fútbol", "imagenes/futbol.jpg", "Una pelota de futbol Nike", 14.99, 50))
        this.listaDeProductos.push(new Producto("Basket", "imagenes/basket.jpg", "Una pelota de basketball genérica", 12.99, 15))
        this.listaDeProductos.push(new Producto("Voley", "imagenes/voley.jpg", "Una pelota de voleyball Mikasa", 10.99, 11))
        this.listaDeProductos.push(new Producto("Golf", "imagenes/golf.avif", "Una pelota de golf Inesis", 24.99, 60))
        this.listaDeProductos.push(new Producto("Bowling", "imagenes/bowling.webp", "Una pelota de bolos azul", 89.99, 44))
        this.listaDeProductos.push(new Producto("Tenis", "imagenes/tenis.webp", "Una pelota de tenis Wilson", 9.99, 70))
        this.listaDeProductos.push(new Producto("Ping Pong", "imagenes/pingpong.webp", "Una caja de 6 pelotas de ping pong", 6.99, 13))
        this.listaDeProductos.push(new Producto("Futsal", "imagenes/futsal.webp", "Una pelota de futsal Mikasa", 11.99, 60))
        this.listaDeProductos.push(new Producto("Padel", "imagenes/padel.webp", "Una pelota de padel profesional", 19.99, 5))
        this.listaDeProductos.push(new Producto("Bolas de pool", "imagenes/pool.webp", "Un juego de 16 bolas de pool", 149.99, 8))
        this.listaDeProductos[6].estado = false;

        // Precarga de compras
        this.listaDeCompras.push(new Compra(this.listaDeCompradores[0], this.listaDeProductos[0], 5))
        this.listaDeCompras.push(new Compra(this.listaDeCompradores[1], this.listaDeProductos[1], 2))
        this.listaDeCompras.push(new Compra(this.listaDeCompradores[2], this.listaDeProductos[4], 40))
        this.listaDeCompras.push(new Compra(this.listaDeCompradores[3], this.listaDeProductos[6], 8))
        this.listaDeCompras.push(new Compra(this.listaDeCompradores[4], this.listaDeProductos[8], 10))
    }

    //Validaciones
    validarInicioSesionUsuario(userName, password){
        let resp = false;
        userName = userName.toUpperCase();
        for (let i = 0; i < this.listaDeCompradores.length; i++) {
            let objActual = this.listaDeCompradores[i];
            let userActual = objActual.userName;
            let passActual = objActual.password;
            if(userName == userActual.toUpperCase() && password == passActual){
                resp = true
                this.usuarioLogueado = objActual
            }

        }
        return resp;
    }

    validarInicioSesionAdministrador(userName, password){
        let resp = false;
        userName = userName.toUpperCase();
        for (let i = 0; i < this.listaDeAdministradores.length; i++) {
            let objActual = this.listaDeAdministradores[i];
            let userActual = objActual.userName;
            let passActual = objActual.password;
            if(userName == userActual.toUpperCase() && password == passActual){
                resp = true;
                this.usuarioLogueado = objActual;
            }

        }
        return resp;
    }

    cierreDeSesion(){
        this.usuarioLogueado = null;
    }

    existeComprador(userName){
        let existe = false;
        userName = userName.toUpperCase();
        for (let i = 0; i < this.listaDeCompradores.length; i++) {
            let objCompradorActual = this.listaDeCompradores[i];
            if(objCompradorActual.userName.toUpperCase() == userName){
                existe = true;
            }
        }
        return existe;
    }

    existeAdministrador(userName){
        let existe = false;
        userName = userName.toUpperCase();
        for (let i = 0; i < this.listaDeAdministradores.length; i++) {
            let objCompradorActual = this.listaDeAdministradores[i];
            if(objCompradorActual.userName.toUpperCase() == userName){
                existe = true;
            }
        }
        return existe;
    }

    //Acciones del Usuario
    agregarComprador(nombre, apellido, userName, password, numeroTarjetaDeCredito, cvcTarjetaDeCredito){
        let objComprador = new Comprador(nombre, apellido, userName, password, numeroTarjetaDeCredito, cvcTarjetaDeCredito)
        this.listaDeCompradores.push(objComprador)
    }

    comprarProducto(idProducto, cantidad){
        let producto = this.obtenerProductoPorID(idProducto);
        let compra = new Compra(this.usuarioLogueado, producto, cantidad);
        this.listaDeCompras.push(compra);
    }

    cancelarCompra(idProducto){
        let sigo = true;
        for (let i = 0; i < this.listaDeCompras.length; i++) {
            let objProducto = this.listaDeCompras[i];
            if(objProducto.id === idProducto){
                objProducto.estado = "Cancelada";
                sigo = false;
            }

        }
    }

    calcularMontoDeComprasAprobadas(){
        let lista = sistema.obtenerMisCompras("Aprobada");
        let montoFinal = 0;

        for (let i = 0; i < lista.length; i++) {
            let objCompra = lista[i];
            montoFinal += parseFloat(objCompra.montoTotal());
        }

        return montoFinal;
    }

    //Acciones del Administrador
    procesarCompra(idCompra){
        let compra = this.obtenerCompraPorID(idCompra);
        let ok = false;
        if( !compra.producto.estado || compra.producto.stock < compra.cantidad || compra.montoTotal() > compra.comprador.saldo ){
            compra.estado = "Cancelada";
        }else{
            compra.producto.stock -= compra.cantidad;
            compra.producto.cantidadDeVendidos += compra.cantidad;
            compra.comprador.saldo -= compra.montoTotal();
            compra.estado = "Aprobada";
            if(compra.producto.stock == 0){
                compra.producto.estado = false;
            }
            ok = true
        }
        return ok;
    }

    agregarProducto(nombre, precio, descripcion, imagen, stock){
        let objProducto = new Producto(nombre, imagen, descripcion, precio, stock);
        this.listaDeProductos.push(objProducto);
    }

    actualizarStock(idProducto, nuevoStock){
        let producto = this.obtenerProductoPorID(idProducto);
        producto.stock = nuevoStock;
        if(producto.stock == 0){
            producto.estado = false;
        }

        return nuevoStock
    }

    modificarEstado(idProducto){
        let producto = this.obtenerProductoPorID(idProducto);
        if(producto.stock == 0){

        }else{
            if(producto.estado == false){
                producto.estado = true;
            }else{
                producto.estado = false;
            }
        }
    }

    modificarOferta(idProducto){
        let producto = this.obtenerProductoPorID(idProducto);
        if (producto.oferta == false) {
            producto.oferta = true;
        }else{
            producto.oferta = false;
        }
    }

    //Obtener Datos
    obtenerListadoDeTodosLosProductos(){
        return this.listaDeProductos;
    }

    obtenerListadoDeProductos(){
        let lista = [];
        for (let i = 0; i < this.listaDeProductos.length; i++) {
            let objProducto = this.listaDeProductos[i];
            if(objProducto.estado){
                lista.push(objProducto);
            }
        }
        return lista;
    }

    obtenerProductoPorID(idProducto){
        for (let i = 0; i < this.listaDeProductos.length; i++) {
            let objProducto = this.listaDeProductos[i];
            if (objProducto.id == idProducto) {
                return objProducto;
            }
            
        }
    }

    obtenerListadoDeCompras(){
        return this.listaDeCompras;
    }
    
    obtenerCompraPorID(idCompra){
        for (let i = 0; i < this.listaDeCompras.length; i++) {
            let objCompra = this.listaDeCompras[i];
            if(objCompra.id == idCompra){
                return objCompra;
            }
            
        }
    }

    obtenerMisCompras(estado){
        let lista = [];
        for (let i = 0; i < this.listaDeCompras.length; i++) {
            let objCompra = this.listaDeCompras[i];
            if(objCompra.comprador.userName === this.usuarioLogueado.userName && estado == "Aprobada" && objCompra.estaAprobada()){
                lista.push(objCompra);
            }else if(objCompra.comprador.userName === this.usuarioLogueado.userName && estado == "Pendiente" && objCompra.estaPendiente()){
                lista.push(objCompra);
            }else if(objCompra.comprador.userName === this.usuarioLogueado.userName && estado == "Cancelada" && objCompra.estaCancelada()){
                lista.push(objCompra);
            }else if(objCompra.comprador.userName === this.usuarioLogueado.userName && estado == "Todas"){
                lista.push(objCompra);
            }
        }
        return lista
    }

    obtenerComprasDeUsuario(estado){
        let lista = [];
        for (let i = 0; i < this.listaDeCompras.length; i++) {
            let objCompra = this.listaDeCompras[i];
            if(estado == "Aprobada" && objCompra.estaAprobada()){
                lista.push(objCompra);
            }else if(estado == "Pendiente" && objCompra.estaPendiente()){
                lista.push(objCompra);
            }else if(estado == "Cancelada" && objCompra.estaCancelada()){
                lista.push(objCompra);
            }
        }
        return lista;
    }

    obtenerSaldoComprador(){
        for (let i = 0; i < this.listaDeCompradores.length; i++) {
            let objCompradorActual = this.listaDeCompradores[i];
            if(objCompradorActual.userName == this.usuarioLogueado.userName){
                return objCompradorActual.obtenerSaldo();
            }
        }
    }
    
    obtenerMontoTotalDeComprasAprobadas(){
        let lista = this.obtenerComprasDeUsuario("Aprobada");
        let montoFinal = 0;

        for (let i = 0; i < lista.length; i++) {
            let objCompraAprobada = lista[i];
            montoFinal += objCompraAprobada.montoTotal();
            
        }

        return montoFinal;
    }

}

sigIdCompra = 1;
class Compra{
    constructor(comprador, producto, cantidad){
        this.id = sigIdCompra++;
        this.comprador = comprador;
        this.producto = producto;
        this.cantidad = cantidad;
        this.estado = "Pendiente";
    }


    montoTotal(){
        return this.producto.precio * this.cantidad;
    }

    estaAprobada(){
        return this.estado == "Aprobada";
    }

    estaPendiente(){
        return this.estado == "Pendiente";
    }

    estaCancelada(){
        return this.estado == "Cancelada";
    }
}

let sigIDComprador = 1;
class Comprador{
    constructor(nombre, apellido, userName, password, numeroTarjetaDeCredito, cvcTarjetaDeCredito){
        this.id = sigIDComprador++;
        this.nombre = nombre;
        this.apellido = apellido;
        this.userName = userName;
        this.password = password;
        this.numeroTarjetaDeCredito = numeroTarjetaDeCredito;
        this.cvcTarjetaDeCredito = cvcTarjetaDeCredito;
        this.saldo = 3000;
    }

    obtenerSaldo(){
        return this.saldo;
    }
}

class Administrador{
    constructor(nombre, apellido, userName, password){
        this.nombre = nombre;
        this.apellido = apellido;
        this.userName = userName;
        this.password = password;
    }
}

sigIDProducto = 1;
class Producto{
    constructor(nombre, imagen, descripcion, precio, stock){
        this.id = "PROD_ID_" + sigIDProducto++;
        this.nombre = nombre;
        this.imagen = imagen;
        this.descripcion = descripcion;
        this.precio = precio;
        this.stock = stock;
        this.cantidadDeVendidos = 0;
        this.oferta = false;
        this.estado = true;
    }


}