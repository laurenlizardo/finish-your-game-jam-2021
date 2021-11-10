using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ggj
{
    public abstract class InteractableItem : MonoBehaviour
    {
        protected Collider _collider => GetComponent<Collider>();
        
        [SerializeField] protected bool _hasTouchCount;
        [SerializeField] protected int _currentTouchCount;
        [SerializeField] protected int _maxTouchCount = 4;

        //[SerializeField] private CursorController _cursorController;
        
        #region Static Members |========================================================================================
        private static List<InteractableItem> Items = new List<InteractableItem>();

        public static void ActivateInteractableItems()
        {
            foreach (var item in Items)
            {
                item._collider.enabled = true;
            }
        }
        
        public static void DeactivateInteractableItems( InteractableItem selectedItem )
        {
            foreach (var item in Items)
            {
                if ( item != selectedItem )
                {
                    item._collider.enabled = false;
                }
            }
        }
        #endregion Static Members |=====================================================================================
        
        #region MonoBehaviour Methods |=================================================================================
        protected void OnEnable()
        {
            Items.Add( this );
            _collider.enabled = true;
        }

        void OnMouseUp()
        {
            Raise();
        }

        // private void OnMouseEnter()
        // {
        //     _cursorController.ShowCursor( _cursorController._itemCursorTexture );
        // }
        //
        // private void OnMouseExit()
        // {
        //     _cursorController.ShowDefaultCursor();
        // }
        #endregion MonoBehaviour Methods |==============================================================================
        
        #region Abstract Methods |======================================================================================
        public abstract void Raise();
        #endregion Abstract Methods |===================================================================================
        
    }
}