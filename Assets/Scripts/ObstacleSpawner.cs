using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform player;
    public float spawnDistance;
    private float prevZ;
    // private readonly GameObject[] objects = new GameObject[7];

    private void OnEnable() {
        // InvokeRepeating(nameof(Spawn), spawnDelay, spawnDelay);
        prevZ = player.position.z;
    }
    
    private void OnDisable() {
        CancelInvoke(nameof(Spawn));
    }

    private void Update() {
        if(prevZ + spawnDistance < player.position.z) {
            prevZ = player.position.z;
            Spawn();
        }
    }

    private void Spawn() {

        Instantiate(obstaclePrefab, new(-1.875f, 1.5f, transform.position.z + prevZ), Quaternion.identity);
        Instantiate(obstaclePrefab, new( 1.875f, 1.5f, transform.position.z + prevZ), Quaternion.identity);
        Instantiate(obstaclePrefab, new(-5.625f, 1.5f, transform.position.z + prevZ), Quaternion.identity);
        Instantiate(obstaclePrefab, new( 5.625f, 1.5f, transform.position.z + prevZ), Quaternion.identity);
        Instantiate(obstaclePrefab, new(-3.75f, 1.5f, transform.position.z + prevZ), Quaternion.identity);
        Instantiate(obstaclePrefab, new( 3.75f, 1.5f, transform.position.z + prevZ), Quaternion.identity);
        Instantiate(obstaclePrefab, new( 0f, 1.5f, transform.position.z + prevZ), Quaternion.identity);

        // int a = Random.Range(0, 7);
        // Destroy(objects[a].gameObject);
    }
}
