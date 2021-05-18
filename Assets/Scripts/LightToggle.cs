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

    private void OnMouseDown()
    {
        if (!((GameData.player.transform.position - transform.position).sqrMagnitude <= distanceForClick)) return; //joueur est trop loin

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