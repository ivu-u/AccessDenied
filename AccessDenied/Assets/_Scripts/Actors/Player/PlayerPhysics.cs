using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rn this just adds gravity acceleration when falling
/// </summary>
public class PlayerPhysics : MonoBehaviour {
    
    private Rigidbody2D rb;
    [SerializeField] private float gravityScale = 15;
    [SerializeField] private float maxFallAcceleration = 1.4f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (rb.velocity.y < 0) {
            float downwardForce = gravityScale * Time.deltaTime;

            if (downwardForce > gravityScale * maxFallAcceleration) {
                rb.velocity += new Vector2(0, -downwardForce * maxFallAcceleration);
            }
        }
    }
}
