package sistemaAutogestion;

import dominio.Calificacion;
import dominio.Sala;
import dominio.Cliente;
import dominio.Entrada;
import dominio.Evento;
import java.time.LocalDate;
import tads.ListaSimpleNodos;

public class Sistema implements IObligatorio {

    private ListaSimpleNodos<Cliente> listaClientes;
    private ListaSimpleNodos<Sala> listaSalas;
    private ListaSimpleNodos<Evento> listaEventos;
    private ListaSimpleNodos<Entrada> listaEntradas;

    public Sistema() {
        listaSalas = new ListaSimpleNodos();
        listaEventos = new ListaSimpleNodos();
        listaClientes = new ListaSimpleNodos();
        listaEntradas = new ListaSimpleNodos();
    }

    @Override
    public Retorno crearSistemaDeGestion() {
        listaSalas = new ListaSimpleNodos();
        listaEventos = new ListaSimpleNodos();
        listaClientes = new ListaSimpleNodos();
        listaEntradas = new ListaSimpleNodos();
        return Retorno.ok();
    }

    @Override
    public Retorno registrarSala(String nombre, int capacidad) {
        Retorno r = new Retorno(Retorno.Resultado.OK);
        if (capacidad > 0) {
            Sala aux = new Sala(nombre, capacidad);
            if (!listaSalas.existeElemento(aux)) {
                listaSalas.agregarInicio(aux);
            } else {
                r.resultado = Retorno.Resultado.ERROR_1;
            }
        } else {
            r.resultado = Retorno.Resultado.ERROR_2;
        }

        return r;
    }

    @Override
    public Retorno eliminarSala(String nombre) {
        Sala aux = new Sala(nombre, 0);
        boolean encontre = false;
        Retorno r = new Retorno(Retorno.Resultado.OK);
        for (int i = 0; i < listaSalas.cantidadElementos() && !encontre; i++) {
            if (aux.compareTo((Sala) listaSalas.obtenerElemento(i)) == 0) {
                encontre = true;
                listaSalas.eliminarElemento(aux);
            }

        }
        if (!encontre) {
            r.resultado = Retorno.Resultado.ERROR_1;
        }
        return r;
    }

    @Override
    public Retorno registrarEvento(String codigo, String descripcion, int aforoNecesario, LocalDate fecha) {
        Retorno r = new Retorno(Retorno.Resultado.OK);

        if (aforoNecesario > 0) {
            Evento aux = new Evento(codigo, descripcion, aforoNecesario, fecha, null);

            if (!listaEventos.existeElemento(aux)) {
                Sala s = salaDisponible(fecha, aforoNecesario);
                if (s != null) {
                    aux.setSala(s);
                    listaEventos.agregarOrdenado(aux);
                    s.getEventosAsignados().agregarOrdenado(aux);
                    r.resultado = Retorno.Resultado.OK;
                } else {
                    r.resultado = Retorno.Resultado.ERROR_3;
                }
            } else {
                r.resultado = Retorno.Resultado.ERROR_1;
            }
        } else {
            r.resultado = Retorno.Resultado.ERROR_2;
        }
        return r;
    }

    @Override
    public Retorno registrarCliente(String cedula, String nombre) {
        Retorno r = new Retorno(Retorno.Resultado.OK);
        if (cedula.length() == 8) {
            Cliente aux = new Cliente(cedula, nombre);
            if (!listaClientes.existeElemento(aux)) {
                listaClientes.agregarOrdenado(aux);
            } else {
                r.resultado = Retorno.Resultado.ERROR_2;
            }
        } else {
            r.resultado = Retorno.Resultado.ERROR_1;
        }

        return r;
    }

    @Override
    public Retorno comprarEntrada(String cedula, String codigoEvento) {
        Retorno r = new Retorno(Retorno.Resultado.OK);
        if (codigoEvento.length() > 0 && cedula.length() > 0) {
            Cliente c = buscarCliente(cedula);
            if (c != null) {
                Evento e = buscarEvento(codigoEvento);
                if (e != null) {
                    Entrada ent = new Entrada(c, e);
                    if (e.getAforoNecesario() > e.getEntradasVendidas()) {
                        listaEntradas.agregarFinal(ent);
                        e.setEntradasVendidas(e.getEntradasVendidas() + 1);
                    } else {
                        e.getListaEspera().encolar(ent);
                    }
                } else { // evento no existe
                    r.resultado = Retorno.Resultado.ERROR_2;
                }
            } else { // cliente no existe
                r.resultado = Retorno.Resultado.ERROR_1;
            }

        }
        return r;
    }

    @Override
    public Retorno eliminarEvento(String codigo) {
        Retorno r = new Retorno(Retorno.Resultado.OK);
        if (codigo.length() > 0) {
            Evento e = buscarEvento(codigo);
            if (e != null) {
                if (e.getEntradasVendidas() == 0) {
                    boolean encontre = false;
                    for (int i = 0; i < listaEventos.cantidadElementos() && !encontre; i++) {
                        if (e.compareTo((Evento) listaEventos.obtenerElemento(i)) == 0) {
                            encontre = true;
                            listaEventos.eliminarElemento(e);
                            Sala s = e.getSala();
                            s.getEventosAsignados().eliminarElemento(e);
                        }
                    }
                } else {
                    r.resultado = Retorno.Resultado.ERROR_2;
                }
            } else {
                r.resultado = Retorno.Resultado.ERROR_1;
            }
        }
        return r;
    }

    @Override
    public Retorno devolverEntrada(String cedula, String codigoEvento) {
        Retorno r = new Retorno(Retorno.Resultado.OK);
        if (cedula.length() > 0 && codigoEvento.length() > 0) {
            Cliente c = buscarCliente(cedula);
            if (c != null) {
                Evento e = buscarEvento(codigoEvento);
                if (e != null) {
                    Entrada aux = new Entrada(c, e);
                    boolean encontre = false;
                    for (int i = 0; i < listaEntradas.cantidadElementos() && !encontre; i++) {
                        Entrada ent = (Entrada) listaEntradas.obtenerElemento(i);
                        if (ent.equals(aux) && ent.getDevuelta().equals("N")) {
//                            listaEntradas.eliminarElemento(aux);
                            ent.setDevuelta("D");
                            if (e.getListaEspera().cantidadElementos() > 0) {
                                listaEntradas.agregarFinal((Entrada) e.getListaEspera().frente());
                                e.getListaEspera().desencolar();
                            } else {
                                e.setEntradasVendidas(e.getEntradasVendidas() - 1);
                            }
                            encontre = true;
                        }
                    }

                } else {
                    r.resultado = Retorno.Resultado.ERROR_2;
                }
            } else {
                r.resultado = Retorno.Resultado.ERROR_1;
            }
        }
        return r;
    }

    @Override
    public Retorno calificarEvento(String cedula, String codigoEvento, int puntaje, String comentario) {
        Retorno r = new Retorno(Retorno.Resultado.OK);
        if (cedula.length() > 0 && codigoEvento.length() > 0) {
            Cliente c = buscarCliente(cedula);
            if (c != null) {
                Evento e = buscarEvento(codigoEvento);
                if (e != null) {
                    if (puntaje >= 0 && puntaje <= 10) {
                        Calificacion cal = new Calificacion(c, e, puntaje, comentario);
                        if (!e.getCalificaciones().existeElemento(cal)) {
                            e.getCalificaciones().agregarFinal(cal);
                            e.setSumaCalificaciones(e.getSumaCalificaciones() + puntaje);
                        } else {
                            r.resultado = Retorno.Resultado.ERROR_4;
                        }
                    } else {
                        r.resultado = Retorno.Resultado.ERROR_3;
                    }
                } else {
                    r.resultado = Retorno.Resultado.ERROR_2;
                }
            } else {
                r.resultado = Retorno.Resultado.ERROR_1;
            }
        }
        return r;
    }

// 2
    @Override
    public Retorno listarSalas() {
        String texto = "";
        Retorno r = new Retorno(Retorno.Resultado.OK);
        for (int i = 0; i < listaSalas.cantidadElementos(); i++) {
            Sala s = (Sala) listaSalas.obtenerElemento(i);
            if (i < (listaSalas.cantidadElementos() - 1)) {
                texto += s.toString() + "#";
            } else {
                texto += s.toString();
            }
        }
        System.out.println(texto);
        r.valorString = texto;
        return r;
    }

    @Override
    public Retorno listarEventos() {
        String texto = "";
        Retorno r = new Retorno(Retorno.Resultado.OK);
        for (int i = 0; i < listaEventos.cantidadElementos(); i++) {
            Evento e = (Evento) listaEventos.obtenerElemento(i);
            if (i < (listaEventos.cantidadElementos() - 1)) {
                texto += e.toString() + "#";
            } else {
                texto += e.toString();
            }
        }
        System.out.println(texto);
        r.valorString = texto;
        return r;
    }

    @Override
    public Retorno listarClientes() {
        String texto = "";
        Retorno r = new Retorno(Retorno.Resultado.OK);
        for (int i = 0; i < listaClientes.cantidadElementos(); i++) {
            Cliente c = (Cliente) listaClientes.obtenerElemento(i);
            if (i < (listaClientes.cantidadElementos() - 1)) {
                texto += c.toString() + "#";
            } else {
                texto += c.toString();
            }
        }
        System.out.println(texto);
        r.valorString = texto;
        return r;
    }

    @Override
    public Retorno esSalaOptima(String[][] vistaSala) {
        Retorno r = new Retorno(Retorno.Resultado.OK);
        int cantCumplen = 0;

        for (int i = 0; i < vistaSala[0].length; i++) {
            int maxBloqueO = 0;
            int bloqueActual = 0;
            int totalX = 0;

            for (int j = 0; j < vistaSala.length; j++) {
                String valor = vistaSala[j][i];

                if ("O".equals(valor)) {
                    bloqueActual++;
                    if (bloqueActual > maxBloqueO) {
                        maxBloqueO = bloqueActual;
                    }
                } else {
                    bloqueActual = 0;
                    if ("X".equals(valor)) {
                        totalX++;
                    }
                }
            }

            if (maxBloqueO > totalX) {
                cantCumplen++;
            }
        }

        if (cantCumplen >= 2) {
            r.valorString = "Es óptimo";
        } else {
            r.valorString = "No es óptimo";
        }
        System.out.println(r.valorString);
        return r;
    }

    @Override
    public Retorno listarClientesDeEvento(String codigo, int n) {
        Retorno r = new Retorno(Retorno.Resultado.OK);
        String texto = "";
        if (buscarEvento(codigo) != null) {
            if (n >= 1) {
                for (int i = 0; i < n && i < listaEntradas.cantidadElementos(); i++) {
                    Entrada aux = (Entrada) listaEntradas.obtenerElemento(i);
                    if (aux.getEvento().getCodigo().equals(codigo)) {
                        texto += aux.toString() + "#";
                    }
                }
            } else {
                r.resultado = Retorno.Resultado.ERROR_2;
            }
        } else {
            r.resultado = Retorno.Resultado.ERROR_1;
        }
        r.valorString = texto;
        return r;
    }

    @Override
    public Retorno listarEsperaEvento() {
        Retorno r = new Retorno(Retorno.Resultado.OK);
        String texto = "";
        for (int i = 0; i < listaEventos.cantidadElementos(); i++) {
            Evento e = (Evento) listaEventos.obtenerElemento(i);
            if (e.getListaEspera().cantidadElementos() > 0) {
                if (i == listaEventos.cantidadElementos() - 1) {
                    texto += e.getCodigo() + "-" + e.clientesEnCola();
                } else {
                    texto += e.getCodigo() + "-" + e.clientesEnCola() + "#";

                }
            }
        }
        r.valorString = texto;
        return r;
    }

    @Override
    public Retorno deshacerUtimasCompras(int n) {
        Retorno r = new Retorno(Retorno.Resultado.OK);
        String texto = "";
        ListaSimpleNodos<Entrada> entradasDeshechas = new ListaSimpleNodos<>();

        int total = listaEntradas.cantidadElementos();

        for (int i = total - 1; i >= 0 && n > 0; i--) {
            Entrada e = (Entrada) listaEntradas.obtenerElemento(i);
            entradasDeshechas.agregarOrdenado(e);

            devolverEntrada(e.getCliente().getCedula(), e.getEvento().getCodigo());

            n--;
        }

        for (int i = 0; i < entradasDeshechas.cantidadElementos(); i++) {
            Entrada ent = (Entrada) entradasDeshechas.obtenerElemento(i);
            texto += ent.getEvento().getCodigo() + "-" + ent.getCliente().getCedula() + "#";
        }

        r.valorString = texto;
        return r;
    }

    @Override
    public Retorno eventoMejorPuntuado() {
        Retorno r = new Retorno(Retorno.Resultado.OK);
        String texto = "";
        int mayor = 0;
        ListaSimpleNodos<Evento> eventos = new ListaSimpleNodos<>();

        for (int i = 0; i < listaEventos.cantidadElementos(); i++) {
            Evento e = (Evento) listaEventos.obtenerElemento(i);
            if (e.calcularPromedio() > mayor) {
                eventos.vaciar();
                eventos.agregarOrdenado(e);
                mayor = e.calcularPromedio();
            } else if (e.calcularPromedio() == mayor) {
                eventos.agregarOrdenado(e);
            }
        }

        for (int i = 0; i < eventos.cantidadElementos(); i++) {
            Evento ev = (Evento) eventos.obtenerElemento(i);
            if (i < eventos.cantidadElementos() - 1) {
                texto += ev.getCodigo() + "-" + ev.calcularPromedio() + "#";
            } else {
                texto += ev.getCodigo() + "-" + ev.calcularPromedio();
            }
        }
        r.valorString = texto;
        return r;
    }

    @Override
    public Retorno comprasDeCliente(String cedula) {
        Retorno r = new Retorno(Retorno.Resultado.OK);
        String texto = "";

        Cliente c = buscarCliente(cedula);
        if (c != null) {
            for (int i = 0; i < listaEntradas.cantidadElementos(); i++) {
                Entrada ent = (Entrada) listaEntradas.obtenerElemento(i);
                if (ent.getCliente().getCedula().equals(cedula)) {
                    texto += ent.getEvento().getCodigo() + "-" + ent.getDevuelta() + "#";
                }
            }
        } else {
            r.resultado = Retorno.Resultado.ERROR_1;
        }
        r.valorString = texto;
        return r;
    }
// Segun lo conversado con el profe, buscamos comprasXDia del Evento

    @Override
    public Retorno comprasXDia(int mes) {
        Retorno r = new Retorno(Retorno.Resultado.OK);
        int contador = 0;
        String texto = "";

        if (mes >= 1 && mes <= 12) {
            int[] dias = new int[31]; // días 1 a 31 mapeados a posiciones 0 a 30

            for (int i = 0; i < listaEntradas.cantidadElementos(); i++) {
                Entrada e = (Entrada) listaEntradas.obtenerElemento(i);
                LocalDate fecha = e.getEvento().getFecha();

                if (fecha.getMonthValue() == mes) {
                    int dia = fecha.getDayOfMonth();
                    dias[dia - 1]++;
                }
            }

            for (int i = 0; i < 31; i++) {
                if (dias[i] > 0) {
                    texto += (i + 1) + "-" + dias[i] + "#";
                }
            }

            r.valorString = texto;
            return r;
        } else {
            r.resultado = Retorno.Resultado.ERROR_1;
        }
        r.valorString = texto;
        return r;
    }

    // Métodos auxiliares
    public Sala salaDisponible(LocalDate fecha, int aforo) {
        Sala sDisponible = null;
        for (int i = 0; i < listaSalas.cantidadElementos() && sDisponible == null; i++) {
            Sala s = (Sala) listaSalas.obtenerElemento(i);
            if (s.getCapacidad() >= aforo && !s.existeEventoEnFecha(fecha)) {
                sDisponible = (Sala) listaSalas.obtenerElemento(i);
            }

        }
        return sDisponible;
    }

    public Evento buscarEvento(String codigo) {
        boolean encontre = false;
        Evento aux = new Evento(codigo, null, 0, null, null);
        Evento ret = null;
        for (int i = 0; i < listaEventos.cantidadElementos() && !encontre; i++) {
            if (listaEventos.obtenerElemento(i).equals(aux)) {
                ret = (Evento) listaEventos.obtenerElemento(i);
                encontre = true;
            }
        }
        return ret;
    }

    public Cliente buscarCliente(String cedula) {
        boolean encontre = false;
        Cliente aux = new Cliente(cedula, null);
        Cliente ret = null;
        for (int i = 0; i < listaClientes.cantidadElementos() && !encontre; i++) {
            if (listaClientes.obtenerElemento(i).equals(aux)) {
                ret = (Cliente) listaClientes.obtenerElemento(i);
                encontre = true;
            }
        }
        return ret;
    }
}
