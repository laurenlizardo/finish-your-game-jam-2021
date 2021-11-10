using UnityEngine;

public class StringEventListener : MonoBehaviour
{
    /// <summary>
    /// The ScriptableObject event channel to listen to.
    /// </summary>
    [SerializeField] private StringEventChannelSO _eventChannel;
    
    /// <summary>
    /// The method(s) to call when the assigned event is invoked.
    /// </summary>
    [SerializeField] public StringReferenceEvent OnEventRaised;

    private void OnEnable()
    {
        if ( _eventChannel != null )
        {
            _eventChannel.OnEventRaised += Respond;
        }
    }

    private void OnDisable()
    {
        if ( _eventChannel != null )
        {
            _eventChannel.OnEventRaised -= Respond;
        }
    }
    
    public void Respond( StringReference value )
    {
        OnEventRaised?.Invoke( value );
    }
}