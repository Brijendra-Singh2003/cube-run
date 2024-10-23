using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    public float stiffness;

    private void FixedUpdate() {
        transform.position += stiffness * Time.deltaTime * (target.position + offset - transform.position);
    }
}
