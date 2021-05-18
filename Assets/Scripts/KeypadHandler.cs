using System.Collections;
using Scenes;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(BtnUIScript))]
public class KeypadHandler : MonoBehaviour
{
    [Tooltip("Le code a 4 chiffre pour ouvrir le cadena")]
    public string code;

    

    public float distanceForClick = 2f;

    [SerializeField] private AudioClip _keypadEnter;
    [SerializeField] private AudioClip _keypadExit;
    [SerializeField] private AudioClip _keypadCorrect;
    [SerializeField] private AudioClip _keypadWrong;
    [SerializeField] private UnityEvent keypadEvent;

    private GameObject _player;
    private AudioSource _audioSource;

    
    private BtnUIScript _btnQuit;
    private KeypadLightManager _lightManager;

    private LockOnCameraManager _cameraManager;

    

    private bool _alreadyUnlocked;
    

    private string _codeInput = "";

    private LightUp _lightUp;
    private BoxCollider _boxCollider;

    private void Start()
    {
       

        _player = GameObject.FindWithTag("Player");
    

        if (_player.Equals(null))
        {
            throw new MissingObjectException("couldn't find gameObject with tag Player");
        }

     
        _btnQuit = GetComponent<BtnUIScript>();
        _lightManager = GetComponentInChildren<KeypadLightManager>();
        _cameraManager = GetComponentInChildren<LockOnCameraManager>();
        _lightUp = GetComponent<LightUp>();
        _boxCollider = GetComponent<BoxCollider>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (_alreadyUnlocked || GameData.isUsingKeyPad) return;
        if (!((GameData.player.transform.position - transform.position).sqrMagnitude <= distanceForClick)) return;
        SwitchViewMode();
    }

    private void Update()
    {
        if (_alreadyUnlocked || GameData.isUsingKeyPad)
        {
            _lightUp.enabled = false;
            _lightUp.meshRenderer.material.DisableKeyword("_EMISSION");
        }
        else _lightUp.enabled = true;

       
    }

    private void SwitchViewMode()
    {
        
        _boxCollider.enabled = !_boxCollider.enabled;
        _cameraManager.SwitchCam();
        GameData.isUsingKeyPad = !GameData.isUsingKeyPad;
        _btnQuit.enabled = !_btnQuit.enabled;
       

        _audioSource.clip = _audioSource.clip.Equals(_keypadEnter) ? _keypadExit : _keypadEnter;
        _audioSource.Play();
    }

    public void NewInput(int nb)
    {


        if (nb == -1) //enter
        {
            if (_codeInput.Equals(code))
            {
                _alreadyUnlocked = true;
                SwitchViewMode();

                keypadEvent.Invoke();
                _audioSource.clip = _keypadCorrect;
                _audioSource.Play();
            }
            else if (_codeInput.Length == 4)
            {
                _codeInput = "";
                _lightManager.SetLight(0);
                _audioSource.clip = _keypadWrong;
                _audioSource.Play();
            }
        }
        else if (nb == -2) //clear
        {
            _codeInput = "";
            _lightManager.SetLight(0);
        }
        else //un nb est entré
        {
            if (_codeInput.Length < 4)
            {
                _codeInput += nb.ToString();
                _lightManager.SetLight(_codeInput.Length);
            }
            else
            {
                StartCoroutine(WaitExecution(2.5f));
            }
        }

    }

    public void UIBtnAction()
    {
        SwitchViewMode();
        _codeInput = "";
    }

    private IEnumerator WaitExecution(float delay)
    {
        GameData.bottomText.text = "Vous avez déjà entré 4 chiffres!";
        yield return new WaitForSeconds(delay);
        GameData.bottomText.text = "";
    }

    public void reset()
    {
        _alreadyUnlocked = false;
        _codeInput = "";
        _lightManager.SetLight(0);
    }
}