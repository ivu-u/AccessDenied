// reference: https://www.youtube.com/watch?v=mgjWA2mxLfI&ab_channel=BMo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Add this script to a bullet prefab. Use the editor to set the behaviors
/// </summary>
public class Bullet : MonoBehaviour
{
    [Header("Destroy Bullet Based On Time")]
    public bool destroyBasedOnTime;
    [SerializeField] private float destroyTime = 3f;
    public GameObject impactEffect;

    void Start() {
        if (destroyBasedOnTime) { Invoke("DestroySelf", destroyTime); }
    }

    private void DestroySelf() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        DestroySelf();
    }
}
