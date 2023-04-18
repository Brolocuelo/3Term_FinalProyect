using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal ="Horizontal";
    public float speed = 15f;

    private Rigidbody playerRb;
    public float jumpForce;

    private bool isOnTheGround = true;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis(Horizontal);
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space)&& isOnTheGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnTheGround = false;
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        isOnTheGround = true;
        if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }
    }
}
