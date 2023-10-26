using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace DOTweenElement.UI
{
    [RequireComponent(typeof(SettingsElementDOTween))]
    [RequireComponent(typeof(Graphics))]
    [ExecuteAlways]
    public abstract class ElementDOTween : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        protected SettingsElementDOTween settings;

        [HideInInspector] public UnityEvent OnCompleteBack;
        [HideInInspector] public UnityEvent OnCompleteForward;
        protected virtual void Start()
        {
            settings = GetComponent<SettingsElementDOTween>();
        }
        protected virtual void OnDestroy()
        {
           if(settings!=null)
           WasDestroyComponent();
        }

        public virtual void OnPointerEnter(PointerEventData eventData) { }

        public virtual void OnPointerExit(PointerEventData eventData) { }

        public virtual Tween CreateForwardTween() { return null; }

        public virtual Tween CreateBackTween() { return null; }

        protected virtual void WasDestroyComponent() { }
    }
}