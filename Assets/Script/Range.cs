using UnityEngine;

public class RadiusViewer : MonoBehaviour
{
    public float radius = 20f;

    void OnDrawGizmosSelected() // ????????????????? object
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}