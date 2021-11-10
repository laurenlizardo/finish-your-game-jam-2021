using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ggj
{
    [Serializable]
    public class CameraSettings : MonoBehaviour
    {
        [SerializeField] private CameraSwitcher[] _cameraSwitchers;
        
        // Member Methods=======================================
        public void ToggleCameraSwitchers( bool toggle )
        {
            foreach (var cameraSwitcher in _cameraSwitchers)
            {
                cameraSwitcher.Toggle( toggle );
            }
        }
    }
}