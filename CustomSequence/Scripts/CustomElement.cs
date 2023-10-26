using DG.Tweening;

namespace DOTweenElement.UI
{
    public class CustomElement : ElementDOTween
    {
        protected Tween customTween;

        protected bool wasCalledReset=false;

        #region UNITY_EVENTS
        protected override void Start()
        {
            base.Start();

            //write your logic of actions
            CustomStart();
        }

        private void Reset()
        {
            if (!wasCalledReset)
            {
                settings = GetComponent<SettingsElementDOTween>();

                settings.hasCustom = true;

                wasCalledReset = true;
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            

            //write your logic of actions
            CustomOnDestroy();
        }
        #endregion

        #region OVERRIDDEN_METHODS
        protected override void WasDestroyComponent()
        {
            var type = this.GetType();
            if (GetComponents(type).Length > 1) return;

            settings.hasCustom = false;
        }
        public override Tween CreateBackTween()
        {
            //write your logic of actions
            CreateReverseTween();

            return customTween;
        }
        public override Tween CreateForwardTween()
        {
            //write your logic of actions
            CreateDirectTween();

            return customTween;
        }
        #endregion

        #region VIRTUAL_METHODS
        protected virtual void CustomStart() { }
        protected virtual void CustomOnDestroy() { customTween.Kill(); }
        protected virtual void CreateReverseTween() { }
        protected virtual void CreateDirectTween() { }
        #endregion
    }
}