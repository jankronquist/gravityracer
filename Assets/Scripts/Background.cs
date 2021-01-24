using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform follow;
    public Vector2 tileSize;

    void FixedUpdate()
    {
        Vector3 pos = this.transform.position;
        while (follow.position.x - pos.x > tileSize.x) {
            pos.x += tileSize.x;
        }
        while (pos.x - follow.position.x > tileSize.x) {
            pos.x-= tileSize.x;
        }
        while (follow.position.y - pos.y > tileSize.y) {
            pos.y += tileSize.y;
        }
        while (pos.y - follow.position.y > tileSize.y) {
            pos.y -= tileSize.y;
        }
        this.transform.position = pos;
    }
}
