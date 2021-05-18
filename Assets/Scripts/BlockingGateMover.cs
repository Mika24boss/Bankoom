using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using Random = System.Random;

public class BlockingGateMover : MonoBehaviour
{
    /// <summary>
    /// Courbe de la vitesse de l'animation
    /// </summary>
    [SerializeField] private AnimationCurve curve;

    /// <summary>
    /// Audio du portail qui ouvre
    /// </summary>
    [SerializeField] private AudioClip gateOpen;

    /// <summary>
    /// Audio du portail qui ferme
    /// </summary>
    [SerializeField] private AudioClip gateClose;

    /// <summary>
    /// Tableau contenant les sources d'audio pour l'alarme
    /// </summary>
    [SerializeField] private AudioSource[] alarmSources;

    /// <summary>
    /// Source de l'audio pour le portail
    /// </summary>
    private AudioSource _audioSource;

    /// <summary>
    /// Dernière valeur de GameData.isPlayDetected
    /// </summary>
    private bool _lastValue;

    private Random _random = new Random();

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (GameData.isPlayerDetected == _lastValue) return; //donc rien n'a changé
        if (GameData.isPlayerDetected) //fermer le portail
        {
            transform.DOLocalMoveY(5.509f, 0.5f).SetEase(curve);
            _audioSource.clip = gateClose;
            _audioSource.Play();
            foreach (AudioSource source in alarmSources)
            {
                source.Play();
            }
        }
        else StartCoroutine(Wait2NdTest(0.8f)); //joueur n'est pas détecté

        _lastValue = GameData.isPlayerDetected; //update la valeur
    }

    /// <summary>
    /// Attend un certain montant de temps pour vérifier si le joueur n'est toujours pas détecté
    /// </summary>
    /// <param name="delay">Délai à attendre</param>
    /// <returns></returns>
    private IEnumerator Wait2NdTest(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (GameData.isPlayerDetected) yield break;

        transform.DOLocalMoveY(7.759f, 1f);
        _audioSource.clip = gateOpen;
        _audioSource.Play();
        foreach (AudioSource source in alarmSources)
        {
            source.Stop();
        }
    }
}