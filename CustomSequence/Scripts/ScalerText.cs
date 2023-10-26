using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DOTweenElement.UI
{
    public class ScalerText : ElementDOTween
    {
        [Header("Set duration")]
        [SerializeField] private float durationChangeFontSizeText;

        [Header("Size Text")]
        [SerializeField] private Text text;
        [SerializeField] private float neccessaryFontSize;
        private float startFontSize;

        private Tween fontSizeTween;

        #region UNITY_EVENTS
        protected override void Start()
        {
            base.Start();
            if(Application.isPlaying) startFontSize = text.fontSize;
        }

        private void Reset()
        {
            settings = GetComponent<SettingsElementDOTween>();

            settings.hasScalableText = true;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            fontSizeTween.Kill();
        }
        #endregion

        #region OVERRIDEN_METHODS
        protected override void WasDestroyComponent()
        {
            if (GetComponents<ScalerText>().Length > 1) return;

            settings.hasScalableText = false;
        }

        public override Tween CreateBackTween()
        {
            ChangeStateSizer(false);
            return fontSizeTween;
        }
        public override Tween CreateForwardTween()
        {
            ChangeStateSizer(true);
            return fontSizeTween;
        }
        #endregion

        #region PRIVATE_METHODS
        private void ChangeStateSizer(bool elementIsSelect)
        {
            if (elementIsSelect)
            {
                fontSizeTween.Kill();
                StartCyclicChange();
            }

            if (!elementIsSelect)
            {
                fontSizeTween.Kill();
                fontSizeTween = DOTween.To(() => text.fontSize, y => text.fontSize = y, (int)startFontSize, durationChangeFontSizeText).SetEase(Ease.Linear).OnComplete(OnCompleteBack.Invoke);
            }
        }

        private void StartCyclicChange()
        {
            fontSizeTween = DOTween.To(() => text.fontSize, y => text.fontSize = y, (int)neccessaryFontSize, durationChangeFontSizeText / 2).SetEase(Ease.Linear).OnComplete(ReverseChange);

        }
        private void ReverseChange()
        {
            fontSizeTween = DOTween.To(() => text.fontSize, y => text.fontSize = y, (int)startFontSize, durationChangeFontSizeText / 2).SetEase(Ease.Linear).OnComplete(() => 
            {
                OnCompleteForward.Invoke();
                StartCyclicChange();
            });
        }
        #endregion
    }
}