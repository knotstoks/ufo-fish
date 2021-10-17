using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    [SerializeField] private GameObject rocket;
    [SerializeField] private float respawnTime;
    private float time;
    private void Start()
    {
        time = respawnTime;
    }

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = respawnTime;
            Instantiate(rocket, transform.position, Quaternion.identity);
        }
    }
}
