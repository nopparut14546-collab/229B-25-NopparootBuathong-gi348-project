using UnityEngine;
public class GrassSpawner : MonoBehaviour
{
    public GameObject grassPrefab;
    public int count = 500;
    public float areaSize = 20f;

    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-areaSize, areaSize),
                0,
                Random.Range(-areaSize, areaSize)
            );

            Instantiate(grassPrefab, pos, Quaternion.identity, transform);
        }
    }
}