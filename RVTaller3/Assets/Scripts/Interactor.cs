using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public float distancia = 100f;

    Hotspot hotspotActual;

    void Update()
    {
        if (Mouse.current == null) return;

        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distancia))
        {
            Hotspot h = hit.collider.GetComponent<Hotspot>();

            if (h != null)
            {
                if (hotspotActual != h)
                {
                    if (hotspotActual != null)
                        hotspotActual.Hover(false);

                    hotspotActual = h;
                    hotspotActual.Hover(true);
                }

                if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    hotspotActual.Activar();
                }
            }
        }
        else
        {
            if (hotspotActual != null)
            {
                hotspotActual.Hover(false);
                hotspotActual = null;
            }
        }
    }
}