using UnityEngine;

public class ButtonStackHandler : MonoBehaviour
{
   

    private int stackValue = 0;
    private FlagButtonScript currentActiveButton = null;
    private FlagPuzzleHandler parent = null;
    
    
    
 // Start is called before the first frame update
    private void Start()
    {
        parent = transform.parent.GetComponent<FlagPuzzleHandler>();
    }

   

/**
 * Valeur de la colonne de bouton.
 */
    public void setStackValue(int value)
    {
      
        parent.priceSubstract(stackValue);
        stackValue = value;
        parent.priceAdd(stackValue);
    }

/*
 * Change le bouton actif, et change leur couleur
 */
    public void setActiveButton(string newActiveButtonStr)


    {
        FlagButtonScript newActiveButton = searchInStack(newActiveButtonStr).GetComponent<FlagButtonScript>();
        if (currentActiveButton != null)
        {
            currentActiveButton.setColorRed();
        }

        newActiveButton.setColorGreen();

        currentActiveButton = newActiveButton;
    }
/**
 * script pour rechercher le bouton dans les childs de la colonne.
 */
    public GameObject searchInStack(string name)
    {
        for (int i = 0; i < transform.childCount; i++)

        {
            Transform transChild = transform.GetChild(i);


            if (transChild.name.Equals(name))
            {
                return transChild.gameObject;
            }
        }


        return null;
    }
}