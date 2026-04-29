using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float height = 2f;
    public float speed = 2f;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, height);
        transform.position = startPos + new Vector3(0, y, 0);
    }
}