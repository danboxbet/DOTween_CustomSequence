using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DOTweenElement.UI
{
    public class ChangerColorOutlines : ElementDOTween
    {
        [Header("Set duration")]
        [SerializeField] private float durationChangeColor;

        [Header("Color Outline")]
        [SerializeField] private Color selectColor;
        [SerializeField] private Color deselectColor;

        [Header("Outline to change color")]
        [SerializeField] private Outline outline;

        private Tween outlineTween;

        #region UNITY_EVENTS
        protected override void Start()
        {
            base.Start();
            if (Application.isPlaying) outline.effectColor = deselectColor;
        }

        private void Reset()
        {
            settings = GetComponent<SettingsElementDOTween>();

            settings.hasChangeableColorOutlines = true;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            outlineTween.Kill();
        }
        #endregion

        #region OVERRIDDEN_METHODS
        protected override void WasDestroyComponent()
        {
            if (GetComponents<ChangerColorOutlines>().Length > 1) return;

            settings.hasChangeableColorOutlines = false;
        }
        public override Tween CreateBackTween()
        {
            ChangeOutlineColor(deselectColor, durationChangeColor);
            return outlineTween;
        }
        public override Tween CreateForwardTween()
        {
            ChangeOutlineColor(selectColor, durationChangeColor);
            return outlineTween;
        }
        #endregion

        #region PRIVATE_METHODS
        private void ChangeOutlineColor(Color endColor, float duration)
        {
            if(endColor==selectColor)
            outlineTween = outline.DOColor(endColor, duration).OnComplete(OnCompleteForward.Invoke);

            if(endColor==deselectColor)
            outlineTween = outline.DOColor(endColor, duration).OnComplete(OnCompleteBack.Invoke);
        }
        #endregion

        #region UNITY_EDITOR

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (outline != null && gameObject.activeSelf)
                outline.effectColor = deselectColor;
        }
#endif

        #endregion
    }
}