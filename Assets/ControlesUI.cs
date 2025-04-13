using UnityEngine;

public class ControlesUI : MonoBehaviour
{
    public static bool izquierdaPresionada;
    public static bool derechaPresionada;
    public static bool botonAPresionado;
    public static bool botonBPresionado;

    public void PulsarIzquierda(bool activo) => izquierdaPresionada = activo;
    public void PulsarDerecha(bool activo) => derechaPresionada = activo;
    public void PulsarA(bool activo) => botonAPresionado = activo;
    public void PulsarB(bool activo) => botonBPresionado = activo;
}
