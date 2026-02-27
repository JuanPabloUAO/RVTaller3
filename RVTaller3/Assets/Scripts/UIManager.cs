using UnityEngine;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject panel;
    public TextMeshProUGUI texto;

    public float tiempoVisible = 2f;

    Coroutine rutinaActiva;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        panel.SetActive(false);
        texto.text = ""; //
    }

    public void MostrarInfo(string mensaje)
    {
        panel.SetActive(true);
        texto.text = mensaje;

        if (rutinaActiva != null)
            StopCoroutine(rutinaActiva);

        rutinaActiva = StartCoroutine(OcultarDespuesDeTiempo());
    }

    IEnumerator OcultarDespuesDeTiempo()
    {
        yield return new WaitForSeconds(tiempoVisible);

        OcultarTodo();
    }

    public void Cerrar()
    {
        if (rutinaActiva != null)
            StopCoroutine(rutinaActiva);

        OcultarTodo();
    }

    void OcultarTodo()
    {
        panel.SetActive(false);
        texto.text = "";
        rutinaActiva = null;
    }
}