using System.Collections;
using System.Collections.Generic;
using ggj;
using UnityEngine;
using UnityEngine.UI;

namespace ggj
{
    public class ApartmentLaptop : InteractableItem, IViewable
    {
        [SerializeField] private ToggleableUI _toggleableUI;
        [SerializeField] private IViewable.ViewState _currentState;
        
        [Space(20)]
        
        [Header("UI Input")]
        [SerializeField] private string _password = "";
        [SerializeField] private string _input = "";
        [SerializeField] private Text _inputText;
        
        [Space(20)]
        
        [Header("Email UI")]
        [SerializeField] private GameObject _message;
        [SerializeField] private GameObject _emailNotification;
        [SerializeField] private GameObject _email;
        
        #region MonoBehaviour Methods |=================================================================================
        private void Start()
        {
            _message.SetActive( false );
            _emailNotification.SetActive( false );
            _email.SetActive( false );
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
        #endregion Interface Implementation |===========================================================================
        
        #region UI Input |==============================================================================================
        public void AppendInput( string character )
        {
            _input += character;
            _inputText.text += "*";
        }

        public void ClearInput()
        {
            _input = "";
            _inputText.text = "";
        }
        
        public void EvaluateInput()
        {
            if (_input == _password)
            {
                StartCoroutine("GoodInput");
            }
            else
            {
                StartCoroutine("BadInput");
            }
        }

        IEnumerator GoodInput()
        {
            Debug.Log( "CORRECT");
            
            ShowMessage();

            yield return new WaitForSeconds( 1.5f );

            ShowEmailNotification();    // TODO: Invoke an event
        }
        
        IEnumerator BadInput()
        {
            Debug.Log("START OVER");
            
            yield return new WaitForSeconds(1f);
            
            ClearInput();
        }
        #endregion UI Input |===========================================================================================

        #region Email UI |==============================================================================================
        private void ShowMessage()
        {
            _message.SetActive( true );
        }

        private void ShowEmailNotification()
        {
            _emailNotification.SetActive( true );
        }

        public void ShowEmail()
        {
            _email.SetActive( true );
        }
        #endregion Email UI |===========================================================================================

        // TODO: Move below elsewhere/invoke via event
        public GameObject[] Lights;

        public void TurnOffLights( )
        {
            foreach ( var light in Lights )
            {
                light.SetActive( false );
            }
        }

        public GameObject SecretDoor;
        
        public void OpenHideout()
        {
            Quaternion rot = Quaternion.Euler( 0, 180, -90 );
            SecretDoor.transform.localRotation = rot;
        }
    }
}
