using UnityEngine;

public class Road : MonoBehaviour
{
    public Transform player;
    public float offset;
    public Material _material;

    private void FixedUpdate() {
        _material.mainTextureOffset = Vector2.down * player.position.z / 16;
        transform.position = new(0f, 0f, offset + player.position.z);
    }
}
