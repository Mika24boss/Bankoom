using System.Collections;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    /// <summary>
    /// Animator de la porte
    /// </summary>
    private Animator doorAnimator;

    /// <summary>
    /// Animator du joueur
    /// </summary>
    private Animator playerAnimator;

    /// <summary>
    /// True = porte ouverte, false sinon
    /// </summary>
    private bool isOpen;

    /// <summary>
    /// Référence au PlayerDetection de la porte
    /// </summary>
    private PlayerDetection playerDetection;

    /// <summary>
    /// Source de l'audio de la porte
    /// </summary>
    private AudioSource audioSource;

    private void Start()
    {
        doorAnimator = GetComponent<Animator>();
        playerAnimator = GameData.player.GetComponent<Animator>();
        playerDetection = transform.GetComponentInChildren<PlayerDetection>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (isOpen || playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("OpeningLock") ||
            playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Opening")) return;

        if (!playerDetection.isPlayerClose) return;

        if (CompareTag("SecurityDoor1"))
        {
            GameData.doorNumber = 1;

            if (GameData.KeyDictionary["hasKey1"])
            {
                opening();
            }
            else
            {
                StartCoroutine(WaitExecution(2f, "Vous n'avez pas la clé!"));
                playerAnimator.SetTrigger("DoorLock");
            }
        }
        else if (CompareTag("SecurityDoor2"))
        {
            GameData.doorNumber = 2;
            opening();
        }
        else if (CompareTag("JanitorDoor"))
        {
            if (!GameData.isPlayerDetected)
            {
                GameData.doorNumber = 3;
                opening();
            }
            else
            {
                StartCoroutine(WaitExecution(3f,
                    "Une caméra de sécurité vous a repéré! Il faut découvrir comment la tourner."));
            }
        }
        else if (CompareTag("TutorialDoor"))
        {
            GameData.doorNumber = 4;

            if (GameData.KeyDictionary["hasKeyTut"])
            {
                GameData.currentObjectiveIndex = 1;
                opening();
            }
            else
            {
                StartCoroutine(WaitExecution(2f, "Vous n'avez pas la clé!"));
                playerAnimator.SetTrigger("DoorLock");
            }
        }
    }

    /// <summary>
    /// Afficher un message à l'écran pour une durée de temps
    /// </summary>
    /// <param name="delay">Durée du message en secondes</param>
    /// <param name="msg">Message à afficher</param>
    /// <returns></returns>
    private IEnumerator WaitExecution(float delay, string msg)
    {
        GameData.bottomText.text = msg;
        yield return new WaitForSeconds(delay);
        GameData.bottomText.text = "";
    }

    /// <summary>
    /// Ouvrir la porte
    /// </summary>
    private void opening()
    {
        audioSource.Play();
        doorAnimator.SetTrigger("Open");
        playerAnimator.SetTrigger("DoorOpen");
        isOpen = true;
    }
}