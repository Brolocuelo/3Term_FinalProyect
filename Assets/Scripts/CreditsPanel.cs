using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsPanel : MonoBehaviour
{
    public GameObject CreditsButton;

    public void OpenCreditsPanel()
    {
        CreditsButton.SetActive(true);
    }

    public void CloseCreditsPanel()
    {
        CreditsButton.SetActive(false);
    }
}
