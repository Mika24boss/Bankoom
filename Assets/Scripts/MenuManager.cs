using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public static int Retour = -1;
    public GameObject menuIndication;
    
    private GameObject canvas;
    private CursorLockMode previousLockMode;

    // Start is called before the first frame update
    private void Start()
    {
        canvas = gameObject.transform.GetChild(0).gameObject;
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (!GameData.hasGameStarted) return;
        
        if (GameData.isMenuOpened)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                CloseMenu();
            }
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            OpenMenu();
        }
    }

    public void ButtonPressed(int btnIndex)
    {
        if (btnIndex.Equals(Retour))
        {
            CloseMenu();
        }
    }

    private void CloseMenu()
    {
        canvas.SetActive(false);
        GameData.isMenuOpened = false;
        Cursor.lockState = previousLockMode;
        menuIndication.SetActive(true);
    }

    private void OpenMenu()
    {
        canvas.SetActive(true);
        GameData.isMenuOpened = true;
        previousLockMode = Cursor.lockState;
        Cursor.lockState = CursorLockMode.None; //Confined;
        menuIndication.SetActive(false);
    }
}
