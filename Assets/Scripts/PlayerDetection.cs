using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    /// <summary>
    /// True = joueur dans trigger collider, false sinon
    /// </summary>
    public bool isPlayerClose;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerClose = false;
        }
    }
}
