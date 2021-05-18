using System;
using TMPro;
using UnityEngine;

public class DrapeauAppHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Linked Objects")] public TMP_Text txtStoredValue = null;
    private TMP_Dropdown dropdownElement = null;
    private TMP_InputField inputFieldElement = null;
    public TMP_Text answerText = null;
    private int[] flagArray = null;

    private int[] flagArrayAnswers =
        {30, 17, 27, 100};


private void Start()
    {

        dropdownElement = GetComponentInChildren<TMP_Dropdown>();
        inputFieldElement = GetComponentInChildren<TMP_InputField>();
     
        
        flagArray = new int[dropdownElement.options.Count];

    }

  



    public void onChangeDropdown()
    {
        txtStoredValue.text = ""+flagArray[dropdownElement.value];

       

    }

    public void onConfirmPress()
    {
        //send the shit to oblivion

        var index = dropdownElement.value;
        if (inputFieldElement.text.Length == 0)
        {
            inputFieldElement.text = "0";

        }

        flagArray[index] = Convert.ToInt32(inputFieldElement.text);
        txtStoredValue.text = ""+flagArray[index];

        GameObject.Find(dropdownElement.options[index].text).GetComponent<FlagMoverScript>().move(flagArray[index]);
        int i =0;
        for (i = 0; i < flagArray.Length; i++)
        {
            if (flagArray[i] != flagArrayAnswers[i])
            {
print("NOT EQUAL");
                return;
            }
        }

        if (i == flagArray.Length)
        {
             answerText.text = "7306";
        }
   


 



    }
    
    
    
    
    
    
    
}
