using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace ggj
{
    public class HallwayKeypad : InteractableItem, IViewable
    {
        [SerializeField] private ToggleableUI _toggleableUI;
        [SerializeField] private IViewable.ViewState _currentState;
        
        [Space(20)]
        
        [SerializeField] private string _keyCode = "";
        [SerializeField] private string _input = "";
        [SerializeField] private Image _indicator;

        [Space( 20 )]
        
        [SerializeField] private VoidEventChannelSO _onHallwayKeypadSolved;
        
        #region MonoBehaviour Methods |=================================================================================
        private void Start()
        {
            UnviewItem();
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
            _collider.enabled = false;
            ViewableObject().SetActive( true );
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
        
        #region Member Methods |========================================================================================
        public void AppendInput( string number )
        {
            _input += number;
            EvaluateInput();
        }

        private void EvaluateInput()
        {
            if (_input.Length == 4)
            {
                if (_input == _keyCode)
                {
                    StartCoroutine("GoodInput");
                }
                else
                {
                    StartCoroutine("BadInput");
                }
            }
        }

        IEnumerator GoodInput()
        {
            Debug.Log( "CORRECT");
            _indicator.color = Color.green;
            yield return new WaitForSeconds(1);
            UnviewItem();
            
            _onHallwayKeypadSolved?.RaiseEvent();    //PuzzleController.OnHallwayKeypadSolved?.Invoke();
        }
        
        IEnumerator BadInput()
        {
            Debug.Log("START OVER");
            _indicator.color = Color.red;
            yield return new WaitForSeconds(1.5f);
            _indicator.color = Color.white;
            _input = "";
        }
        #endregion Member Methods |=====================================================================================
    }
}