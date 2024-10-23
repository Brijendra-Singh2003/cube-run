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
        transform.position += speed * Time.deltaTime * Vector3.forward;

        if(transform.position.y < 0) {
            DestroySelf();
        }
    }

    private void OnTriggerEnter(Collider other) {
        Obsticle obsticle = other.GetComponent<Obsticle>();

        if(obsticle != null) {
            speed = obsticle.speed;
        }
    }

    public void OnHit() {
        Invoke(nameof(DestroySelf), 1f);
    }

    private void DestroySelf() {
        Destroy(this.gameObject);
    }
}
