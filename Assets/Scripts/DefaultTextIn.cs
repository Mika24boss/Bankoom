using System;
using TMPro;
using UnityEngine;

public class DefaultTextIn : MonoBehaviour
{
    // Start is called before the first frame update


    private TMP_InputField fieldComponent = null;

    private void Start()

    {
        fieldComponent = GetComponent<TMP_InputField>();
    }

   


    public void checkChangedValue()
    {
        string finalFieldText = "";


        if (fieldComponent.text.Length != 0)
        {
            foreach (char character in fieldComponent.text)
            {
                int yo = character;

                if (yo >= 48 && yo <= 57)
                {
                    if (Convert.ToInt32(finalFieldText + character) <= 100)
                    {
                        finalFieldText += character;
                    }
                }
            }


            if (!fieldComponent.text.Equals(finalFieldText))
            {
                fieldComponent.text = finalFieldText;
            }
        }
        else
        {
            fieldComponent.text = "0";


        }
    }
}