using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class SimplePlayerMovement : MonoBehaviour
{
    public float velocidad = 5f;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;   // Muy importante
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        Vector3 direccion = Vector3.zero;

        if (Keyboard.current.wKey.isPressed)
            direccion += Vector3.forward;

        if (Keyboard.current.sKey.isPressed)
            direccion += Vector3.back;

        if (Keyboard.current.aKey.isPressed)
            direccion += Vector3.left;

        if (Keyboard.current.dKey.isPressed)
            direccion += Vector3.right;

        if (direccion != Vector3.zero)
        {
            // Movimiento
            transform.Translate(direccion.normalized * velocidad * Time.deltaTime);

            // Si no está sonando, reproducir
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            // Si está quieto, detener inmediatamente
            if (audioSource.isPlaying)
                audioSource.Stop();
        }
    }
}