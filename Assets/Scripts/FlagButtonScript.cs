using UnityEngine;

public class FlagButtonScript : MonoBehaviour
{

    private bool isActive = false;

    [Header("Header!")] 
    public int value = 0;




// Start is called before the first frame update
private void Start()
    {
        setColorRed();
    }

   


    private void OnMouseDown()
    {





      
            
         
          transform.parent.gameObject.SendMessage("setStackValue", value, SendMessageOptions.DontRequireReceiver);
     
        
         
         transform.parent.gameObject.SendMessage("setActiveButton", gameObject.name, SendMessageOptions.DontRequireReceiver);
        
        

        }


    public void setColorRed()
    {
       GetComponent <MeshRenderer>().material.SetColor("_EmissionColor",Color.red*50.0f);
    
    }

    public void setColorGreen()
    {
           GetComponent <MeshRenderer>().material.SetColor("_EmissionColor",Color.green*50.0f);
           
           
           
    }
}
