using System;
using UnityEngine;
using UnityEngine.Events;

public class LaserButton : MonoBehaviour
{
   /// <summary>
   /// Quoi faire quand on clique sur le bouton rouge
   /// </summary>
   [SerializeField] private UnityEvent laserButtonEvent;

   private Collider objectCollider;

   private Ray ray;
   private RaycastHit r = new RaycastHit();

   private void Start()
   {
      objectCollider = GetComponent<Collider>();
   }

   private void Update()
   {
      ray = GameData.mainCamera.ViewportPointToRay(GameData.cameraRayVector) ;
      if (objectCollider.Raycast(ray, out r, 3) && Input.GetMouseButtonDown(0))    laserButtonEvent.Invoke();;
   }



}
