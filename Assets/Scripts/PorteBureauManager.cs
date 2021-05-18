using UnityEngine;

public class PorteBureauManager : MonoBehaviour
{
    /// <summary>
    /// Animator de la porte du manager
    /// </summary>
    private Animator _animator;

    /// <summary>
    /// Source de l'audio de la porte
    /// </summary>
    private AudioSource _audioSource;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Ouvrir la porte du manager
    /// </summary>
    public void openDoor()
    {
        _animator.SetTrigger("Open");
        _audioSource.Play();
    }
}