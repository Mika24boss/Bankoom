using System.Linq;
using TMPro;
using UnityEngine;

public class SecurityCamManager : MonoBehaviour
{
    /// <summary>
    /// Tableau des logiques des caméras de sécurité
    /// </summary>
    public GameObject[] securityCamsLogic;

    /// <summary>
    /// Overlay de quand on regarde une caméra de sécurité
    /// </summary>
    public GameObject securityCameraOverlay;

    /// <summary>
    /// Texte où on affiche le nom de la caméra
    /// </summary>
    private TMP_Text secCamOverlayText;

    /// <summary>
    /// Tableau des scripts SecurityCam des caméras
    /// </summary>
    private SecurityCam[] securityCams;

    /// <summary>
    /// Tableau des caméras
    /// </summary>
    private Camera[] cameras;

    /// <summary>
    /// Savoir on regarde quelle caméra
    /// </summary>
    private int index;

    /// <summary>
    /// Script PlayerMovement du joueur
    /// </summary>
    private PlayerMovement playerMovement;

    /// <summary>
    /// Script MouseLook du joueur
    /// </summary>
    private MouseLook playerMouseLook;

    /// <summary>
    /// Caméra du joueur
    /// </summary>
    private Camera playerCamera;

    private void Start()
    {
        //pcq'on commence par voir la camera du couloir (a cote du joueur), et cette camera est la derniere sur la liste
        index = securityCamsLogic.Length - 1;

        securityCams = new SecurityCam[securityCamsLogic.Length];
        cameras = new Camera[securityCamsLogic.Length];
        for (int i = 0; i < securityCamsLogic.Length; i++)
        {
            securityCams[i] = securityCamsLogic[i].GetComponent<SecurityCam>();
            cameras[i] = securityCamsLogic[i].GetComponent<Camera>();
        }

        secCamOverlayText = securityCameraOverlay.GetComponentInChildren<TMP_Text>();
        playerMovement = GameData.player.GetComponent<PlayerMovement>();
        playerMouseLook = GameData.player.GetComponentInChildren<MouseLook>();
        playerCamera = GameData.player.GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        checkPlayerVisibility();
    }

    private void Update()
    {
        if (!GameData.viewSecurityCam) return;
        if (Input.GetKey(KeyCode.Escape) && !playerMouseLook.isInAnim)
        {
            stopViewingSecurity();
            return;
        }

        int newIndex = index;
        if (Input.GetMouseButtonDown(0)) newIndex--; //left click
        if (Input.GetMouseButtonDown(1)) newIndex++; //right click

        if (newIndex == index) return;
        if (newIndex < 0) newIndex = securityCamsLogic.Length - 1;
        if (newIndex >= securityCamsLogic.Length) newIndex = 0;
        cameras[index].enabled = false;
        cameras[newIndex].enabled = true;
        securityCams[index].stopViewingSecurity();
        securityCams[newIndex].viewSecurity();
        index = newIndex;
        changeText();
    }

    public void viewSecurity()
    {
        GameData.viewSecurityCam = true;
        GameData.bottomText.text = "ESC pour revenir\nClic gauche et clic droit pour changer de caméra";
        securityCameraOverlay.SetActive(true);
        cameras[index].enabled = true;
        securityCams[index].viewSecurity();
        changeText();
    }

    private void stopViewingSecurity()
    {
        playerCamera.enabled = true;
        securityCams[index].stopViewingSecurity();
        cameras[index].enabled = false;
        GameData.viewSecurityCam = false;
        playerMovement.enabled = true;
        playerMouseLook.enabled = true;
        playerMouseLook.resetCamera();
        GameData.bottomText.text = "";
        securityCameraOverlay.SetActive(false);
    }

    private void changeText()
    {
        secCamOverlayText.text = securityCams[index].cameraName switch
        {
            CameraNames.lobbyTellers => "Caméra Caissiers",
            CameraNames.guichets => "Caméra Guichets",
            CameraNames.sofa => "Caméra Sofas",
            CameraNames.coffrefort => "Caméra Coffre-fort",
            CameraNames.manager => "Caméra Manager",
            CameraNames.couloir => "Caméra Couloir",
            _ => secCamOverlayText.text
        };
        if (!GameData.CameraActiveDictionary[securityCams[index].cameraName.ToString()])
            secCamOverlayText.text += "\nDÉSACTIVÉE";
    }

    private void checkPlayerVisibility()
    {
        if (!GameData.hasGameStarted) return;

        bool isDetected = securityCams.Aggregate(false, (current, secCam) => current || secCam.checkPlayerVisibility());

        GameData.isPlayerDetected = isDetected;
    }
}