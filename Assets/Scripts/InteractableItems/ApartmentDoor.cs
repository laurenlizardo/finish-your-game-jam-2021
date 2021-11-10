using System.Collections;
using System.Collections.Generic;
using ggj;
using UnityEngine;

public class ApartmentDoor : MonoBehaviour
{
    private Collider _collider => GetComponent<Collider>();
    private Quaternion _doorRotation = Quaternion.Euler(0,-20,0);
    
    // MonoBehaviour Methods===================================
    private void Awake()
    {
        //PuzzleController.OnHallwayKeypadSolved.AddListener( OpenDoor );
        PuzzleController.OnHallwayDoorClicked.AddListener( CloseDoor );
    }

    private void Start()
    {
        _collider.enabled = false;
    }

    private void OnMouseUp()
    {
        PuzzleController.OnHallwayDoorClicked?.Invoke();
    }
    
    // Member Methods============================================
    public void OpenDoor()
    {
        gameObject.transform.localRotation = _doorRotation;
        _collider.enabled = true;
    }

    private void CloseDoor()
    {
        gameObject.transform.localRotation = Quaternion.identity;
        Destroy( _collider );
    }
}