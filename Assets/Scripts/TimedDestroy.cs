using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    public void DestroyAfterSeconds(float t) {
        StartCoroutine(DestructSequence(t));
    }

    private IEnumerator DestructSequence(float t) {
        yield return new WaitForSeconds(t);
        Destroy(this.gameObject);
    }
}
