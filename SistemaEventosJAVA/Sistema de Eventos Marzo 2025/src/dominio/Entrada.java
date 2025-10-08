/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package dominio;

/**
 *
 * @author matia
 */
public class Entrada implements Comparable<Entrada>{
    private Cliente cliente;
    private Evento evento;
    private String devuelta;

    public String getDevuelta() {
        return devuelta;
    }

    public void setDevuelta(String devuelta) {
        this.devuelta = devuelta;
    }

    public Entrada(Cliente cliente, Evento evento) {
        this.cliente = cliente;
        this.evento = evento;
        this.devuelta = "N";
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

    @Override
    public int compareTo(Entrada o) {
        int cmpEvento = this.getEvento().getCodigo().compareTo(o.getEvento().getCodigo());
        if (cmpEvento != 0) {
            return cmpEvento;
        }
        return this.getCliente().getCedula().compareTo(o.getCliente().getCedula());
    }

    @Override
    public boolean equals(Object o){
        Entrada e = (Entrada)o;
        return this.getCliente().equals(e.getCliente()) && this.getEvento().equals(e.getEvento());
    }
    
    @Override
    public String toString(){
        return getCliente().getCedula() + "-" + getCliente().getNombre();
    }
}
