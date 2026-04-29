using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageFlash : MonoBehaviour
{
    public Image overlay;

    [Header("Flash")]
    public float flashAlpha = 0.5f;
    public float fadeSpeed = 2f;

    [Header("Low HP Effect")]
    public float maxLowHPAlpha = 0.6f; // ?????????????????? 0

    private Coroutine currentFlash;
    private float baseAlpha; // ?? ????????????????

    void Update()
    {
        // ??? “???????” ????????
        Color c = overlay.color;
        c.a = baseAlpha;
        overlay.color = c;
    }

    public void SetHealthPercent(float percent)
    {
        // percent = 1 (?????????) ? alpha = 0
        // percent = 0 (????????) ? alpha = maxLowHPAlpha
        baseAlpha = (1f - percent) * maxLowHPAlpha;
    }

    public void Flash()
    {
        if (currentFlash != null)
            StopCoroutine(currentFlash);

        currentFlash = StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        Color c = overlay.color;

        // ?????? (??????????? baseAlpha)
        c.a = Mathf.Clamp(baseAlpha + flashAlpha, 0f, 1f);
        overlay.color = c;

        // ???? ? ?????? baseAlpha
        while (overlay.color.a > baseAlpha)
        {
            c.a -= Time.deltaTime * fadeSpeed;
            overlay.color = c;
            yield return null;
        }

        c.a = baseAlpha;
        overlay.color = c;
    }

    public void ResetFlash()
    {
        StopAllCoroutines();

        Color c = overlay.color;
        c.a = 0f; // ? ??????????
        overlay.color = c;

        baseAlpha = 0f; // ??????????
    }
}