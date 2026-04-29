using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Inventory")]
    public bool hasItem = false;

    [Header("Use Settings")]
    public float useRange = 2f;

    [Header("UI")]
    public GameObject hammerUI; // ?????????

    void Start()
    {
        if (hammerUI != null)
            hammerUI.SetActive(false); // ????????????
    }

    void OnTriggerEnter(Collider other)
    {
        // ?? ??????????
        if (other.CompareTag("Item"))
        {
            hasItem = true;
            Destroy(other.gameObject);

            if (hammerUI != null)
                hammerUI.SetActive(true); // ?? ????????

            Debug.Log("Picked item!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryBreakWall();
        }
    }

    void TryBreakWall()
    {
        if (!hasItem)
        {
            Debug.Log("No item!");
            return;
        }

        Collider[] hits = Physics.OverlapSphere(transform.position, useRange);

        foreach (Collider col in hits)
        {
            if (col.CompareTag("BreakableWall"))
            {
                Destroy(col.gameObject);

                hasItem = false;

                if (hammerUI != null)
                    hammerUI.SetActive(false); // ?? ????????

                Debug.Log("Wall destroyed!");
                return;
            }
        }
    }
}