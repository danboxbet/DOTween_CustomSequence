using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DOTweenElement.UI
{
    public class TwinklerImage : ElementDOTween
    {
        [Header("Set duration")]
        [SerializeField] private float durationChangeTwinkleImage;

        [Header("Image to twinkle")]
        [SerializeField] private Image twinkleImage;

        [Header("Fade Image Property")]
        [SerializeField] [Range(0, 255)] private float minTwinkleValue;
        [SerializeField] [Range(0, 255)] private float maxTwinkleValue;

        private Tween twinkleTween;

        #region UNITY_EVENTS
        protected override void Start()
        {
            base.Start();
            if (Application.isPlaying) twinkleImage.color = new Vector4(twinkleImage.color.r, twinkleImage.color.g, twinkleImage.color.b, minTwinkleValue / 255);
        }

        private void Reset()
        {
            settings = GetComponent<SettingsElementDOTween>();

            settings.isFlickering = true;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            twinkleTween.Kill();
        }
        #endregion

        #region OVERRIDDEN_METHODS
        protected override void WasDestroyComponent()
        {
            if (GetComponents<TwinklerImage>().Length > 1) return;

            settings.isFlickering = false;
        }
        public override Tween CreateBackTween()
        {
            ChangeStateTwinkle(false);
            return twinkleTween;
        }
        public override Tween CreateForwardTween()
        {
            ChangeStateTwinkle(true);
            return twinkleTween;
        }
        #endregion

        #region PRIVATE_METHODS
        private void ChangeStateTwinkle(bool elementIsSelect)
        {
            if (elementIsSelect)
            {
                twinkleTween.Kill();
                StartTwinkleCycle();
            }

            if (!elementIsSelect)
            {
                twinkleTween.Kill();
                twinkleTween = twinkleImage.DOFade(minTwinkleValue / 255, durationChangeTwinkleImage).SetEase(Ease.Linear).OnComplete(OnCompleteBack.Invoke);
            }
        }

        private void StartTwinkleCycle()
        {
            twinkleTween = twinkleImage.DOFade(maxTwinkleValue / 255, durationChangeTwinkleImage).SetEase(Ease.Linear).OnComplete(ReverseTwinkle);
        }
        private void ReverseTwinkle()
        {
            twinkleTween = twinkleImage.DOFade(minTwinkleValue / 255, durationChangeTwinkleImage).SetEase(Ease.Linear).OnComplete(()=>
            {
                OnCompleteForward.Invoke();
                StartTwinkleCycle();
            }
            );
        }
        #endregion

        #region UNITY_EDITOR

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (twinkleImage != null && gameObject.activeSelf)
                twinkleImage.color = new Vector4(twinkleImage.color.r, twinkleImage.color.g, twinkleImage.color.b, minTwinkleValue / 255);
        }
#endif

        #endregion
    }
}
