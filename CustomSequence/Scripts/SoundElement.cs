using DG.Tweening;
using UnityEngine;

namespace DOTweenElement.UI
{
    public class SoundElement : ElementDOTween
    {
        [Header("Select Target AudioSource")]
        [SerializeField] private AudioSource audioSource;

        [Header("Volume Settings")]
        [SerializeField] private float minSoundVolume = 0.5f;
        [SerializeField] private float maxSoundVolume = 1.0f;
        [SerializeField] private float durationChangeVolume = 2.0f;

        [Header("Pitch Settings")]
        [SerializeField] private float minSoundPitch = 1.0f;
        [SerializeField] private float maxSoundPitch = 2.0f;
        [SerializeField] private float durationChangePitch = 2.0f;

        private Tween audioTween;

        #region UNITY_EVENTS
        protected override void Start()
        {
            base.Start();
            if (Application.isPlaying) SetUsersSetting();
        }

        private void Reset()
        {
            settings = GetComponent<SettingsElementDOTween>();

            settings.isAccompaniedBySound = true;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            audioTween.Kill();
        }
        #endregion

        #region OVERRIDDEN_METHODS
        protected override void WasDestroyComponent()
        {
            if (GetComponents<SoundElement>().Length > 1) return;

            settings.isAccompaniedBySound = false;
        }
        public override Tween CreateBackTween()
        {
            return ConfigureSequence(minSoundPitch, minSoundVolume);
        }
        public override Tween CreateForwardTween()
        {
            return ConfigureSequence(maxSoundPitch, maxSoundVolume);
        }
        #endregion

        #region PRIVATE_METHODS
        private void SetUsersSetting()
        {
            SetUserVolumeSetting();
            SetUsersPitchSetting();
        }
        private void SetUsersPitchSetting()
        {
            audioSource.pitch = minSoundPitch;
        }
        private void SetUserVolumeSetting()
        {
            audioSource.volume = minSoundVolume;
        }

        private Tween ConfigureSequence(float endPitch, float endVolume)
        {
            if(endPitch==minSoundPitch && endVolume==minSoundVolume)
            audioTween = audioSource.DOPitch(endPitch, durationChangePitch).OnStart(() => DOTween.To(() => audioSource.volume, x => audioSource.volume = x, endVolume, durationChangeVolume)).OnComplete(OnCompleteBack.Invoke);

            if (endPitch == maxSoundPitch && endVolume == maxSoundVolume)
            audioTween = audioSource.DOPitch(endPitch, durationChangePitch).OnStart(() => DOTween.To(() => audioSource.volume, x => audioSource.volume = x, endVolume, durationChangeVolume)).OnComplete(OnCompleteForward.Invoke);

            return audioTween;
        }
        #endregion
    }
}