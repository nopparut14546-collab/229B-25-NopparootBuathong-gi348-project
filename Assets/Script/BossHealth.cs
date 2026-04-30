using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health = 10; 
    public GameObject winPanel;

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        Debug.Log("Boss HP: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        Destroy(gameObject);
    }
}