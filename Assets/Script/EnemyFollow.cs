using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;

    public float speed = 3f;
    public float stopDistance = 1.5f;

    public float visionRange = 8f;   // ?? ???????????

    void Update()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
        direction.y = 0;

        float distance = direction.magnitude;

        // ? ?????????????? ? ?????????
        if (distance > visionRange)
            return;

        // ?? ??????? Player
        if (direction != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, 5f * Time.deltaTime);
        }

        // ?? ?????????? (????????????????)
        if (distance > stopDistance)
        {
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }

    // ?? ???????????? Scene
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
}