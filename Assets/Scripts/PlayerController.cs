using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float thrust;
    public float rotationSpeed;
    public GameEvent playerDied;
    public FloatGameEvent raceStarted;
    public FloatGameEvent raceFinished;
    public ParticleSystem explosion;
    public Rigidbody2D shard;
    public ParticleSystem mainSmoke;
    public float thrustVolume = 0.6f;
    public BoolVariable alive;

    private Rigidbody2D body;
    private bool started;
    private AudioSource audioSource;

    private void Start() {
        this.body = this.GetComponent<Rigidbody2D>();
        this.audioSource = this.GetComponent<AudioSource>();
        body.gravityScale = 0;
        alive.Value = true;
    }

    public void Destroy() {
        alive.Value = false;
        Destroy(this.gameObject);
    }

    void FixedUpdate()
    {
        mainSmoke.transform.position = this.transform.position;
        if (!started && Input.anyKey) {
            started = true;
            body.gravityScale = 1;
            raceStarted.Raise(Time.time);
        }
        if (started) {
            if (Input.GetKey(KeyCode.Space)) {
                body.AddForce(thrust * this.transform.up, ForceMode2D.Impulse);
                mainSmoke.Emit(1);
                this.audioSource.volume = thrustVolume;
            } else {
                this.audioSource.volume = 0;
            }
            if (Input.GetKey(KeyCode.LeftArrow)) {
                body.rotation += rotationSpeed;
            } else if (Input.GetKey(KeyCode.RightArrow)) {
                body.rotation -= rotationSpeed;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (alive.Value) {
            if (collision.tag == "Checkpoint") {
            } else {
                alive.Value = false;
                Debug.Log("player collision with: " + collision.gameObject.name);
                playerDied.Raise();
                ParticleSystem p = Instantiate(explosion, this.transform.position, Quaternion.identity);
                p.GetComponent<Rigidbody2D>().velocity = body.velocity;
                for (int i = 0; i < 5; i++) {
                    Rigidbody2D s = Instantiate(shard, this.transform.position, Quaternion.identity);
                    Vector2 dir = Random.insideUnitCircle;
                    s.transform.localScale *= Random.Range(0.8f, 1.2f);
                    s.velocity = body.velocity + dir;
                    s.position += 1f * dir;
                }
                mainSmoke.transform.parent = this.transform.parent;
                mainSmoke.GetComponent<TimedDestroy>().DestroyAfterSeconds(3);
                Destroy(this.gameObject);
            }
        }
    }
}
