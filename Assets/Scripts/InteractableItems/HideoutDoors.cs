using System.Collections;
using System.Collections.Generic;
using ggj;
using UnityEngine;

public class HideoutDoors : MonoBehaviour
{
    [SerializeField] private GameObject _leftDoor;
    [SerializeField] private GameObject _rightDoor;

    [SerializeField] private Collider _exitCollider;

    private void Start()
    {
        _exitCollider.GetComponent<MeshRenderer>().enabled = false;
        _exitCollider.gameObject.SetActive( false );
    }
    
    public void CloseDoors()
    {
        _leftDoor.transform.localPosition = new Vector3( _leftDoor.transform.localPosition.x,
            _leftDoor.transform.localPosition.y, .435f );
        _rightDoor.transform.localPosition = new Vector3( _rightDoor.transform.localPosition.x,
            _rightDoor.transform.localPosition.y, -.435f );
    }

    public void ShowExit()
    {
        _exitCollider.gameObject.SetActive( true );
    }
}
