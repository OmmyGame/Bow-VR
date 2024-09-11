using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BloodScreenEffect : MonoBehaviour
{
    public Image bloodScreenImage; // Assign the red image in the inspector
    public float fadeDuration = 0.5f; // Duration of fade effect
    public float visibleDuration = 0.5f; // How long the blood stays on screen

    private Coroutine bloodCoroutine;

    void Start()
    {
        // Initially make sure the image is fully transparent
        bloodScreenImage.color = new Color(bloodScreenImage.color.r, bloodScreenImage.color.g, bloodScreenImage.color.b, 0);
    }

    public void ShowBloodScreen()
    {
        if (bloodCoroutine != null)
        {
            StopCoroutine(bloodCoroutine);
        }

        bloodCoroutine = StartCoroutine(BloodEffectRoutine());
    }

    private IEnumerator BloodEffectRoutine()
    {
        // Fade in the blood screen effect
        yield return StartCoroutine(FadeBloodScreen(1));

        // Keep the effect visible for a moment
        yield return new WaitForSeconds(visibleDuration);

        // Fade out the blood screen effect
        yield return StartCoroutine(FadeBloodScreen(0));
    }

    private IEnumerator FadeBloodScreen(float targetAlpha)
    {
        float startAlpha = bloodScreenImage.color.a;
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            bloodScreenImage.color = new Color(bloodScreenImage.color.r, bloodScreenImage.color.g, bloodScreenImage.color.b, newAlpha);
            yield return null;
        }

        // Ensure the final alpha is exactly as intended
        bloodScreenImage.color = new Color(bloodScreenImage.color.r, bloodScreenImage.color.g, bloodScreenImage.color.b, targetAlpha);
    }
}
