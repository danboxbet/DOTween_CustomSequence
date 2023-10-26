using DG.Tweening;
using UnityEngine;

namespace DOTweenElement.UI
{
   
    public class ScalerElementUI : ElementDOTween
    {
        [Header("Set duration")]
        [SerializeField] private float durationChangeScale;

        [Header("Scaling Axes")]
        [SerializeField] private float axisX = 2;
        [SerializeField] private float axisY = 2;

        [Header("Element to scale")]
        [SerializeField] private Transform elementTransform;

        private float axisXOnStart;
        private float axisYOnStart;
        private float axisZOnStart;

        private Tween scaleTween;

        #region UNITY_EVENTS
        protected override void Start()
        {
            base.Start();
            if(Application.isPlaying) GetScaleValueOnRectTransform((RectTransform)elementTransform);
        }

        private void Reset()
        {
            settings = GetComponent<SettingsElementDOTween>();

            settings.isScalableObject = true;
        }
       
        protected override void OnDestroy()
        {
            base.OnDestroy();
            scaleTween.Kill();
        }
        #endregion

        #region OVERRIDDEN_METHODS
        protected override void WasDestroyComponent()
        {
            if (GetComponents<ScalerElementUI>().Length > 1) return;

            settings.isScalableObject = false;
        }

        public override Tween CreateForwardTween()
        {
            CreateTweenScale(axisX, axisY, axisZOnStart, durationChangeScale);
            return scaleTween;
        }
        public override Tween CreateBackTween()
        {
            CreateTweenScale(axisXOnStart, axisYOnStart, axisZOnStart, durationChangeScale);
            return scaleTween;
        }
        #endregion

        #region PRIVATE_METHODS
        private void GetScaleValueOnRectTransform(RectTransform rectTransform)
        {
            axisXOnStart = elementTransform.localScale.x;
            axisYOnStart = elementTransform.localScale.y;
            axisZOnStart = elementTransform.localScale.z;
        }

        private void CreateTweenScale(float endX, float endY, float endZ, float duration)
        {
            if(endX==axisX && endY==axisY)
            scaleTween = elementTransform.DOScale(new Vector3(endX, endY, endZ), duration).OnComplete(OnCompleteForward.Invoke);

            if(endX==axisXOnStart && endY==axisYOnStart)
            scaleTween = elementTransform.DOScale(new Vector3(endX, endY, endZ), duration).OnComplete(OnCompleteBack.Invoke);
        }
        #endregion
    }
}
