using UnityEngine;

public class Obsticle : MonoBehaviour
{
    private void FixedUpdate() {
        if(transform.position.y < 0) {
            Destroy(this.gameObject);
        }
    }
}
