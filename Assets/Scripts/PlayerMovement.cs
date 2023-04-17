using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal ="Horizontal";

    public float speed = 15f;

    private void Update()
    {
        float horizontalInput = Input.GetAxis(Horizontal);

        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
    }
}
