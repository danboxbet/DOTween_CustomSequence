using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DOTweenElement.UI
{
    public class FillerImage : ElementDOTween
    {
        [Header("Set duration")]
        [SerializeField] private float durationChangeFillAmount;

        [Header("Image to fill")]
        [SerializeField] private Image fillableImage;

        [Header("Color fill")]
        [SerializeField] private Color color;

        private Tween fillTween;

        #region UNITY_EVENTS
        protected override void Start()
        {
            base.Start();
            if (Application.isPlaying) fillableImage.color = color;
        }

        private void Reset()
        {
            settings = GetComponent<SettingsElementDOTween>();

            settings.isFillable = true;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            fillTween.Kill();
        }
        #endregion

        #region OVERRIDDEN_METHODS
        protected override void WasDestroyComponent()
        {
            if (GetComponents<FillerImage>().Length > 1) return;

            settings.isFillable = false;
        }
        public override Tween CreateBackTween()
        {
            FillImage(0);
            return fillTween;
        }
        public override Tween CreateForwardTween()
        {
            BringBackFillValue();
            FillImage(1);
            return fillTween;
        }
        #endregion

        #region PRIVATE_METHODS
        private void FillImage(float endStroke)
        {
            if(endStroke==0)
            fillTween = DOTween.To(() => fillableImage.fillAmount, x => fillableImage.fillAmount = x, endStroke, durationChangeFillAmount).SetEase(Ease.Linear).OnComplete(OnCompleteBack.Invoke);

            if(endStroke==1)
            fillTween = DOTween.To(() => fillableImage.fillAmount, x => fillableImage.fillAmount = x, endStroke, durationChangeFillAmount).SetEase(Ease.Linear).OnComplete(OnCompleteForward.Invoke);
        }

        private void BringBackFillValue()
        {
            fillTween = DOTween.To(() => fillableImage.fillAmount, x => fillableImage.fillAmount = x, 0, durationChangeFillAmount * (fillableImage.fillAmount / 1)).SetEase(Ease.Linear);
        }
        #endregion

        #region UNITY_EDITOR

#if UNITY_EDITOR
        private void OnValidate()
        {
            if(fillableImage!=null && gameObject.activeSelf)
            fillableImage.color = color;
        }
#endif

        #endregion
    }
}