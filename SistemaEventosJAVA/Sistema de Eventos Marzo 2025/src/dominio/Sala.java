/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package dominio;

import java.time.LocalDate;
import tads.ListaSimpleNodos;

/**
 *
 * @author matia
 */
public class Sala implements Comparable<Sala>{
    private String nombre;
    private int capacidad;
    private ListaSimpleNodos<Evento> eventosAsignados;

    public Sala(String nombre, int capacidad) {
        this.nombre = nombre;
        this.capacidad = capacidad;
        eventosAsignados = new ListaSimpleNodos();
    }

    public ListaSimpleNodos<Evento> getEventosAsignados() {
        return eventosAsignados;
    }

    public void setEventosAsignados(ListaSimpleNodos<Evento> eventosAsignados) {
        this.eventosAsignados = eventosAsignados;
    }

    public int getCapacidad() {
        return capacidad;
    }

    public void setCapacidad(int capacidad) {
        this.capacidad = capacidad;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    @Override
    public boolean equals(Object o){
        return this.nombre.equalsIgnoreCase(((Sala)o).getNombre());
    }
    
    @Override
    public String toString(){
        return getNombre() + "-" + getCapacidad();
    }

    @Override
    public int compareTo(Sala c) {
        return this.getNombre().compareTo(c.getNombre());
    }
    
    // Metodo auxiliar
    public boolean existeEventoEnFecha(LocalDate fecha){
        boolean existe = false;
        for(int i = 0; i < eventosAsignados.cantidadElementos(); i++){
            Evento e = (Evento)eventosAsignados.obtenerElemento(i);
            if(e.getFecha().equals(fecha)){
                existe = true;
            }
        }
        return existe;
    }
}
