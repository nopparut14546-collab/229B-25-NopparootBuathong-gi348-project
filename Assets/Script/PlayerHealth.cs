using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
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
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        Debug.Log("Player Current Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
            Debug.Log("Player Died! Remaining Lives: " + currentLives);
        }
    }

    void Die()
    {
        isDead = true;
        currentLives--;

        if (currentLives > 0)
        {
            // ?? ?????????? ? Respawn
            Respawn();
        }
        else
        {
            // ? ???????? ? ???
            GameManager.instance.ShowLoseUI();
        }
    }

    void Respawn()
    {
        // ???????
        currentHealth = maxHealth;

        // ?????? checkpoint
        transform.position = GameManager.instance.GetSpawnPoint();

        // ???????
        isDead = false;

        // reset velocity
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
        }
    }
}