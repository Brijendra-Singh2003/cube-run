using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform player;
    public float spawnDistance;
    private float spawnLocation;
    private float prevZ;
    private readonly GameObject[] objects = new GameObject[5];

    private void OnEnable() {
        // InvokeRepeating(nameof(Spawn), spawnDelay, spawnDelay);
        prevZ = player.position.z;
    }
    
    private void OnDisable() {
        CancelInvoke(nameof(Spawn));
    }

    private void FixedUpdate() {
        spawnLocation = transform.position.z + player.transform.position.z;

        for(int i=0; i<5; i++) {
            if(objects[i] != null && !objects[i].IsDestroyed()){
                float p = objects[i].transform.position.z;
                if(p > prevZ) prevZ = p;
            }
        }

        if(prevZ + spawnDistance < spawnLocation) {
            prevZ = player.position.z;
            Spawn();
        }
    }

    private void Spawn() {

        objects[0] = Instantiate(obstaclePrefab, new(-2f, 1.5f, spawnLocation), Quaternion.identity);
        objects[1] = Instantiate(obstaclePrefab, new( 2f, 1.5f, spawnLocation), Quaternion.identity);
        objects[2] = Instantiate(obstaclePrefab, new(-4f, 1.5f, spawnLocation), Quaternion.identity);
        objects[3] = Instantiate(obstaclePrefab, new( 4f, 1.5f, spawnLocation), Quaternion.identity);
        objects[4] = Instantiate(obstaclePrefab, new( 0f, 1.5f, spawnLocation), Quaternion.identity);
    }
}
