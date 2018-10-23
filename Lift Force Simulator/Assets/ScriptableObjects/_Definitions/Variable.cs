using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Base class for new <see cref="ScriptableObject"/> classes.
/// </summary>
/// <typeparam name="T"> Type that this <see cref="ScriptableObject"/> holds.</typeparam>
public class Variable<T> : ScriptableObject
{
    [SerializeField] private T value;

    public T Value
    {
        get
        {
            return value;

        }
        set
        {
            this.value = value;
            ValueChangedEvent.Invoke();
        }
    }

    public UnityEvent ValueChangedEvent;
}