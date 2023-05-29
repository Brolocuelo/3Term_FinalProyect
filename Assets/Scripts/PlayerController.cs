using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private Collactables collactables;

    private const string Horizontal = "Horizontal";
    //private float moveDir;
    public float speed = 12f;
    //public float rotateSpeed = 3f;

    private Rigidbody playerRb;
    public float jumpForce = 8f;
    private bool isOnTheGround = true;

    private int jumpCounter;
    public bool dobleJumpUnlocked;

    public int playerIndex;
    private float yRange = 10f;

    private int fireCounter;
    private int hitsCounter;
    public GameObject bulletPrefab;
    public Transform bulletSpawnerTransform;
    private bool canFire;

    public bool gameOver;

    private Animator _animator;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //collactables = FindObjectOfType<Collactables>();
        canFire = true;
        fireCounter = 0;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Movement();

        Jump();

        SpawnPlayer();

        if (Input.GetMouseButtonDown(0) && canFire)
        {
            FireProjectile();
        }

        GameOver();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis(Horizontal);
        _animator.SetTrigger("Walking");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * horizontalInput);

        //transform.LookAt(Vector3.right*horizontalInput);
        //moveDir = Vector3.left(rotateSpeed) *= -1;
        //moveDir = Vector3.right(rotateSpeed) *= 1;
    }

    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) && isOnTheGround)&& !dobleJumpUnlocked) 
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnTheGround = false;
            _animator.SetTrigger("Jumping");
        }
        if (Input.GetKeyDown(KeyCode.Space) && (isOnTheGround || jumpCounter < 2) && dobleJumpUnlocked)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnTheGround = false;
            jumpCounter++;
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
            jumpCounter = 0;
        }

        if (otherCollider.gameObject.CompareTag("SpikesPlatform"))
        {
            _animator.SetBool("Death1", true);
            transform.position = new Vector3(-52, 1, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet") && hitsCounter >= 3)
        {
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(gameObject);
            transform.position = new Vector3(-52, 1, 0);
            SpawnPlayer();
        }
    }

    private void SpawnPlayer()
    {
        Vector3 pos = transform.position;

        if (pos.y < -yRange)
        {
            transform.position = new Vector3(-52, 1, 0);
        }
    }

    private void FireProjectile()
    { 
        Instantiate(bulletPrefab, bulletSpawnerTransform.position, Quaternion.identity);
        fireCounter++;
        if(fireCounter >= 6)
        {
            canFire = false;
            StartCoroutine(AttackCoolDown());
        }
    }

    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(3);
        canFire = true;
        fireCounter = 0;
    }

    private void GameOver()
    {
        Vector3 pos = transform.position;
        _animator.SetBool("Death", true);
    }
}
