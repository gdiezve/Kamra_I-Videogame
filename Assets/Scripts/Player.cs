using System;
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
    public Animator animator;

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
        isOnFloor = Physics2D.OverlapCircle(foot.position, footRadius, floor);

        if (!isOnFloor) {
            isOnEnemy = Physics2D.OverlapCircle(foot.position, footRadius, enemy);
        }

        if (currentHealth == 0) {
            Application.Quit();
        }
    }

    void TakeDamage(int damage) {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Enemy" && isOnEnemy == false)
        {
            TakeDamage(10);
        }
    }
}
