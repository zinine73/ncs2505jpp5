using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Rigidbody targetRb;
    float minSpeed = 12f;
    float maxSpeed = 16f;
    float maxTorque = 10f;
    float xRange = 4f;
    float ySpawnPos = -6f;

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(),
            ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(),
            RandomTorque(), RandomTorque(),
            ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    Vector3 RandomForce()
    {
        return Vector3.up *
            Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(
            Random.Range(-xRange, xRange), ySpawnPos);
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
