using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private CursorMode _cursorMode = CursorMode.Auto;
    [SerializeField] private Vector2 _hotSpot = Vector2.zero;[SerializeField] private Texture2D _defaultCursorTexture;
    public Texture2D _itemCursorTexture;
    public Texture2D _cameraCursorTexture;

    public void ShowCursor( Texture2D texture )
    {
        //Cursor.SetCursor( texture, _hotSpot, _cursorMode );
    }

    public void ShowDefaultCursor()
    {
        //Cursor.SetCursor( _defaultCursorTexture, _hotSpot, _cursorMode );
    }

    private void Start()
    {
        ShowDefaultCursor();
    }
}