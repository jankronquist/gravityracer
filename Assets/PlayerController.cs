using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float thrust;
    public float rotationSpeed;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space)) {
            this.GetComponent<Rigidbody2D>().AddForce(thrust * this.transform.up, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            this.GetComponent<Rigidbody2D>().rotation += rotationSpeed;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            this.GetComponent<Rigidbody2D>().rotation -= rotationSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
