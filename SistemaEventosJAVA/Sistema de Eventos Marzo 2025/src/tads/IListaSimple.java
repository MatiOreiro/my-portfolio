/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package tads;

/**
 *
 * @author matia
 */
public interface IListaSimple<T> {
    
    public void agregarInicio(T x);
    
    public void mostrar();
    
    public int cantidadElementos();
    
    public boolean esVacia();
    
    public void vaciar();
    
    public boolean existeElemento (T x);
    
    public Object obtenerElemento(int indice);
    
    public void agregarFinal (T x);
    
    public void eliminarInicio();
    
    public void eliminarFinal();

    public void agregarOrdenado(T x);
    
    public boolean eliminarElemento(T x);
    
    public boolean eliminarXIndice(int indice);

}
