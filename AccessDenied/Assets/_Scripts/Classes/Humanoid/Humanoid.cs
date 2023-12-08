using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;


[RequireComponent(typeof(Rigidbody2D))]
public class Humanoid : MonoBehaviour
{
    private Maid maid;

    [Header("Health")]
    public int MaxHealth = 100;

    [SerializeField]
    private int health;
    public int Health
    {
        get { return health; }
        set { if (value <= MaxHealth) 
            { 
                health = MaxHealth;
                OnHealthChanged.Fire(health);
            } 
        }
    }
    public BindableEvent<int> OnHealthChanged = new BindableEvent<int>();


    private Rigidbody2D Rigidbody;
    private Animator Animator;

    [SerializeField]
    public Vector2 DesiredMovement; 


    void Awake()
    {
        health = MaxHealth;
    }


    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        Rigidbody.gravityScale = 0;

        OnHealthChanged.Connect((int health) =>
            {
                Debug.Log(health);
                return true;
            }
        );
    }

    void Update()
    {
        Rigidbody.velocity = DesiredMovement.normalized * 2;
    }
}

