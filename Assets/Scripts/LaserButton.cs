using UnityEngine;
using UnityEngine.Events;

public class LaserButton : MonoBehaviour
{
   /// <summary>
   /// Quoi faire quand on clique sur le bouton rouge
   /// </summary>
   [SerializeField] private UnityEvent laserButtonEvent;
   private void OnMouseDown()
   {
      laserButtonEvent.Invoke();
   }
}
