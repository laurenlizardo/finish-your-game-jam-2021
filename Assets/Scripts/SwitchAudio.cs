using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAudio : MonoBehaviour
{
    public GameObject MainMusic;
    public GameObject CountdownMusic;

    void OnMouseUp()
    {
        MainMusic.SetActive( false );
        CountdownMusic.SetActive( true );
    }
}
