using UnityEngine;
using System.Collections.Generic;

public class AttackHitbox : MonoBehaviour
{
    public int damage = 1;

    HashSet<Collider> hitTargets = new HashSet<Collider>();

    void OnEnable()
    {
        hitTargets.Clear();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !hitTargets.Contains(other))
        {
            hitTargets.Add(other);

            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                return; 
            }

            BossHealth boss = other.GetComponent<BossHealth>();
            if (boss != null)
            {
                boss.TakeDamage(damage);
            }
        }
    }
}