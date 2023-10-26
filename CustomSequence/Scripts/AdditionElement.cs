using System.Collections.Generic;
using UnityEngine;

namespace DOTweenElement.UI
{
    public abstract class AdditionElement : MonoBehaviour
    {
        #region PUBLIC_STATIC_METHODS
#if UNITY_EDITOR
        public static void AddElementDOTween<T>(GameObject changerObject) where T : ElementDOTween
        {
            if (changerObject.GetComponent<T>() == null)
                changerObject.AddComponent<T>();
        }
        public static void RemoveElementDOTween<T>(GameObject changerObject) where T : ElementDOTween
        {
            var arrayElements = changerObject.GetComponents<T>();

            if (arrayElements != null)
            {
                foreach (var element in arrayElements)
                {
                    DestroyImmediate(element);
                }
            }
        }

        public static void ResetCustomElementsSequence<T>(GameObject changerObject, List<SettingsElementDOTween.SettingsAnimateElement> settingsAnimateElements) where T: CustomElement
        {
            var arrayCustoms = changerObject.GetComponents<CustomElement>();
           
            foreach (var component in arrayCustoms)
            {
                DestroyImmediate(component);
            }

            settingsAnimateElements.RemoveAll(item => item.elementDOTween == null);
        }
        public static void RemoveAllElementsSequence(GameObject changerObject, List<SettingsElementDOTween.SettingsAnimateElement> settingsAnimateElements)
        {
            settingsAnimateElements.Clear();

            var standartElements = changerObject.GetComponents<ElementDOTween>();
            var customElements = changerObject.GetComponents<CustomElement>();

            foreach (var element in standartElements)
            {
                DestroyImmediate(element);
            }
            foreach (var element in customElements)
            {
                DestroyImmediate(element);
            }
        }
#endif
        #endregion
    }
}