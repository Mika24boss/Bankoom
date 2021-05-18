using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Laser : MonoBehaviour
{
    /// <summary>
    /// Que faire quand le joueur rentre dans un laser
    /// </summary>
    [SerializeField] private UnityEvent laserEvent;

    /// <summary>
    /// Distance parcourue dans un aller
    /// </summary>
    [Range(0f, 3f)] [SerializeField] private float movementRange;

    /// <summary>
    /// Durée en secondes d'un aller
    /// </summary>
    [Range(0f, 8f)] [SerializeField] private float movementDuration;

    /// <summary>
    /// Début du trajet
    /// </summary>
    private Vector3 end1 = Vector3.zero;

    /// <summary>
    /// Fin du trajet
    /// </summary>
    private Vector3 end2 = Vector3.zero;

    /// <summary>
    /// True = laser est fonctionnel, false sinon
    /// </summary>
    private bool isEnabled = true;

    /// <summary>
    /// Collider du laser
    /// </summary>
    private CapsuleCollider collider;

    private void Start()
    {
        Vector3 ini = transform.localPosition;
        Vector3 fw = transform.forward;
        end1 = ini - fw * movementRange;
        end2 = ini + fw * movementRange;
        transform.localPosition = end1;
        collider = GetComponent<CapsuleCollider>();
    }

    private void FixedUpdate()
    {
        if (!isEnabled || movementRange == 0f)
            return; //si le laser n'est pas activé ou si le laser n'a pas besoin de bouger

        if (transform.localPosition.Equals(end1))
        {
            transform.DOLocalMove(end2, movementDuration);
        }
        else if (transform.localPosition.Equals(end2))
        {
            transform.DOLocalMove(end1, movementDuration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            laserEvent.Invoke();
        }
    }

    /// <summary>
    /// Désactiver le laser et le monter dans le plafond
    /// </summary>
    public void stopMoving()
    {
        isEnabled = false;
        transform.DOKill();
        transform.DOLocalMoveY(50.67f, 4.5f);
        collider.enabled = false;
    }
}