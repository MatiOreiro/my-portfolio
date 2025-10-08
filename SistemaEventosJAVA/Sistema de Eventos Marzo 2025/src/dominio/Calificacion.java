/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package dominio;

/**
 *
 * @author matia
 */
public class Calificacion implements Comparable<Calificacion> {
    private Cliente cliente;
    private Evento evento;
    private int puntaje;
    private String comentario;

    public Calificacion(Cliente cliente, Evento evento, int puntaje, String comentario) {
        this.cliente = cliente;
        this.evento = evento;
        this.puntaje = puntaje;
        this.comentario = comentario;
    }

    public Cliente getCliente() {
        return cliente;
    }

    public void setCliente(Cliente cliente) {
        this.cliente = cliente;
    }

    public Evento getEvento() {
        return evento;
    }

    public void setEvento(Evento evento) {
        this.evento = evento;
    }

    public int getPuntaje() {
        return puntaje;
    }

    public void setPuntaje(int puntaje) {
        this.puntaje = puntaje;
    }

    public String getComentario() {
        return comentario;
    }

    public void setComentario(String comentario) {
        this.comentario = comentario;
    }
    
    @Override
    public int compareTo(Calificacion o) {
        throw new UnsupportedOperationException("Not supported yet."); // Generated from nbfs://nbhost/SystemFileSystem/Templates/Classes/Code/GeneratedMethodBody
    }
    
    @Override
    public boolean equals(Object o){
        Calificacion e = (Calificacion)o;
        return this.getCliente().equals(e.getCliente()) && this.getEvento().equals(e.getEvento());
    }
}
