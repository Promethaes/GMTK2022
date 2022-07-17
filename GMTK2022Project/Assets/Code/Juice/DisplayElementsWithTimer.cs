using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DisplayElementsWithTimer : MonoBehaviour
{
    [SerializeField] AnimationCurve colourLerpCurve;
    [SerializeField] Color colour1;
    [SerializeField] Color colour2;
    [SerializeField] UnityEvent OnDisplayElement;
    [SerializeField] float typeSpeed = 1.0f;
    [SerializeField] float colorSpeed = 1.0f;
    [SerializeField] string textToDisplay = "you    d";
    [SerializeField] TMPro.TextMeshProUGUI text;
    [SerializeField] GameObject dieImage;

    private void OnEnable()
    {
        text.text = "";
        text.color = colour1;
        dieImage.SetActive(false);
        IEnumerator Timer()
        {
            int stringLength = 1;
            while (true)
            {
                yield return new WaitForSeconds(1 / typeSpeed);
                if (stringLength == 4)
                {
                    dieImage.SetActive(true);
                    stringLength = 8;
                }
                text.text = textToDisplay.Substring(0, stringLength);
                OnDisplayElement.Invoke();
                if (stringLength == 8)
                    break;
                stringLength++;
            }
            yield return null;
        }
        StartCoroutine(Timer());
        StartCoroutine(Lerp());

    }
    IEnumerator Lerp()
    {
        while (true)
        {
            float x = 0.0f;
            while (x < 1.0f)
            {
                yield return new WaitForEndOfFrame();
                x += Time.deltaTime * 1 / colorSpeed;
                text.color = Color.Lerp(colour1, colour2, colourLerpCurve.Evaluate(x));
            }
            x = 1.0f;
            while (x > 0.0f)
            {
                yield return new WaitForEndOfFrame();
                x -= Time.deltaTime * 1 / colorSpeed;
                text.color = Color.Lerp(colour1, colour2, colourLerpCurve.Evaluate(x));
            }
            x = 0.0f;
        }
    }
}
