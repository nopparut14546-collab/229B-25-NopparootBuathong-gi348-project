using UnityEngine;

public class UI_Lives : MonoBehaviour
{
    public GameObject[] hearts; 

    public void UpdateLives(int lives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < lives);
        }
    }
}