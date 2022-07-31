using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class KeypadButtonScript : MonoBehaviour
{
    public ButtonEvent buttonEvent;


    private void Update()
    {
    }

    private void OnMouseDown()
    {
       
        if (!GameData.isUsingKeyPad) return;
        buttonEvent.Invoke(0);
    }
}

[Serializable]
public class ButtonEvent : UnityEvent<int>
{
}
