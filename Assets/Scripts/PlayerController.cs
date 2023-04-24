using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Collactables collactables;

    private const string Horizontal = "Horizontal";
    public float speed = 15f;

    private Rigidbody playerRb;
    public float jumpForce;
    private bool isOnTheGround = true;

    public int Counter;
    public bool dobleJumpUnlocked;

    public GameObject bulletPrefab;
    public Transform bulletSpawnerTransform;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        collactables = FindObjectOfType<Collactables>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis(Horizontal);
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);

        Jump();

        if (Input.GetMouseButtonDown(0))
        {
            FireProjectile();
        }
    }

    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) && isOnTheGround)&& !dobleJumpUnlocked) 
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnTheGround = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && (isOnTheGround || Counter < 2) && dobleJumpUnlocked)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnTheGround = false;
            Counter++;
        }
    }

    public void DobleJump()
    {
        dobleJumpUnlocked = true;
    }


    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
            Counter = 0;
        }
    }

    private void FireProjectile()
    { 
        Instantiate(bulletPrefab, bulletSpawnerTransform.position, Quaternion.identity);
    }
}
