using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpenVault : MonoBehaviour
{
    /// <summary>
    /// Script VaultGate du portail
    /// </summary>
    [SerializeField] private VaultGate _vaultGate;

    /// <summary>
    /// Keypad du coffre-fort
    /// </summary>
    [SerializeField] private KeypadHandler _keypadHandler;

    /// <summary>
    /// Tableau de tous les lasers
    /// </summary>
    [SerializeField] private Laser[] _lasers;

    /// <summary>
    /// AudioManager de la scène
    /// </summary>
    [SerializeField] private AudioManager _audioManager;

    /// <summary>
    /// Son du coffre-fort qui ouvre
    /// </summary>
    [SerializeField] private AudioClip _clipOpen;

    /// <summary>
    /// Son du coffre-fort qui ferme
    /// </summary>
    [SerializeField] private AudioClip _clipClose;

    /// <summary>
    /// MouseLook du joueur
    /// </summary>
    [SerializeField] private MouseLook _playerMouseLook;

    /// <summary>
    /// Black background
    /// </summary>
    [SerializeField] private Image _black;

    /// <summary>
    /// Logo final
    /// </summary>
    [SerializeField] private Image _logo;

    /// <summary>
    /// Slogan à la fin
    /// </summary>
    [SerializeField] private TMP_Text _slogan;

    /// <summary>
    /// 2 en-dessous du logo
    /// </summary>
    [SerializeField] private TMP_Text _2;

    /// <summary>
    /// Quit button pour la fin
    /// </summary>
    [SerializeField] private Image _quitButton;

    /// <summary>
    /// X sur le quit button
    /// </summary>
    [SerializeField] private TMP_Text _quitX;
    
    /// <summary>
    /// Le UI
    /// </summary>
    [SerializeField] private GameObject _UI;

    /// <summary>
    /// Graphic raycaster du canvas ending
    /// </summary>
    [SerializeField] private GraphicRaycaster _raycaster;
    
    /// <summary>
    /// Source de l'audio du coffre-fort
    /// </summary>
    private AudioSource _audioSource;

    /// <summary>
    /// Animator du coffre-fort
    /// </summary>
    private Animator _animator;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    public void Open()
    {
        if (!_vaultGate.isOpen) //on a essayé de l'ouvrir quand le portail était fermé
        {
            StartCoroutine(WaitExecution(3.5f,
                "Le portail est verrouillé! Il faut appuyer le bouton rouge pour le réinitialiser."));
            _keypadHandler.reset();
        }
        else //ouvrir
        {
            GameData.currentObjectiveIndex = 3;
            _audioSource.clip = _clipOpen;
            _audioSource.Play();
            _animator.SetTrigger("Open");
            foreach (Laser laser in _lasers)
            {
                laser.stopMoving();
            }
        }
    }

    /// <summary>
    /// Afficher un message pendant une certaine durée
    /// </summary>
    /// <param name="delay">Durée du message en secondes</param>
    /// <param name="msg">Message affiché en bas de l'écran</param>
    /// <returns></returns>
    private IEnumerator WaitExecution(float delay, string msg)
    {
        GameData.bottomText.text = msg;
        yield return new WaitForSeconds(delay);
        GameData.bottomText.text = "";
    }

    /// <summary>
    /// Fermer le vault + cutscene + ending
    /// </summary>
    public void closeVault()
    {
        GameData.hasGameStarted = false;
        StartCoroutine(finale());
    }
    /// <summary>
    /// Faire les fade-ins de fin
    /// </summary>
    /// <returns></returns>
    private IEnumerator finale()
    {
        _raycaster.enabled = true;
        _UI.SetActive(false);
        _playerMouseLook.endAnim();
        yield return new WaitForSeconds(1f);
        _audioSource.clip = _clipClose;
        _audioSource.volume = 0.5f;
        _audioSource.Play();
        _audioManager.audioBoom();
        _animator.SetTrigger("Close");
        yield return new WaitForSeconds(6.5f);
        _audioSource.DOFade(0f, 1.5f);
        yield return new WaitForSeconds(2f);
        _black.DOFade(1f, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.5f);
        _slogan.DOFade(1f, 0.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2f);
        _logo.DOFade(1f, 0.5f).SetEase(Ease.Linear);
        _2.DOFade(1f, 0.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2f);
        Cursor.lockState = CursorLockMode.None;
        _quitButton.gameObject.SetActive(true);
        _quitButton.DOFade(1f, 0.5f).SetEase(Ease.Linear);
        _quitX.DOFade(1f, 0.5f).SetEase(Ease.Linear);
    }
}