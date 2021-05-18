using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// Source de l'audio pour la musique du menu
    /// </summary>
    [SerializeField] private AudioSource menu;

    /// <summary>
    /// Source de l'audio pour le voice-over du tutoriel
    /// </summary>
    [SerializeField] private AudioSource tutorial;

    /// <summary>
    /// Source de l'audio pour le son quand on ramasse une clé ou la carte de sécurité
    /// </summary>
    [SerializeField] private AudioSource pickUp;

    /// <summary>
    /// Source de l'audio pour le boom quand le vault ferme
    /// </summary>
    [SerializeField] private AudioSource boom;

    /// <summary>
    /// Valeur de l'index de l'objectif au dernier frame (pour savoir s'il a changé ou pas)
    /// </summary>
    private int previousObj = 0;

    private void Update()
    {
        if (previousObj != 0 || GameData.currentObjectiveIndex < 1)
            return; //donc le tutoriel est soit deja fini, soit encore en cours
        endTutorialSound();
        previousObj = GameData.currentObjectiveIndex;
    }

    /// <summary>
    /// Fade out la musique de menu et commencer le voice-over du tutoriel
    /// </summary>
    public void startTutorialSound()
    {
        if (GameData.currentObjectiveIndex == 0) StartCoroutine(fade(menu, 2f, 0f, () => tutorial.Play()));
    }

    /// <summary>
    /// Fade out le voice-over du tutoriel
    /// </summary>
    private void endTutorialSound()
    {
        if (tutorial.isPlaying) StartCoroutine(fade(tutorial, 1.5f, 0f, null));
    }

    /// <summary>
    /// Fade l'audio vers le targetVolume
    /// </summary>
    /// <param name="audioSource">audio à fade</param>
    /// <param name="duration">durée du fade</param>
    /// <param name="targetVolume">volume final voulu</param>
    /// <param name="action">action effectuée après le fade (écrire null pour rien faire)</param>
    /// <returns></returns>
    private IEnumerator fade(AudioSource audioSource, float duration, float targetVolume, Action action)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }

        action?.Invoke();
    }

    /// <summary>
    /// Jouer le son quand le joueur pick up une clé/carte de sécurité
    /// </summary>
    public void audioPickUp()
    {
        pickUp.Play();
    }

    /// <summary>
    /// Jouer le son quand la porte du vault ferme
    /// </summary>
    public void audioBoom()
    {
        boom.Play();
    }
}