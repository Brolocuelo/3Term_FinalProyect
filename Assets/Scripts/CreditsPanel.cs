using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsPanel : MonoBehaviour
{
    public GameObject credits;

    public void OpenCreditsPanel()
    {
        credits.SetActive(true);
    }

    public void CloseCreditsPanel()
    {
        credits.SetActive(false);
    }
}
