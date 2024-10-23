using UnityEngine;

public class LookAt : MonoBehaviour {
    public Transform target;
    public float offset = 3.75f;

    private void Update() {
        Vector3 position = new(
            transform.position.x,
            target.position.y,
            target.position.z + offset
        );
        transform.LookAt(position);
    }
}