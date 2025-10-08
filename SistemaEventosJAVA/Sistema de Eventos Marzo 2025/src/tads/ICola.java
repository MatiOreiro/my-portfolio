package tads;





public interface ICola<T> {
    
   
    public void encolar (T x);
    
    public void desencolar();
    
    public void mostrar();
    
    public int cantidadElementos ();
    
    public boolean esVacia();
    
    public void vaciar();
    
    public T frente();
   
    
}
