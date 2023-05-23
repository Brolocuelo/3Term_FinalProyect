using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletProperties : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public float distanceLimit = 4f;

    private void Start()
    {
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
    }
}
