// reference: https://www.youtube.com/watch?v=mgjWA2mxLfI&ab_channel=BMo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attatch this to your player char to shoot. Must have a ridgidbody on that player.
/// </summary>
public class PlayerShoot : MonoBehaviour
{
    // accessed denied variables
    [SerializeField] private Tutorial_GrapplingGun grapplingGun;

    public Camera sceneCamera;
    private Rigidbody2D rb;
    private Vector2 _mousePosition;

    public Weapon weapon;
    public float reloadTime = 0.5f;

    private bool canFire = true;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetMouseButtonDown(1) && canFire && !grapplingGun.grappleRope.isGrappling)
        {
            weapon.Fire();
            canFire = false;
            Invoke("Reload", reloadTime);
        }
    }

    void FixedUpdate()
    {
        // rotate the player to follow mouse position
        Vector2 aimDirection = _mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    private void Reload() {
        canFire = true;
    }
}
