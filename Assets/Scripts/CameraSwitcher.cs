using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ggj
{
    [Serializable]
    public class CameraSwitcher : MonoBehaviour
    {
        private MeshRenderer _meshRenderer => GetComponent<MeshRenderer>();
        [SerializeField] private CameraSettings _settings;
        [SerializeField] private CursorController _cursorController;

    #region MonoBehaviour Methods |=====================================================================================
        private void OnEnable()
        {
            _meshRenderer.enabled = false;
        }
        
        private void OnMouseUp()
        {
            CameraController.SetCameraSettings( _settings );
        }

        private void OnMouseEnter()
        {
            _cursorController.ShowCursor( _cursorController._cameraCursorTexture );
        }

        private void OnMouseExit()
        {
            _cursorController.ShowDefaultCursor();
        }
    #endregion MonoBehaviour Methods |==================================================================================

        public void Toggle( bool toggle )
        {
            gameObject.SetActive( toggle );
        }
    }
}
