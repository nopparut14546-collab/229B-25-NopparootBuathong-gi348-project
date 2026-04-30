using UnityEngine;

public class BossDamage : MonoBehaviour
{
    public int damage = 50;
    public float pushForce = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ?? ?????
            PlayerHealth hp = collision.gameObject.GetComponent<PlayerHealth>();
            if (hp != null) hp.TakeDamage(damage);

            // ?? ???????????????
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                Vector3 pushDir = collision.transform.position - transform.position;
                pushDir.y = 0; // ? ?????? Y (?????????)
                pushDir = pushDir.normalized;

                playerRb.AddForce(pushDir * pushForce, ForceMode.Impulse);
            }
        }
    }
}