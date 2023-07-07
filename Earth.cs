using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public int health = 5;
    public int currentHealth;
    public HealthBar healthbar;
    public GameObject GameOverScreen;
    public Animator animator;
    public Scored scored;
    public Scored2 scored2;
    public Scored3 scored3; 
    public HealthText healthtxt;


    private void Start()
    {
        healthtxt.Health = currentHealth;
        healthtxt.MaxHealth = health;
        currentHealth = health;
        healthtxt.UpdateHealthText(currentHealth, health);
        healthbar.SetMaxHealth(health);
        healthbar.SetSlider(health);
        animator =GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        animator.SetBool("Damage", true);
        if (currentHealth <= 0)
        {
            animator.SetTrigger("Death");
        }
        healthtxt.AddHealth(currentHealth, health);
        healthtxt.UpdateHealthText(currentHealth, health);
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverScreen.SetActive(true);
        Die();
    }
    public void TakingDamage()
    {
        animator.SetBool("Damage",false);
    }
    public void Heal()
    {
        if (scored.score >= 10)
        {
            if (currentHealth < health)
            {
                currentHealth += 1;
                healthbar.SetSlider(currentHealth);
                scored.MinusScore(10);
                healthtxt.AddHealth(currentHealth, health);
                healthtxt.UpdateHealthText(currentHealth, health);
            }
        }
    }
    public void AddMaxHealth()
    {
        if (scored.score >= 20 && scored2.score >=15)
        {
            health += 1;
            currentHealth += 1;
            healthbar.SetMaxHealth(health);
            healthbar.SetSlider(currentHealth);
            healthtxt.AddHealth(currentHealth, health);
            healthtxt.UpdateHealthText(currentHealth, health);
            scored.MinusScore(20);
            scored2.MinusScore(15);
        }
    }
    public void UpdateHealthTextScript()
    {
        healthtxt.Health = currentHealth;
        healthtxt.MaxHealth = health;
    }
}
