using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New VoidEventChannelSO", menuName = "Scriptable Objects/Events/Void Event Channel")]
public class VoidEventChannelSO : ScriptableObject
{
    /// <summary>
    /// The ScriptableObject's event to invoke.
    /// </summary>
    public UnityAction OnEventRaised;

    public void RaiseEvent()
    {
        OnEventRaised?.Invoke();
    }
}