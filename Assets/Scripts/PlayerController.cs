using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float thrust;
    public float rotationSpeed;
    public GameEvent playerDied;
    public ParticleSystem explosion;
    public Rigidbody2D shard;

    private Rigidbody2D body;
    private bool started;

    private void Start() {
        this.body = this.GetComponent<Rigidbody2D>();
        body.gravityScale = 0;
    }

    void FixedUpdate()
    {
        if (!started && Input.anyKey) {
            started = true;
            body.gravityScale = 1;
        }
        if (started) {
            if (Input.GetKey(KeyCode.Space)) {
                body.AddForce(thrust * this.transform.up, ForceMode2D.Impulse);
            }
            if (Input.GetKey(KeyCode.LeftArrow)) {
                body.rotation += rotationSpeed;
            } else if (Input.GetKey(KeyCode.RightArrow)) {
                body.rotation -= rotationSpeed;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        playerDied.Raise();
        // TODO: add shards
        ParticleSystem p = Instantiate(explosion, this.transform.position, Quaternion.identity);
        p.GetComponent<Rigidbody2D>().velocity = body.velocity;
        for (int i = 0; i < 5; i++) {
            Rigidbody2D s = Instantiate(shard, this.transform.position, Quaternion.identity);
            Vector2 dir = Random.insideUnitCircle;
            s.transform.localScale *= Random.Range(0.8f, 1.2f);
            s.velocity = body.velocity + dir;
            s.position += 2f * dir;
        }
        Destroy(this.gameObject);
    }
}
