using UnityEngine;

public class BtnUIScript : MonoBehaviour
{
    
    [Header("Button Text")] 
    public string text;
    public int fontSize = 45;
    
    private float _width;
    private float _height;
    private GUIStyle _style;
    private bool _styleIsInit;
    
  
    private void Start()
    {
        _width = fontSize * text.Length / 1.5f;
        _height = fontSize*2;
        enabled = false;
    }
/*
 *Crée un bouton en bas à droite de l'écran
 */
    private void OnGUI()
    {
        if (!enabled) return;
        if (!_styleIsInit)
        {
            _style = GUI.skin.button;
            _style.fontSize = fontSize;
            _styleIsInit = true;
        }

        if (GUI.Button(new Rect(Screen.width - _width - 50, Screen.height - _height - 50, _width, _height), text, _style))
        {
            gameObject.SendMessage("UIBtnAction");
        }
    }
}
