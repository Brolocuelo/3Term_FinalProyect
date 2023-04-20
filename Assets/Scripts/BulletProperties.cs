using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperties : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public float distanceLimit = 5f;

    void Update()
    {
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
        if(transform.position.x < distanceLimit)
        {
            Destroy(gameObject);
        }
    }
}
