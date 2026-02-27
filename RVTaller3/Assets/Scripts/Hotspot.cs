using UnityEngine;

public class Hotspot : MonoBehaviour
{
    [TextArea]
    public string mensaje;

    Renderer rend;
    Color colorOriginal;

    void Start()
    {
        rend = GetComponent<Renderer>();
        colorOriginal = rend.material.color;
    }

    public void Activar()
    {
        UIManager.Instance.MostrarInfo(mensaje);
    }

    public void Hover(bool estado)
    {
        if (estado)
            rend.material.color = Color.yellow;
        else
            rend.material.color = colorOriginal;
    }
}