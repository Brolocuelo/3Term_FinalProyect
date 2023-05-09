using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private Transform player;

    private float playerPosition;

    private void OnCollisionEnter(Collider other)
    {
        transform.position = new Vector3(0, 0, 0);
    }

}
