using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public UI_Lives uiLives;

    public DamageFlash damageFlash;

    [Header("Health")]
    public int maxHealth = 100;
    private int currentHealth;

    [Header("Lives")]
    public int maxLives = 3;
    private int currentLives;

    private bool isDead;

    void Start()
    {
        currentHealth = maxHealth;
        currentLives = maxLives;

        if (uiLives != null)
            uiLives.UpdateLives(currentLives);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        float percent = (float)currentHealth / maxHealth;

        if (damageFlash != null)
        {
            damageFlash.SetHealthPercent(percent);
            damageFlash.Flash();
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        if (damageFlash != null)
        {
            damageFlash.ResetFlash();
        }


        currentLives--;

        if (uiLives != null)
        {
            uiLives.UpdateLives(currentLives);
        }
        if (currentLives > 0)
        {
            Respawn();
        }
        else
        {
            GameManager.instance.ShowLoseUI();
        }
    }

    void Respawn()
    {
        currentHealth = maxHealth;

        transform.position = GameManager.instance.GetSpawnPoint();

        isDead = false;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
        }
    }
}