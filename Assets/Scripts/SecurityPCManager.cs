using System;
using System.Collections;
using UnityEngine;

public class SecurityPCManager : MonoBehaviour
{
    /// <summary>
    /// Distance maximale où le joueur peut cliquer sur l'ordi
    /// </summary>
    public float distanceForClick = 5f;

    /// <summary>
    /// Script MouseLook du joueur
    /// </summary>
    private MouseLook playerMouseLook;

    private Ray ray;
    private RaycastHit r = new RaycastHit();
    private Collider objectCollider;
    private void Start()
    {
        playerMouseLook = GameData.player.GetComponentInChildren<MouseLook>();
        objectCollider = GetComponent<Collider>();

    }

    private void Update()
    {
    
        
            ray =GameData.mainCamera.ViewportPointToRay(GameData.cameraRayVector);


            if (objectCollider.Raycast(ray, out r, 3) && Input.GetMouseButtonDown(0))
            {


              
                if (!GameData.KeyDictionary["hasKeycard"])
                {
                    StartCoroutine(WaitExecution(2.5f));
                }
                else
                {
                    playerMouseLook.startTransition();
                    playerMouseLook.enabled = false;
                }

            }
        
    }

    private void OnMouseDown()
    {
      
    }

    /// <summary>
    /// Afficher un message à l'écran durant une certaine durée
    /// </summary>
    /// <param name="delay">Montant de temps que le message sera à l'ecran en seconde</param>
    /// <returns></returns>
    private IEnumerator WaitExecution(float delay)
    {
        GameData.bottomText.text = "Vous n'avez pas la carte de sécurité!";
        yield return new WaitForSeconds(delay);
        GameData.bottomText.text = "";
    }
}