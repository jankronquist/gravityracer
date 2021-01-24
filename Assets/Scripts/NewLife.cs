using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLife : MonoBehaviour
{
    public GameObject player;
    public Follow follow;

    void Start() {
        StartCoroutine(SpawnPlayer());
    }

    public void OnPlayerDied() {
        StartCoroutine(Restart());
    }

    private IEnumerator Restart() {
        follow.target = null;
        yield return new WaitForSeconds(2f);
        yield return SpawnPlayer();
    }

    private IEnumerator SpawnPlayer() {
        follow.lastPosition = new Vector2(0, 0);
        while (Vector2.Distance(follow.transform.position, follow.lastPosition) > 0.8f) {
            yield return new WaitForSeconds(0.1f);
        }
        GameObject g = Instantiate(player);
        follow.target = g.GetComponent<Rigidbody2D>();
    }
}
