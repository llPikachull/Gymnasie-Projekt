using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Player_2 : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Punch();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }

    void Punch()
    {
        animator.SetTrigger("Punch");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);


        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Player_Combat>().TakeDamage(attackDamage);
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Player2 died!");
    }
}
