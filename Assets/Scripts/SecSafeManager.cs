using UnityEngine;

public class SecSafeManager : MonoBehaviour
{
    /// <summary>
    /// Animator du petit coffre-fort
    /// </summary>
    private Animator _animator;

    /// <summary>
    /// Source de l'audio du petit coffre-fort
    /// </summary>
    private AudioSource _audioSource;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Ouvrir le petit coffre-fort
    /// </summary>
    public void OpenLockAction()
    {
        _animator.SetTrigger("Open");
        _audioSource.Play();
    }
}