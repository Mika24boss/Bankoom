using UnityEngine;

public class ObjVisibleToggle : MonoBehaviour
{
    /// <summary>
    /// UI de l'objectif
    /// </summary>
    [SerializeField] private GameObject _objectiveUI;

    public void toggle()
    {
        _objectiveUI.SetActive(!_objectiveUI.activeSelf);
    }
}
