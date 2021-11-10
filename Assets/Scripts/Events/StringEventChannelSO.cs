using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This is a ScriptableObject event channel.
/// Multiple events can be created in the Project folder.
/// To invoke their UnityAction, "plug" the event channel in a MonoBehaviour that exists in the scene, preferably a button.
/// To add a listener to the event channel, select a game object with the StringEventListener component and drag an EventChannelSO into the EventChannelSO field.
/// </summary>
[CreateAssetMenu( fileName = "New StringEventChannel", menuName = "Scriptable Objects/Events/String Event Channel" )]
public class StringEventChannelSO : ScriptableObject
{
    /// <summary>
    /// The ScriptableObject's event to invoke.
    /// </summary>
    public UnityAction<StringReference> OnEventRaised;

    public void RaiseEvent( StringReference value )
    {
        OnEventRaised?.Invoke( value );
    }

    public StringReference StringReference;
}