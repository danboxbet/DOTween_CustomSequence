using System;

#if UNITY_EDITOR
[AttributeUsage(AttributeTargets.Method)]
public class EditorButtonAtribute : Attribute
{
    public string name;
    
    public EditorButtonAtribute(string name)
    {
        this.name = name;
    }
}
#endif