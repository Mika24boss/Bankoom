using TMPro;
using UnityEngine;

public class BotTextLinkToGameDataWowThisIsALongTitle : MonoBehaviour
{
    private void Awake()
    {
        GameData.bottomText = GetComponent<TMP_Text>();
    }
}
