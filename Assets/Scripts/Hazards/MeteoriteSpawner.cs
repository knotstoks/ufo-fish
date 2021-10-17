using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour {
    [SerializeField] private GameObject meteorite;
    [SerializeField] private Vector2 movingTo;
    [SerializeField] private float respawnTime;
    private float time;
    private void Start() {
        time = respawnTime;
    }

    private void Update() {
        if (time > 0) {
            time -= Time.deltaTime;
        } else {
            time = respawnTime;
            GameObject projectile = Instantiate(meteorite, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Meteorite>().movingTo = this.movingTo;
        }
    }
}
