using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu]
public class DoubleVariable : Variable<double>
{
}

#if UNITY_EDITOR
[CustomEditor(typeof(DoubleVariable))]
public class DoubleVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DoubleVariable myScript = (DoubleVariable) target;
        if (GUILayout.Button("Invoke"))
        {
            myScript.ValueChangedEvent.Invoke();
        }
    }
}
#endif
