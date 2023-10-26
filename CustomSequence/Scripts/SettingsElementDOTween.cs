using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DOTweenElement.UI
{
    [RequireComponent(typeof(Graphics))]
    public class SettingsElementDOTween : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        #region NESTED_CLASSES
        [Serializable]
        public class SettingsAnimateElement
        {
            public enum AddAnimateElementMode
            {
                Append,
                Join
            }

            public AddAnimateElementMode animateForwardMode;
            public AddAnimateElementMode animateBackMode;

            public ElementDOTween elementDOTween;
        }
        #endregion

        [Header("Items to add")]
        [HideInInspector] public bool hasCustom = false;
        public bool isScalableObject = false;
        public bool hasChangeableColorOutlines = false;
        public bool hasScalableText = false;
        public bool isAccompaniedBySound = false;
        public bool isFlickering = false;
        public bool isFillable = false;

        [Header("Arrange the animations in the right order")]
        public List<SettingsAnimateElement> animateList;

        private GameObject changerObject;

        private Sequence forwardSequence;
        private Sequence backSequence;

        #region INTERFACE_IMPLEMENTATIONS
        public void OnPointerEnter(PointerEventData eventData)
        {
            KillCurrentSequence(backSequence);
            InitSequence();

            BuildForwardSequence();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            KillCurrentSequence(forwardSequence);
            InitSequence();

            BuildBackSequence();
        }
        #endregion

        #region PRIVATE_METHODS
        private void KillCurrentSequence(Sequence sequence)
        {
            sequence.Kill();
        }
        private void InitSequence()
        {
            forwardSequence = DOTween.Sequence();
            backSequence = DOTween.Sequence();
        }

        private void BuildForwardSequence()
        {
            foreach (var element in animateList)
            {
                if (element.animateForwardMode == SettingsAnimateElement.AddAnimateElementMode.Join)
                    forwardSequence.Join(element.elementDOTween.CreateForwardTween());

                else forwardSequence.Append(element.elementDOTween.CreateForwardTween());
            }
        }
        private void BuildBackSequence()
        {
            foreach (var element in animateList)
            {
                if (element.animateBackMode == SettingsAnimateElement.AddAnimateElementMode.Join)
                    backSequence.Join(element.elementDOTween.CreateBackTween());

                else backSequence.Append(element.elementDOTween.CreateBackTween());
            }
        }
        
        private void AddElementDOTween<T>() where T: ElementDOTween
        {
            AdditionElement.AddElementDOTween<T>(changerObject);
        }
        private void RemoveElementDOTween<T>() where T: ElementDOTween
        {
            AdditionElement.RemoveElementDOTween<T>(changerObject);
        }
        #endregion

        #region UNITY_EDITOR

#if UNITY_EDITOR
        [EditorButtonAtribute("Apply Settings")]
        public void ApplySettings()
        {
            changerObject = this.gameObject;

            if (isScalableObject) AddElementDOTween<ScalerElementUI>();
            else RemoveElementDOTween<ScalerElementUI>();

            if (hasChangeableColorOutlines) AddElementDOTween<ChangerColorOutlines>();
            else RemoveElementDOTween<ChangerColorOutlines>();

            if (hasScalableText) AddElementDOTween<ScalerText>();
            else RemoveElementDOTween<ScalerText>();

            if (isFlickering) AddElementDOTween<TwinklerImage>();
            else RemoveElementDOTween<TwinklerImage>();

            if (isAccompaniedBySound) AddElementDOTween<SoundElement>();
            else RemoveElementDOTween<SoundElement>();

            if (isFillable) AddElementDOTween<FillerImage>();
            else RemoveElementDOTween<FillerImage>();
        }

        [EditorButtonAtribute("Remove All Elements")]
        public void RemoveAllElements()
        {
            AdditionElement.RemoveAllElementsSequence(this.gameObject, animateList);
        }

        [EditorButtonAtribute("Remove Custom Elements")]
        public void RemoveCustomElements()
        {
            AdditionElement.ResetCustomElementsSequence<CustomElement>(this.gameObject, animateList);
        }
#endif

        #endregion
    }
}