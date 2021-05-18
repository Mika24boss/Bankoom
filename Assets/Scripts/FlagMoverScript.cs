using DG.Tweening;
using UnityEngine;

public class FlagMoverScript : MonoBehaviour
{
    private int percentageDown = 0;

    private float maxHeight = 0;

    

    // Start is called before the first frame update
    private void Start()
    {
        maxHeight = transform.position.y;
       
    }


    public void move(int pourcentage)
    {
        transform.DOKill();
        float hauteurVoulue = 3 * ((float) pourcentage / 100);


        transform.DOMoveY(maxHeight - hauteurVoulue, 5, false);
    }
}