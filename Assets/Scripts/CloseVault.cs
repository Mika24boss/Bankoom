using UnityEngine;
using UnityEngine.Events;

public class CloseVault : MonoBehaviour
{
    /// <summary>
    /// Event quand le joueur rentrer dedans
    /// </summary>
    [SerializeField] private UnityEvent laserEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            laserEvent.Invoke();
            gameObject.SetActive(false);
        }
    }
}
