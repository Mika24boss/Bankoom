using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class StartMenu : MonoBehaviour
{
    /// <summary>
    /// Objet à la racine du start menu
    /// </summary>
    public GameObject startMenu;

    /// <summary>
    /// Objet à la racine du UI
    /// </summary>
    public GameObject UI;

    [SerializeField] private Volume ppVolume;

    /// <summary>
    /// Commencer la partie
    /// </summary>
    public void gameStart()
    {
        startMenu.SetActive(false);
        UI.SetActive(true);
        GameData.hasGameStarted = true;
        Cursor.lockState = CursorLockMode.Locked;
        if (ppVolume.profile.TryGet(out DepthOfField dof)) dof.active = false;
    }

    /// <summary>
    /// Quitter le jeu
    /// </summary>
    public void appQuit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}