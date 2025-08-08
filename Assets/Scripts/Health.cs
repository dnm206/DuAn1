using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    //public Image healthBarFill; // Gán Image xanh của thanh máu

    void Start()
    {
        currentHealth = maxHealth;
        //UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        //UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /*void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }
    }*/

    void Die()
    {
        Destroy(gameObject);
    }
}
