using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Humanoid class represents a character with health, movement, and animation capabilities in a Unity environment.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Humanoid : MonoBehaviour
{
    private Maid maid; // Reference to a memory management system (Maid) for automatic cleanup.

    [Header("Health")]
    public int MaxHealth = 100;

    [SerializeField]
    private int health; // Current health of the humanoid.
    public int Health
    {
        get { return health; }
        set
        {
            // Ensure the health value does not exceed the maximum health.
            if (value <= MaxHealth)
            {
                health = MaxHealth;
                // Trigger an event when health changes.
                OnHealthChanged.Fire(health);
            }
        }
    }

    public BindableEvent<int> OnHealthChanged = new BindableEvent<int>(); // Event triggered when health changes.

    private Rigidbody2D Rigidbody; // Reference to the Rigidbody2D component for physics interactions.
    private Animator Animator; // Reference to the Animator component for character animations.

    [SerializeField]
    public Vector2 DesiredMovement; // The desired movement direction of the humanoid.

    void Awake()
    {
        health = MaxHealth; // Initialize health to the maximum value on Awake.
    }

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component.
        Animator = GetComponent<Animator>(); // Get the Animator component.

        Rigidbody.gravityScale = 0; // Disable gravity to control movement manually.

        // Initialize the Maid system for automatic memory management.
        maid = new Maid();

        // Connect a debug log to the OnHealthChanged event for monitoring health changes.
        OnHealthChanged.Connect((int health) =>
        {
            Debug.Log(health);
            return true;
        });
    }

    void Update()
    {
        // Update the Rigidbody velocity based on the desired movement direction.
        Rigidbody.velocity = DesiredMovement.normalized * 2;
    }
}
