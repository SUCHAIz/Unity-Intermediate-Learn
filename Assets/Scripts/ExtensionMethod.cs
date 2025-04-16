using UnityEngine;
using DG.Tweening;
public static class ExtensionMethod
{
    public static void Fade(this CanvasGroup canvasGroup, bool isShow,float fadeDuration)
    {
        float targetAlpha = isShow ? 1f : 0f;

        if(Mathf.Approximately(canvasGroup.alpha, targetAlpha))
        {
            canvasGroup.SetCanvasGroupInteraction(isShow);
            return;
        }

        canvasGroup.DOFade(targetAlpha, fadeDuration).OnComplete(() =>
        {
            canvasGroup.SetCanvasGroupInteraction(isShow);
        });

    }

    public static void Hide(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.SetCanvasGroupInteraction(false);
    }

    public static void SetCanvasGroupInteraction(this CanvasGroup canvasGroup,bool isEnable)
    {
        canvasGroup.blocksRaycasts = isEnable;
        canvasGroup.interactable = isEnable;
    }


}
