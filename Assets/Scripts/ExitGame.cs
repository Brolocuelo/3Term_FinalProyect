using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{


    void Start()
    {
        ExitGameFunction();
    }

    private void ExitGameFunction()
    {
        Application.Quit();
    }
}
