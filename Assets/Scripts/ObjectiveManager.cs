using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public static List<string> objectiveList = new List<string>()
    {
        "Suivre le tutoriel",
        "Désactiver le système de sécurité",
        "Trouver le code du coffre-fort",
        "S'échapper du coffre-fort"
    };

    [SerializeField] private TMP_Text objectiveText;

    private int previousIndex = 0;

    // Start is called before the first frame update
    private void Start()
    {
        objectiveText.text = "- " + objectiveList[GameData.currentObjectiveIndex];
    }

    private void Update()
    {
        if (previousIndex == 0 && GameData.currentObjectiveIndex == 1)
        {
            previousIndex = 1;
            Debug.Log("Le tutoriel a été complété.");
            objectiveFinished();
        } else if (previousIndex == 2 && GameData.currentObjectiveIndex == 3)
        {
            previousIndex = 3;
            Debug.Log("Le coffre-fort est ouvert.");
            objectiveFinished();
        }
        
        if (!GameData.CameraActiveDictionary.ContainsValue(true) && previousIndex == 1)
        {
            previousIndex = 2;
            GameData.currentObjectiveIndex = 2;
            Debug.Log("Toutes les caméras sont désactivées.");
            objectiveFinished();
        }
        else if (GameData.CameraActiveDictionary.ContainsValue(true) && GameData.currentObjectiveIndex == 2)
        {
            GameData.currentObjectiveIndex = 1;
            previousIndex = 1;
            objectiveFinished();
        }
    }

    private void objectiveFinished()
    {
        if (objectiveList.Count <= GameData.currentObjectiveIndex)
        {
            //player win the game
        }
        else
        {
            objectiveText.text = "- " + objectiveList[GameData.currentObjectiveIndex];
        }
    }
}