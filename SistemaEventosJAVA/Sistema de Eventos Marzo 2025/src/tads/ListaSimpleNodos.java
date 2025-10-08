/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package tads;

/**
 *
 * @author matia
 */
public class ListaSimpleNodos<T extends Comparable> implements IListaSimple<T> {

    private Nodo<T> inicio;
    private Nodo<T> fin;
    private int cantE;

    public ListaSimpleNodos() {
        inicio = null;
        fin = null;
        cantE = 0;
    }

    @Override
    public void agregarInicio(T x) {
        Nodo<T> nuevo = new Nodo(x);
        if(esVacia()){
            inicio = nuevo;
            fin = nuevo;

        }else{
            nuevo.setSiguiente(inicio);
            inicio = nuevo;
            
        }
        cantE++;
    }

    @Override
    public void mostrar() {
        Nodo<T> aux = inicio;

        while (aux != null) {
            System.out.print(aux.getDato() + " - ");
            aux = aux.getSiguiente();
        }
    }

    @Override
    public int cantidadElementos() {
       return cantE;
    }

    @Override
    public boolean esVacia() {
        return inicio == null;
    }

    @Override
    public void vaciar() {
        inicio = null;
        fin = null;
        cantE = 0;
    }

    @Override
    public boolean existeElemento(T x) {
        Nodo<T> aux = inicio;
        boolean existe = false;
        
        while (aux != null && !existe) {
            if ( aux.getDato().equals(x)){
                existe = true;
            }
            aux = aux.getSiguiente();
        }
        return existe;
    }
/* Pre: indice >= 0 y < que cantE
    Post: retorna el elemento que está en el indice
*/
    @Override
    public Object obtenerElemento(int indice) {
        Nodo<T> aux = inicio;
        int pos = 0;
        boolean encontre = false;
        Object ret = -1;
        
        while (aux != null && !encontre){
            if(pos == indice){
                ret = aux.getDato();
                encontre = true;
            }
            aux = aux.getSiguiente();
            pos++;
        }
        return ret;
    }

    @Override
    public void agregarFinal(T x) {
        if (esVacia()) {
            agregarInicio(x);
        } else {
            Nodo<T> nuevo = new Nodo(x);
            fin.setSiguiente(nuevo);
            fin = nuevo;
            cantE++;
        }
    }

    @Override
    public void eliminarInicio() {
        if (!esVacia()) {
            if(cantidadElementos() == 1){
                vaciar();
            }else{
                Nodo aBorrar = inicio;
                inicio = inicio.getSiguiente();
                aBorrar.setSiguiente(null);
                cantE--;
            }

        }
    }

    @Override
    public void eliminarFinal() {
        if(!esVacia()){
            if(inicio.getSiguiente() == null){
                eliminarInicio();
            }
            else{
                Nodo<T> aux = inicio;
                while (aux.getSiguiente().getSiguiente() != null) {
                    aux = aux.getSiguiente();
                }
                aux.setSiguiente(null);
                fin = aux;
                cantE--;
            }
            
            
        }
    }

    @Override
    public void agregarOrdenado(T x) {
        if(esVacia() || x.compareTo(inicio.getDato())<0){
            agregarInicio(x);
        }
        else{
            Nodo<T> aux = inicio;
            
            while(aux.getSiguiente() != null && aux.getSiguiente().getDato().compareTo(x)<0){
                aux = aux.getSiguiente();

            }
            
            if(aux.getSiguiente() == null){
                agregarFinal(x);
            }else{
                Nodo<T> nuevo = new Nodo(x);
                nuevo.setSiguiente(aux.getSiguiente());
                aux.setSiguiente(nuevo);
                cantE++;
            }
        }
    }

    @Override
    public boolean eliminarElemento(T x) {
        boolean elimine = false;
        if(!esVacia()){
            if(inicio.getDato().equals(x)){
                eliminarInicio();
                elimine = true;

            }
            else{
                Nodo<T> aux = inicio;
                while(aux.getSiguiente() != null && !aux.getSiguiente().getDato().equals(x)){
                    aux = aux.getSiguiente();
                }
                
                if(aux.getSiguiente() != null){
                    elimine = true;
                    cantE--;
                    Nodo<T> eEliminar = aux.getSiguiente();
                    aux.setSiguiente(aux.getSiguiente().getSiguiente());
                    eEliminar.setSiguiente(null);
                }
            }
        }
        return elimine;
    }

    @Override
    public boolean eliminarXIndice(int indice) {
        if (indice < 0 || indice >= cantidadElementos()) {
            return false;
        }

        if (indice == 0) {
            // eliminar cabeza
            inicio = inicio.getSiguiente();
        } else {
            Nodo actual = inicio;
            for (int i = 0; i < indice - 1; i++) {
                actual = actual.getSiguiente();
            }
            // actual es el nodo anterior al que queremos eliminar
            actual.setSiguiente(actual.getSiguiente().getSiguiente());
        }

        cantE--;
        return true; // eliminado con éxito
    }

}
