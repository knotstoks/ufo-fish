using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneSpawner : MonoBehaviour {
    [SerializeField] private GameObject airplane;
    [SerializeField] private float respawnTime;
    [SerializeField] private bool goingRight;
    private float time;
    private void Start() {
        time = respawnTime;
    }

    private void Update() {
        if (time > 0) {
            time -= Time.deltaTime;
        } else {
            time = respawnTime;
            GameObject projectile = Instantiate(airplane, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Airplane>().goingRight = this.goingRight;
        }
    }
}
