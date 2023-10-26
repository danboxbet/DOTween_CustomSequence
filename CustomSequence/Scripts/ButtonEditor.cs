using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(Object),true,isFallback = false)]
[CanEditMultipleObjects]
public class ButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        foreach(var target in targets)
        {
            var mis = target.GetType().GetMethods().Where(m => m.GetCustomAttributes().Any(a => a.GetType() == typeof(EditorButtonAtribute)));

            if (mis != null)
            {
                foreach (var mi in mis)
                {
                    if (mi != null)
                    {
                        var attribute = mi.GetCustomAttribute(typeof(EditorButtonAtribute)) as EditorButtonAtribute;
                        if (GUILayout.Button(attribute.name))
                        {
                            mi.Invoke(target, null);
                        }
                    }
                }
            }
        }
    }
}
#endif