using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Add this MonoBehaviour to game objects via Inspector.
/// </summary>
public class VoidEventListener : MonoBehaviour
{
    /// <summary>
    /// The ScriptableObject event channel to listen to.
    /// </summary>
    [SerializeField] private VoidEventChannelSO _eventChannel;
    
    /// <summary>
    /// The method(s) to call when the assigned event is invoked.
    /// </summary>
    [SerializeField] public UnityEvent OnEventRaised;

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
    
    public void Respond()
    {
        OnEventRaised?.Invoke();
    }
}