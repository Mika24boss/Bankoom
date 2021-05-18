using System.Collections;
using DG.Tweening;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    /// <summary>
    /// Sensitivité de la souris
    /// </summary>
    public float mouseSensitivity = 1f;

    /// <summary>
    /// Durée de la transition
    /// </summary>
    public float transitionDuration = 2f;

    /// <summary>
    /// Position finale de la transition sur l'ordi
    /// </summary>
    public Transform targetSecScreen;

    /// <summary>
    /// Référence au script SecurityCamManager
    /// </summary>
    public SecurityCamManager securityCameraManager;

    /// <summary>
    /// True = caméra est dans l'animation vers l'ordi de sécurité, false sinon
    /// </summary>
    public bool isInAnim;

    public Transform vaultTransform;

    /// <summary>
    /// Rotation de la caméra en X
    /// </summary>
    private float xRotation = 0f;

    /// <summary>
    /// Corps du joueur
    /// </summary>
    private Transform playerBody;

    /// <summary>
    /// Référence au script PlayerMovement
    /// </summary>
    private PlayerMovement playerMovement;

    /// <summary>
    /// Caméra du joueur
    /// </summary>
    private Camera playerCamera;

    /// <summary>
    /// Position locale de la caméra avant la transition
    /// </summary>
    private Vector3 initialPos;

    /// <summary>
    /// Rotation locale de la caméra avant la transition
    /// </summary>
    private Quaternion initialRot;

    private void Start()
    {
        playerMovement = GameData.player.GetComponent<PlayerMovement>();
        playerBody = GameData.player.transform;
        playerCamera = GameData.player.GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        if (GameData.isMenuOpened || GameData.isUsingKeyPad || !GameData.hasGameStarted) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if (playerMovement.canMove) playerBody.Rotate(Vector3.up * mouseX);
    }

    /// <summary>
    /// Transition vers l'ordi de sécurité
    /// </summary>
    /// <returns></returns>
    private IEnumerator Transition()
    {
        isInAnim = true;
        float t = 0.0f;
        Vector3 startingPos = transform.position;
        Vector3 startingRot = transform.rotation.eulerAngles;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / transitionDuration);

            transform.position = Vector3.Lerp(startingPos, targetSecScreen.position, t);
            transform.rotation = Quaternion.Euler(Vector3.Lerp(startingRot, targetSecScreen.rotation.eulerAngles, t));
            yield return 0;
        }

        //animation terminée
        playerCamera.enabled = false;
        isInAnim = false;
        securityCameraManager.viewSecurity();
    }

    /// <summary>
    /// Méthode à appeler pour commencer la transition
    /// </summary>
    public void startTransition()
    {
        initialPos = transform.localPosition;
        initialRot = transform.localRotation;
        playerMovement.animator.SetInteger("Speed", 0);
        playerMovement.enabled = false;
        StartCoroutine(Transition());
    }

    /// <summary>
    /// Reset la caméra à sa position initiale
    /// </summary>
    public void resetCamera()
    {
        transform.localPosition = initialPos;
        transform.localRotation = initialRot;
        playerCamera.enabled = true;
    }

    /// <summary>
    /// Changer la sensitivité de la caméra
    /// </summary>
    /// <param name="sensitivity">Nouvelle valeur</param>
    public void SetSensitivity(float sensitivity)
    {
        mouseSensitivity = sensitivity;
    }

    public void endAnim()
    {
        GameObject clone = new GameObject("clone");
        clone.transform.position = playerBody.transform.position + Vector3.up * 1.2f;
        clone.transform.LookAt(vaultTransform);
        playerBody.DORotate(clone.transform.rotation.eulerAngles, 1.5f).SetEase(Ease.Linear);
    }
}