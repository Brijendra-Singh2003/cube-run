using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform player;
    public float spawnDelay;
    private readonly GameObject[] objects = new GameObject[7];

    private void OnEnable() {
        InvokeRepeating(nameof(Spawn), spawnDelay, spawnDelay);
    }
    
    private void OnDisable() {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn() {

        objects[0] = Instantiate(obstaclePrefab, new(-1.875f, 1.5f, transform.position.z + player.position.z), Quaternion.identity);
        objects[1] = Instantiate(obstaclePrefab, new( 1.875f, 1.5f, transform.position.z + player.position.z), Quaternion.identity);
        objects[2] = Instantiate(obstaclePrefab, new(-5.625f, 1.5f, transform.position.z + player.position.z), Quaternion.identity);
        objects[3] = Instantiate(obstaclePrefab, new( 5.625f, 1.5f, transform.position.z + player.position.z), Quaternion.identity);
        objects[4] = Instantiate(obstaclePrefab, new(-3.75f, 1.5f, transform.position.z + player.position.z), Quaternion.identity);
        objects[5] = Instantiate(obstaclePrefab, new( 3.75f, 1.5f, transform.position.z + player.position.z), Quaternion.identity);
        objects[6] = Instantiate(obstaclePrefab, new( 0f, 1.5f, transform.position.z + player.position.z), Quaternion.identity);

        int a = Random.Range(0, 7);
        Destroy(objects[a].gameObject);
    }
}
