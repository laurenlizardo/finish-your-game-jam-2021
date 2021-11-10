using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    [SerializeField] private GameObject _endScreen;
    public void EndGame()
    {
        _endScreen.SetActive( true );
    }
    
}
