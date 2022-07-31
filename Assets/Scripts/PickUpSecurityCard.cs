using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PickUpSecurityCard : MonoBehaviour
{
    /// <summary>
    /// Enum contenant les noms des clés/keycards
    /// </summary>
    public keyNames keyName;

    /// <summary>
    /// Distance maximale où on peut toujours pick up l'objet
    /// </summary>
    public float distanceForPickUp = 10f;

    private Ray ray = new Ray();

    /// <summary>
    /// Script AudioManager de la scène
    /// </summary>
    [SerializeField] private AudioManager _audioManager;

    private RaycastHit r = new RaycastHit();
    private Collider objectCollider;
    
    

    private void Start()
    {
        objectCollider = GetComponent<Collider>();




    }

    private void Update()
    {
      
            ray = GameData.mainCamera.ViewportPointToRay(GameData.cameraRayVector);


            if (objectCollider.Raycast(ray, out r, distanceForPickUp) && Input.GetMouseButtonDown(0)&&GameData.isSmallSafeOpen)
            {
            
                _audioManager.audioPickUp();
                GameData.KeyDictionary[keyName.ToString()] = true;
                transform.parent.gameObject.SetActive(false);
            }
        
    }
        
            
        
         
    


}