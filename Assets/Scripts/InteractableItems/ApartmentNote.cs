using UnityEngine;

namespace ggj
{
    public class ApartmentNote : InteractableItem, IViewable
    {
        [SerializeField] private ToggleableUI _toggleableUI;
        [SerializeField] private IViewable.ViewState _currentState;
        
        #region MonoBehaviour Methods |=================================================================================
        private void Start()
        {
            //UnviewItem();
        }
        #endregion MonoBehaviour Methods |==============================================================================

        #region Abstract Overrides |====================================================================================
        public override void Raise()
        {
            if (_currentState == IViewable.ViewState.Unviewed)
            {
                ViewItem();
            }
            else
            {
                UnviewItem();
            }
        }
        #endregion Abstract Overrides |=================================================================================
        
        #region Interface Implementations |=============================================================================
        public GameObject ViewableObject()
        {
            return _toggleableUI.gameObject;
        }    
    
        public void ViewItem()
        {
            ViewableObject().SetActive( true );
            _collider.enabled = false;
            _currentState = IViewable.ViewState.Viewed;
            
            DeactivateInteractableItems( this );
        }

        public void UnviewItem()
        {
            _collider.enabled = true;
            ViewableObject().SetActive( false );
            _currentState = IViewable.ViewState.Unviewed;
            
            ActivateInteractableItems();
        }
        #endregion Interface Implementations |==========================================================================
    }
}