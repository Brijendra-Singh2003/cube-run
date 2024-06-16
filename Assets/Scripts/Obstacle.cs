using UnityEngine;

public class Obsticle : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    public float speed;

    private void Awake() {
        speed = Random.value * (maxSpeed - minSpeed) + minSpeed;
    }
    private void FixedUpdate() {
        transform.position += Vector3.forward * speed * Time.deltaTime;

        if(transform.position.y < 0) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        Obsticle obsticle = other.GetComponent<Obsticle>();

        if(obsticle != null) {
            speed = obsticle.speed;
        }
    }
}
