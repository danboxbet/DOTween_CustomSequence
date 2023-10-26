using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace DOTweenElement.UI.Example
{
    public class CustomSingleTween : MonoBehaviour
    {
        [SerializeField] private FillerImage elementDO;

        [SerializeField] private Color selectColor = Color.red;

        [SerializeField] private float durationColorChange = 1;

        Tween testTween;

        private Image image;
        private Color startColor;

        private void Start()
        {
            image = GetComponent<Image>();
            startColor = image.color;

            //subscribe on event of customers or standart elements
            elementDO.OnCompleteForward.AddListener(ForwardChange);
            elementDO.OnCompleteBack.AddListener(BackChange);
        }
        private void OnDestroy()
        {
            elementDO.OnCompleteForward.RemoveListener(ForwardChange);
            elementDO.OnCompleteBack.RemoveListener(BackChange);
        }

        private void ForwardChange()
        {
            testTween.Kill();
            testTween=image.DOColor(selectColor, durationColorChange);
        }
        private void BackChange()
        {
            testTween.Kill();
            testTween=image.DOColor(startColor, durationColorChange);
        }
    }
}