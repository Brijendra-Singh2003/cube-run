using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    public float stiffness;

    private void FixedUpdate() {
        transform.position += (target.position + offset - transform.position) * stiffness * Time.deltaTime;
    }
}
