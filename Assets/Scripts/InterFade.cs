using System.Collections;
using UnityEngine;

public class InterFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _fadeSpeed = 1f;
    private bool _isShown;

    IEnumerator Fade()
    {
        float alpha = _isShown ? 0f : 1f;
        if(_isShown) // == true
        {
            while(_canvasGroup.alpha < 1f)
            {
                _canvasGroup.alpha += Time.deltaTime * _fadeSpeed;
                yield return null;
            }
        }
         else
        {
            while(_canvasGroup.alpha > 0f)
            {
                _canvasGroup.alpha -= Time.deltaTime * _fadeSpeed;
                yield return null;
            }
        }

        yield return new WaitForSeconds(0.5f);
        Debug.Log("FADED!");
    }

    [ContextMenu("Toggle UI")]
    public void ToggleUI()
    {
        _isShown = !_isShown;
        StartCoroutine(Fade());
    }
}
