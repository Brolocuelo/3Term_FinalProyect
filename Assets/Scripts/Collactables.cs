using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collactables : MonoBehaviour
{
    public GameObject collectable;

    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        playerController.DobleJump();
    }
}
