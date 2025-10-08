/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package dominio;

/**
 *
 * @author matia
 */
public class Cliente implements Comparable<Cliente>{
    private String cedula;
    private String nombre;

    public Cliente(String cedula, String nombre) {
        this.cedula = cedula;
        this.nombre = nombre;
    }

    public String getCedula() {
        return cedula;
    }

    public void setCedula(String cedula) {
        this.cedula = cedula;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    @Override
    public boolean equals(Object o){
        return this.getCedula().equalsIgnoreCase(((Cliente)o).getCedula());
    }
    
    @Override
    public String toString(){
        return getCedula() + "-" + getNombre();
    }

    @Override
    public int compareTo(Cliente c) {
        return Integer.compare(Integer.parseInt(this.cedula), Integer.parseInt(c.cedula));
    }
    
}
