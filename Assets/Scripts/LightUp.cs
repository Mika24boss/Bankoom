using UnityEngine;

public class LightUp : MonoBehaviour
{
    /// <summary>
    /// Quels layers il faut vérifier
    /// </summary>
    public LayerMask layerMaskCheck;

    /// <summary>
    /// Distance maximale où l'objet va lgiht up quand le joueur le regarde
    /// </summary>
    public float distanceForLightUp = 20f;

    /// <summary>
    /// True = print distance au joueur dans la console
    /// </summary>
    public bool printDistance;

    /// <summary>
    /// Mesh renderer a light up
    /// </summary>
    public MeshRenderer meshRenderer;

    /// <summary>
    /// Index du matériel si ce n'est pas le premier sur la liste (laisser à 0 sinon)
    /// </summary>
    [SerializeField] private int indexOfMaterial = 0;

    /// <summary>
    /// Caméra du joueur
    /// </summary>
    private Camera playerCamera;

    private void Start()
    {
        playerCamera = GameData.player.GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        Ray ray = new Ray();
        meshRenderer.materials[indexOfMaterial].DisableKeyword("_EMISSION");

        if (printDistance) print((GameData.player.transform.position - transform.position).sqrMagnitude);
        if (!((GameData.player.transform.position - transform.position).sqrMagnitude <= distanceForLightUp)) return;

        ray.origin = playerCamera.transform.position;
        ray.direction = playerCamera.transform.forward;
        if (Physics.Raycast(ray, out RaycastHit hit, layerMaskCheck) &&
            hit.collider.gameObject.Equals(gameObject))
        {
            meshRenderer.materials[indexOfMaterial].EnableKeyword("_EMISSION");
        }
    }
}