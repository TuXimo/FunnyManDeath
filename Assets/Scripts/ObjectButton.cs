using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ObjectButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject objectReference;
    public Button button;

    [SerializeField] private Texture2D hoverMouse, normalMouse;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse is over GameObject.");
        //Cursor.SetCursor(hoverMouse,Vector2.zero, cursorMode);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse is over GameObject.");
        //Cursor.SetCursor(normalMouse,Vector2.zero, cursorMode);
    }
}
