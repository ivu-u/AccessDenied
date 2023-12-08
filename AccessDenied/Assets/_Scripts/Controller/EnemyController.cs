using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRange = 5f;

    private static EnemyController instance;

    private GameObject player;
    private Humanoid playerHumanoid;

    private List<Humanoid> enemies = new List<Humanoid>();

    public static EnemyController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EnemyController>();

                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(EnemyController).Name;
                    instance = obj.AddComponent<EnemyController>();
                }
            }

            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        player = GameObject.FindGameObjectWithTag("Player");
    
        if (player != null)
        {
            playerHumanoid = player.GetComponent<Humanoid>();
        }
        else
        {
            Debug.LogError("Player not found in the scene!");
        }

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Enemy")) {
            enemies.Add(g.GetComponent<Humanoid>());
        }
    }

    void Update()
    {
        if (player != null)
        {
            foreach (Humanoid enemy in enemies)
            {
                // Check if the player is within detection range of each enemy
                if (Vector2.Distance(enemy.transform.position, player.transform.position) < detectionRange)
                {
                    // Calculate movement direction towards the player
                    Vector2 direction = (player.transform.position - enemy.transform.position).normalized;


                    enemy.DesiredMovement = direction;
                }
                else
                {
                    // Player is outside detection range, stop moving
                    playerHumanoid.DesiredMovement = Vector2.zero;
                }
            }
        }
    }

    void RotateTowardsPlayer(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
}
