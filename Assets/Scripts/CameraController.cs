using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using System.Collections.Generic;

namespace ggj
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private static Camera _camera;
        [SerializeField] private static  List<CameraSettings> _cameraSettingsList = new List<CameraSettings>();

        [SerializeField] private CameraSettings MainMenu;
        [SerializeField] private CameraSettings Hallway;
        [SerializeField] private CameraSettings ApartmentNorthView;
        [SerializeField] private CameraSettings ApartmentKitchen;
        [SerializeField] private CameraSettings ApartmentBathroom;
        [SerializeField] private CameraSettings ApartmentBedView;
        [SerializeField] private CameraSettings ApartmentShelfView;
        [SerializeField] private CameraSettings EntranceView;
        [SerializeField] private CameraSettings HideoutFileView;
        [SerializeField] private CameraSettings HideoutGeneratorView;
        [SerializeField] private CameraSettings HideoutEscapeView;
        [SerializeField] private CameraSettings HideoutNorthView;
        
        [Space(15)]
        
        [SerializeField] private CameraSettings _currentSettings;
        
        
        // MonoBehaviour Methods===================================
        private void Awake()
        {
            _camera = Camera.main;
            
            _cameraSettingsList.Add( MainMenu );
            
            _cameraSettingsList.Add( Hallway );
            
            _cameraSettingsList.Add( ApartmentNorthView );
            _cameraSettingsList.Add( ApartmentKitchen );
            _cameraSettingsList.Add( ApartmentBathroom );
            _cameraSettingsList.Add( ApartmentBedView );
            _cameraSettingsList.Add( ApartmentShelfView );
            _cameraSettingsList.Add( EntranceView );
            
            _cameraSettingsList.Add( HideoutFileView );
            _cameraSettingsList.Add( HideoutGeneratorView );
            _cameraSettingsList.Add( HideoutEscapeView );
            _cameraSettingsList.Add( HideoutNorthView );
        }

        private void Start()
        {
            PuzzleController.OnHallwayDoorClicked.AddListener( MoveCameraToApartment );
            
            SetCameraSettings( MainMenu );
            //SetCameraSettings( Hallway );
        }
        
        private void OnValidate()
        {
            SetCameraSettings( _currentSettings );
        }
        
        // Member Methods===============================================
        public static void SetCameraSettings( CameraSettings settings )
        {
            foreach ( var s in _cameraSettingsList )
            {
                if ( s == settings )
                {
                    _camera.transform.localPosition = s.transform.localPosition;
                    _camera.transform.localRotation = s.transform.localRotation;
                    
                    s.ToggleCameraSwitchers( true );
                }
                else
                {
                    s.ToggleCameraSwitchers( false );
                }
            }
        }
        
        public void MoveCameraToHallway()
        {
            SetCameraSettings( Hallway );
        }
        
        private void MoveCameraToApartment()
        {
            SetCameraSettings( ApartmentNorthView );
        }

    }
}

