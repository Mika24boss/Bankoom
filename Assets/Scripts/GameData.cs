using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class GameData
{
    /// <summary>
    /// Dictionnaire des clés à ramasser, true = joueur a la clé, false sinon
    /// </summary>
    public static Dictionary<string, bool> KeyDictionary = new Dictionary<string, bool>()
    {
        {"hasKey1", false},
        {"hasKeyTut", false},
        {"hasKeycard", false}
    };

    /// <summary>
    /// Dictionnaire des caméras, true = caméra active, false = désactivée
    /// </summary>
    public static Dictionary<string, bool> CameraActiveDictionary = new Dictionary<string, bool>()
    {
        {"lobbyTellers", true},
        {"guichets", true},
        {"sofa", true},
        {"coffrefort", true},
        {"manager", true},
        {"couloir", true}
    };

    /// <summary>
    /// True = joueur regarde les caméras, false sinon
    /// </summary>
    public static bool viewSecurityCam;

    /// <summary>
    /// True = joueur utilise keypad, false sinon
    /// </summary>
    public static bool isUsingKeyPad;


    public static bool isUsingFlagComputer = false;
    /// <summary>
    /// True = joueur utilise ordinateur, false sinon
    /// </summary>

    /// <summary>
    /// True = joueur est détecté, false sinon
    /// </summary>
    public static bool isPlayerDetected;

    /// <summary>
    /// True = menu ouvert à l'écran, false sinon
    /// </summary>
    public static bool isMenuOpened;

    /// <summary>
    /// True = jeu est commencé, false = encore dans le menu de départ
    /// </summary>
    public static bool hasGameStarted;

    /// <summary>
    /// Quelle porte le joueur ouvre (ou essaie d'ouvrir)
    /// 1 = premiere porte du bureau de securite
    /// 2 = 2e porte du bureau de securite
    /// 3 = janitor's closet door
    /// 4 = tutorial door
    /// </summary>
    public static int doorNumber;

    /// <summary>
    /// On est rendu à quel objectif
    /// 0 = tutoriel
    /// 1 = désactiver securiter
    /// 2 = trouver code coffre fort
    /// 3 - sortir coffre fort
    /// </summary>
    public static int currentObjectiveIndex = 0;

    /// <summary>
    /// Référence au joueur
    /// </summary>
    public static GameObject player;

    /// <summary>
    /// Référence au texte en bas de l'écran
    /// </summary>
    public static TMP_Text bottomText;
}