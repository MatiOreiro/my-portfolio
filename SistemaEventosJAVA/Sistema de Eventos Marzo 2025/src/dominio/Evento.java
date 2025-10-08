package dominio;

import java.time.LocalDate;
import tads.Cola;
import tads.ListaSimpleNodos;

public class Evento implements Comparable<Evento> {

    private String codigo;
    private String descripcion;
    private int aforoNecesario;
    private LocalDate fecha;
    private Sala sala;
    private Cola listaEspera;
    private int entradasVendidas;
    private ListaSimpleNodos<Calificacion> calificaciones;
    private int sumaCalificaciones;

    public ListaSimpleNodos<Calificacion> getCalificaciones() {
        return calificaciones;
    }

    public void setCalificaciones(ListaSimpleNodos<Calificacion> calificaciones) {
        this.calificaciones = calificaciones;
    }

    public int getSumaCalificaciones() {
        return sumaCalificaciones;
    }

    public void setSumaCalificaciones(int sumaCalificaciones) {
        this.sumaCalificaciones = sumaCalificaciones;
    }

    public Cola getListaEspera() {
        return listaEspera;
    }

    public void setListaEspera(Cola listaEspera) {
        this.listaEspera = listaEspera;
    }

    public int getEntradasVendidas() {
        return entradasVendidas;
    }

    public void setEntradasVendidas(int entradasVendidas) {
        this.entradasVendidas = entradasVendidas;
    }

    public Evento(String codigo, String descripcion, int aforoNecesario, LocalDate fecha, Sala sala) {
        this.codigo = codigo;
        this.descripcion = descripcion;
        this.aforoNecesario = aforoNecesario;
        this.fecha = fecha;
        this.sala = sala;
        this.listaEspera = new Cola();
        this.calificaciones = new ListaSimpleNodos();
    }

    public Sala getSala() {
        return sala;
    }

    public void setSala(Sala sala) {
        this.sala = sala;
    }

    public String getCodigo() {
        return codigo;
    }

    public void setCodigo(String codigo) {
        this.codigo = codigo;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public int getAforoNecesario() {
        return aforoNecesario;
    }

    public void setAforoNecesario(int aforoNecesario) {
        this.aforoNecesario = aforoNecesario;
    }

    public LocalDate getFecha() {
        return fecha;
    }

    public void setFecha(LocalDate fecha) {
        this.fecha = fecha;
    }

    @Override
    public boolean equals(Object o) {
        return this.getCodigo().equalsIgnoreCase(((Evento) o).getCodigo());
    }

    // codigo-descripcion-sala-aforo-fecha-
    @Override
    public String toString() {
        return getCodigo() + "-" + getDescripcion() + "-" + getSala().getNombre() + "-" + getAforoNecesario() + "-" + 0;
    }

    @Override
    public int compareTo(Evento e) {
        return this.getCodigo().compareTo(e.getCodigo());
    }

    public int calcularPromedio() {
        if(calificaciones.cantidadElementos() == 0){
            return 0;
        }
        return sumaCalificaciones / calificaciones.cantidadElementos();
    }
    
    public String clientesEnCola(){
        String texto = "";
        if(!listaEspera.esVacia()){
            Cola aux = new Cola();
            while(!listaEspera.esVacia()){
                Entrada e = (Entrada)listaEspera.frente();
                texto += e.getCliente().getCedula() + ",";
                aux.encolar(e);
                listaEspera.desencolar();
            }
            listaEspera = aux;
        }
        return texto;
    }
}
