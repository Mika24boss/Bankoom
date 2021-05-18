using UnityEngine;

public class FlagPuzzleHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PanelLock;
    private int priceTotal = 0;


    public void priceAdd(int value)
    {
        priceTotal += value;


        print("Prix total : " + priceTotal);


        if (priceTotal == 4300)
        {
            PanelLock.SetActive(false);
        }
        else
        {
            PanelLock.SetActive(true);
        }
    }

    public void priceSubstract(int value)
    {
        priceTotal -= value;
        print("Prix total : " + priceTotal);
    }
}