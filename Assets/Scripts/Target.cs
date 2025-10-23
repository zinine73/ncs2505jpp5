using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue;
    public ParticleSystem[] explosionParticle;
    GameManager gm;
    Rigidbody targetRb;
    float minSpeed = 12f;
    float maxSpeed = 16f;
    float maxTorque = 10f;
    float xRange = 4f;
    float ySpawnPos = -6f;

    void Start()
    {
        gm = GameObject.Find("GameManager")
            .GetComponent<GameManager>();
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
        if (gm.isGameActive)
        {
            Destroy(gameObject);
            int index = Random.Range(0, explosionParticle.Length);
            Instantiate(explosionParticle[index],
                transform.position,
                explosionParticle[index].transform.rotation);
            gm.UpdateScore(pointValue);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gm.GameOver(true);
        }
    }
}
