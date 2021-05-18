using UnityEngine;

public class MouseLookSecurity : MonoBehaviour
{
    /// <summary>
    /// Sensitivité de la caméra de sécurité
    /// </summary>
    public float mouseSensitivity = 100f;

    /// <summary>
    /// Source de l'audio de la caméra
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Rotation de la caméra
    /// </summary>
    private float xRotation = 40f;
    private float yRotation = 90f;

    /// <summary>
    /// Rotation au dernier frame (pour pouvoir détecter un mouvement de la caméra)
    /// </summary>
    private Vector3 previousRot = Vector3.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (GameData.isMenuOpened) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity; // * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity; // * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, 10f, 90f);
        yRotation -= mouseX;
        yRotation = Mathf.Clamp(yRotation, 40f, 140f);
        transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0f);

        if ((previousRot - transform.rotation.eulerAngles).sqrMagnitude == 0) //la caméra ne bouge pas
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
        else //elle bouge
        {
            audioSource.Play();
        }

        previousRot = transform.rotation.eulerAngles; //update
    }
}