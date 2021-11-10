using UnityEngine;

namespace ggj
{
    /// <summary>
    /// Use for items that need UI to 'view' up close.
    /// Examples: Keypad, computer interface, etc.
    /// </summary>
    public interface IViewable
    {
        enum ViewState
        {
            Unviewed,
            Viewed
        };
        
        GameObject ViewableObject();
        
        void ViewItem();
        void UnviewItem();
    }
}