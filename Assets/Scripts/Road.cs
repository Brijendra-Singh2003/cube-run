using UnityEngine;

public class Road : MonoBehaviour
{
    public Transform player;
    public Material _material;

    private void FixedUpdate() {
        _material.mainTextureOffset = Vector2.down * player.position.z / 16;
        transform.position = new(0f, 0f, 120f + player.position.z);
    }
}
