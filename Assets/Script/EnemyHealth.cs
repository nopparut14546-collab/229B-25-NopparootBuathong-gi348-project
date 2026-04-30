using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        Debug.Log("Enemy HP: " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}