using UnityEngine;

[RequireComponent(typeof(Camera))]

public class LockOnCameraManager : MonoBehaviour
{

    private Camera _lockOnCam;
    private Camera _playerCam;
    private PlayerMovement _playerMovement;
    private Quaternion playerCamRotation;
    
    // Start is called before the first frame update
    private void Start()
    {
        _lockOnCam = GetComponent<Camera>();
        _playerCam = GameData.player.GetComponentInChildren<Camera>();
        _playerMovement = GameData.player.GetComponent<PlayerMovement>();
    }
    
    public void SwitchCam(/*Camera otherCamera*/)
    {
      
        _playerCam.enabled = !_playerCam.enabled;
        _lockOnCam.enabled = !_lockOnCam.enabled;
        if (_lockOnCam.enabled)
        {
            playerCamRotation = _playerCam.transform.localRotation;
            Cursor.lockState = CursorLockMode.None;
            _playerMovement.animator.SetInteger("Speed", 0);
           
        }
        else
        {
            _playerCam.transform.localRotation = playerCamRotation;
            Cursor.lockState = CursorLockMode.Locked;
        }
       
    }
}
