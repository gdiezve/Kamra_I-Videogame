using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public int maxHealth = 100;
    public int currentHealth;
    public Transform foot;
    public float footRadius;
    public LayerMask floor;
    public LayerMask enemy;
    public bool isOnFloor;
    public bool isOnEnemy; 

    public HealthBar healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(20);
        }

        isOnFloor = Physics2D.OverlapCircle(foot.position, footRadius, floor);
        isOnEnemy = Physics2D.OverlapCircle(foot.position, footRadius, enemy);
    }

    void TakeDamage(int damage) {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
