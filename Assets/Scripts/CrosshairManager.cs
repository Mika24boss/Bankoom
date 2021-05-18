using UnityEngine;
using UnityEngine.UI;

public class CrosshairManager : MonoBehaviour
{

    private Image crosshairImage;

    private void Start()
    {
        crosshairImage = GetComponent<Image>();
    }

    // Update is called once per frame
    private void Update()
    {
        Color color = crosshairImage.color;
        if (color.a.Equals(0) && !GameData.isUsingKeyPad)
        {
            crosshairImage.color = new Color(color.r, color.g, color.b, 1);
        }else if (color.a.Equals(1) && GameData.isUsingKeyPad)
        {
            crosshairImage.color = new Color(color.r, color.g, color.b, 0);
        }
    
    }
}
