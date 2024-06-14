using UnityEngine;

public class Obsticle : MonoBehaviour
{
    private float speed;

    private void Awake() {
        speed = Random.value * 5 + 5;
    }
    private void FixedUpdate() {
        transform.position += Vector3.forward * speed * Time.deltaTime;

        if(transform.position.y < 0) {
            Destroy(this.gameObject);
        }
    }
}
