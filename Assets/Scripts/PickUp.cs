using UnityEngine;

public class PickUp : MonoBehaviour
{
    /// <summary>
    /// Enum contenant les noms des clés/keycards
    /// </summary>
    public keyNames keyName;

    /// <summary>
    /// Distance maximale où on peut toujours pick up l'objet
    /// </summary>
    public float distanceForPickUp = 10f;

    /// <summary>
    /// Script AudioManager de la scène
    /// </summary>
    [SerializeField] private AudioManager _audioManager;

    private void OnMouseDown()
    {
        if (!((GameData.player.transform.position - transform.position).sqrMagnitude <= distanceForPickUp)) return;
        _audioManager.audioPickUp();
        GameData.KeyDictionary[keyName.ToString()] = true;
        transform.parent.gameObject.SetActive(false);
    }
}
/// <summary>
/// Les noms des clés et keycards
/// </summary>
public enum keyNames
{
    //copy from GameData
    hasKey1,
    hasKeyTut,
    hasKeycard
}