using UnityEngine;

public class Lava : MonoBehaviour
{
    private float nextDamageTime;
    public float damageInterval = 0.5f; // ?????? 0.5 ??????
    public int damageAmount = 10;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && Time.time >= nextDamageTime)
        {
            PlayerHealth hp = collision.gameObject.GetComponent<PlayerHealth>();
            if (hp != null)
            {
                hp.TakeDamage(damageAmount);
                nextDamageTime = Time.time + damageInterval; // ???????????????????????????????????
            }
        }
    }
}
