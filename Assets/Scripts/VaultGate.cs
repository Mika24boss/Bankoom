using DG.Tweening;
using UnityEngine;

public class VaultGate : MonoBehaviour
{
    /// <summary>
    /// True = portail ouvert, false sinon
    /// </summary>
    public bool isOpen = true;

    /// <summary>
    /// Courbe de la vitesse de l'animation de fermeture
    /// </summary>
    [SerializeField] private AnimationCurve curve;

    /// <summary>
    /// Son du portail qui ouvre
    /// </summary>
    [SerializeField] private AudioClip gateOpen;

    /// <summary>
    /// Son du portail qui ferme
    /// </summary>
    [SerializeField] private AudioClip gateClose;

    /// <summary>
    /// Source de l'audio du portail
    /// </summary>
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Fermer le portail
    /// </summary>
    public void closeGate()
    {
        if (!isOpen) return;
        transform.DOLocalMoveY(45.45f, 0.5f).SetEase(curve);
        _audioSource.clip = gateClose;
        _audioSource.Play();
        isOpen = false;
    }

    /// <summary>
    /// Ouvrir le portail
    /// </summary>
    public void openGate()
    {
        if (isOpen) return;
        transform.DOLocalMoveY(48.2f, 1f);
        _audioSource.clip = gateOpen;
        _audioSource.Play();
        isOpen = true;
    }
}