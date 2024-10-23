using UnityEngine;

public class RotateWheels : MonoBehaviour
{
    public Transform[] wheels;
    public float factor = 1f;
    [SerializeField] private Transform vehicle;
    private float prevPosi;

    private void Update() {
        Vector3 angle = (vehicle.position.z - prevPosi) * factor * Vector3.right;
        foreach (Transform wheel in wheels) {
            wheel.Rotate(angle);
        }
        prevPosi = vehicle.position.z;
    }
}
