using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    public GameObject SettingsButton;

    public void OpenSettingsPanel()
    {
        SettingsButton.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        SettingsButton.SetActive(false);
    }
}
