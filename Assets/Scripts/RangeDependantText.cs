using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]//BoxCollider doit etre un trigger

public class RangeDependantText : MonoBehaviour
{
    
    [Header("UI Message")] 
    public string text;
   
    private bool _showText;
    
    private void Start()
    {
        if (text.Equals(null))
        {
            throw new NullReferenceException("specify what should be written on UI when player enter range");
        }

      
    }

    /**
     * appeler quand le joueur entre dans le BoxCollider
     *
     * other: collider de l'object entrer en contact
     *
     * si other est le joueur afficher le texte sur le UI
     */
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Player"))
        {
            _showText = true;
            GameData.bottomText.text = text;
        }
    }
    
    /**
     * appeler quand le joueur sort du BoxCollider
     *
     * other: collider de l'object qui est sorti
     *
     * si other est le joueur arreter d'afficher le texte sur le UI
     */
    private void OnTriggerExit(Collider other)
    {
      
        if (other.CompareTag("Player"))
        {
            _showText = false;
            GameData.bottomText.text = "";
        }
    }

    /*/**
     * change le style du texte et l'affiche sur le UI si
     * est enabled et showText est true
     #1#
    private void OnGUI()
    {
        if (_showText && enabled)
        {
            if(!_styleIsInit)
            {
                _style = GUI.skin.label;
                _style.fontSize = fontSize;
                _styleIsInit = true;
            }
            GUI.Label(new Rect((Screen.width/2f) - (_width/2), 4*Screen.height/7f, _width, _height), text, _style);
        }
    }*/

    /**
     * getter qui retrourne true si le joueur est
     * dans le BoxCollider
     */
    public bool IsPlayerInRange()
    {
        return _showText;
    }
    
}
