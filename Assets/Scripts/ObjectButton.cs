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
        Cursor.SetCursor(hoverMouse,Vector2.zero, CursorMode.Auto);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(normalMouse,Vector2.zero, CursorMode.Auto);
    }
}
