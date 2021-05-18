using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerCameraSwitcher : MonoBehaviour
{
    // Start is called before the first frame update

    private LockOnCameraManager _cameraManager;
    public float distanceForClick = 0;
    private BoxCollider _boxCollider;


    private BtnUIScript _GUI;
    void Start()
    {
        _cameraManager = GetComponentInChildren<LockOnCameraManager>();
        _boxCollider = GetComponent<BoxCollider>();
        _GUI = GetComponent<BtnUIScript>();
    }
    
 private void OnMouseDown(){
     
        if (GameData.isUsingFlagComputer) return;
        if (!((GameData.player.transform.position - transform.position).sqrMagnitude <= distanceForClick)) return;
        SwitchViewMode();
    }

 
   private void SwitchViewMode()
    {
      
        _boxCollider.enabled = !_boxCollider.enabled;
        _cameraManager.SwitchCam();
     
        _GUI.enabled = !_GUI.enabled;
      
    }

    // Update is called once per frame   
    
    public void UIBtnAction()
    {
        SwitchViewMode();
    }
}
