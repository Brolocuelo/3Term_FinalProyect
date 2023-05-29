using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagerScene : MonoBehaviour
{
    public TMP_InputField InputField;

    private string existingUsername;

    private const string USERNAME = "USERNAME";

    private void Start()
    {
        existingUsername = PlayerPrefs.GetString(USERNAME);
        if (existingUsername != "")
        {
            InputField.placeholder.GetComponent<TextMeshProUGUI>().text = existingUsername;
        }
    }

    public void Saveusername()
    {
        string inputText = InputField.text;

        if (inputText == "")
        {
            DataPersistence.sharedInstance.username =
                InputField.placeholder.GetComponent<TextMeshProUGUI>().text;
        }
        else
        {
            DataPersistence.sharedInstance.username = inputText;
        }
    }
    public void SaveUserNameWithPlayerPrefs()
    {
        PlayerPrefs.SetString("USERNAME", DataPersistence.sharedInstance.username);
    }
}
