using UnityEngine;
using Random = UnityEngine.Random;

public class SecurityCam : MonoBehaviour
{
    /// <summary>
    /// Enum des noms des caméras
    /// </summary>
    public CameraNames cameraName;

    /// <summary>
    /// True = dessiner les gizmos dans le editor
    /// </summary>
    public bool drawGizmos = true;

    /// <summary>
    /// Quels layers il faut verifier
    /// </summary>
    public LayerMask layerMaskCheck;

    /// <summary>
    /// Quelles parties du corps du joueur il faut vérifier
    /// </summary>
    public Transform[] bodyPartsToCheck;

    /// <summary>
    /// Script MouseLookSecurity de la caméra
    /// </summary>
    private MouseLookSecurity mouseLookSecurity;

    /// <summary>
    /// CharacterController du joueur
    /// </summary>
    private CharacterController characterController;

    /// <summary>
    /// Caméra de sécurité
    /// </summary>
    private Camera securityCamera;

    /// <summary>
    /// Tableau contenant les rays à dessiner dans le editor
    /// </summary>
    private Ray[] rays;

    private void Start()
    {
        securityCamera = GetComponent<Camera>();
        mouseLookSecurity = GetComponent<MouseLookSecurity>();
        characterController = GameData.player.GetComponent<CharacterController>();
        rays = new Ray[bodyPartsToCheck.Length];
    }

    /// <summary>
    /// Enable la caméra quand le joueur la regarde
    /// </summary>
    public void viewSecurity()
    {
        if (GameData.CameraActiveDictionary[cameraName.ToString()]) mouseLookSecurity.enabled = true;
    }

    /// <summary>
    /// Disable la caméra quand le joueur arrête de la regarder
    /// </summary>
    public void stopViewingSecurity()
    {
        mouseLookSecurity.enabled = false;
    }

    /// <summary>
    /// Calculer si la caméra voit le joueur
    /// </summary>
    /// <returns>True si le joueur est détecté, false sinon</returns>
    public bool checkPlayerVisibility()
    {
        if (!GameData.CameraActiveDictionary[cameraName.ToString()]) return false; //si la caméra n'est pas active

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(securityCamera);
        Bounds bounds = new Bounds(characterController.bounds.center,
            characterController.bounds.size - new Vector3(0.2f, 0, 0.2f)); //bounds délimitant le joueur
        if (!GeometryUtility.TestPlanesAABB(planes, bounds))
            return false; //si le joueur n'est pas dans le champ de la vision de la caméra

        bool isDetected = false;
        Vector3 playerPos = Vector3.zero; //position du joueur selon le viewport de la camera

        for (int i = 0; i < bodyPartsToCheck.Length; i++)
        {
            if (isDetected) continue;

            playerPos = securityCamera.WorldToViewportPoint(bodyPartsToCheck[i].position);
            rays[i] = securityCamera.ViewportPointToRay(playerPos);

            if (!Physics.Raycast(rays[i], out RaycastHit hit, layerMaskCheck)) continue;
            isDetected =
                isDetected || hit.collider.CompareTag("Player"); //dès qu'il y a un hit, la variable va rester true
        }

        if (isDetected)
        {
            print("Player detected! " + cameraName.ToString());
        }

        return (isDetected);
    }

    private void OnDrawGizmos()
    {
        if (rays == null) return;
        if (!drawGizmos) return;

        foreach (var ray in rays)
        {
            Gizmos.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            Gizmos.DrawRay(ray.origin, ray.direction * 500);
        }
    }
}

/// <summary>
/// Les noms des caméras
/// </summary>
public enum CameraNames
{
    lobbyTellers,
    guichets,
    sofa,
    coffrefort,
    manager,
    couloir,
}