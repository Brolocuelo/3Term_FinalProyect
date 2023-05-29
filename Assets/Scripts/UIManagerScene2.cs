using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagerScene2 : MonoBehaviour
{
    public TextMeshProUGUI helloText;

    private void Start()
    {
        helloText.text = $"Hello, {DataPersistence.sharedInstance.username}";
    }
}
