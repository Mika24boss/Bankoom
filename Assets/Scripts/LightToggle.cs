using System;
using UnityEngine;

public class LightToggle : MonoBehaviour
{
    /// <summary>
    /// Enum des noms des caméras
    /// </summary>
    public CameraNames cameraName;

    /// <summary>
    /// MeshRenderer du bouton ON
    /// </summary>
    [SerializeField] private MeshRenderer mrOn;

    /// <summary>
    /// MeshRenderer du bouton OFF
    /// </summary>
    [SerializeField] private MeshRenderer mrOff;

    /// <summary>
    /// Distance maximale où le joueur peut encore cliquer
    /// </summary>
    [SerializeField] private float distanceForClick;

    private Ray ray;
    private RaycastHit r = new RaycastHit();
    private Collider objectCollider;

    private void Start()
    {
        objectCollider = GetComponent<Collider>();
    }

    private void Update()
    {
        
        ray = GameData.mainCamera.ViewportPointToRay(GameData.cameraRayVector);
        if (objectCollider.Raycast(ray, out r, distanceForClick) && Input.GetMouseButtonDown(0))
        {
            if (mrOn.material.IsKeywordEnabled("_EMISSION")) //ON est on
            {
                mrOn.material.DisableKeyword("_EMISSION");
                mrOff.material.EnableKeyword("_EMISSION");
                GameData.CameraActiveDictionary[cameraName.ToString()] = false;
            }
            else //OFF est on
            {
                mrOn.material.EnableKeyword("_EMISSION");
                mrOff.material.DisableKeyword("_EMISSION");
                GameData.CameraActiveDictionary[cameraName.ToString()] = true;
            }


        }
    }
}