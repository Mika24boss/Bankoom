using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAudio : MonoBehaviour
{
    /// <summary>
    /// Tableau contenant les clips des footsteps
    /// </summary>
    [SerializeField] private AudioClip[] footsteps;

    /// <summary>
    /// Tableau contenant les clips des ouchs
    /// </summary>
    [SerializeField] private AudioClip[] ouchs;

    /// <summary>
    /// Source de l'audio du centre
    /// </summary>
    [SerializeField] private AudioSource midSource;

    /// <summary>
    /// Source de l'audio de gauche
    /// </summary>
    [SerializeField] private AudioSource leftSource;

    /// <summary>
    /// Source de l'audio de droite
    /// </summary>
    [SerializeField] private AudioSource rightSource;

    /// <summary>
    /// Jouer le son d'un pas à gauche
    /// </summary>
    public void leftStep()
    {
        leftSource.clip = footsteps[Random.Range(0, footsteps.Length)];
        leftSource.Play();
    }

    /// <summary>
    /// Jouer le son d'un pas à droite
    /// </summary>
    public void rightStep()
    {
        rightSource.clip = footsteps[Random.Range(0, footsteps.Length)];
        rightSource.Play();
    }

    /// <summary>
    /// Jouer le son d'un ouch
    /// </summary>
    public void ouch()
    {
        midSource.clip = ouchs[Random.Range(0, ouchs.Length)];
        midSource.Play();
    }
}