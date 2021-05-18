
using UnityEngine;

public class TestMenuCanvasManager : MonoBehaviour
{
    private void OnEnable()
    {
        GameData.isMenuOpened = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnDisable()
    {
        GameData.isMenuOpened = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }
}
