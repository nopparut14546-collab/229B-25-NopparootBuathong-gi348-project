using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject hitbox;

    public float activeTime = 0.2f;
    public float cooldown = 0.5f;

    bool canAttack = true;

    void Start()
    {
        hitbox.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        canAttack = false;

        // ???????????
        Vector3 camForward = cameraTransform.forward;
        Vector3 dir = new Vector3(camForward.x, 0, camForward.z);
        transform.forward = dir;

        // ???? hitbox
        hitbox.SetActive(true);

        yield return new WaitForSeconds(activeTime);

        hitbox.SetActive(false);

        yield return new WaitForSeconds(cooldown);

        canAttack = true;
    }
}