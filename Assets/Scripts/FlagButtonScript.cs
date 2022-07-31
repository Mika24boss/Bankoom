using System;
using UnityEngine;

public class FlagButtonScript : MonoBehaviour
{
    private bool isActive = false;

    [Header("Header!")] public int value = 0;

    private RaycastHit r = new RaycastHit();
    private Ray ray;
    private Collider objectCollider;


// Start is called before the first frame update
    private void Start()
    {
        setColorRed();

        objectCollider = GetComponent<Collider>();


        var x = Screen.width / 2;
        var y = Screen.height / 2;

    
    }

    private void Update()

    {
        ray = GameData.mainCamera.ViewportPointToRay(GameData.cameraRayVector);

        if (objectCollider.Raycast(ray, out r, 5) && Input.GetMouseButtonDown(0))
        {
            transform.parent.gameObject.SendMessage("setStackValue", value, SendMessageOptions.DontRequireReceiver);


            transform.parent.gameObject.SendMessage("setActiveButton", gameObject.name,
                SendMessageOptions.DontRequireReceiver);
        }
    }


    private void OnMouseDown()
    {
    }


    public void setColorRed()
    {
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.red * 50.0f);
    }

    public void setColorGreen()
    {
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.green * 50.0f);
    }
}