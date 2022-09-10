using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Changes the mouse pointer when it enters/exits the button.
/// It implements two other interfaces, other than MonoBehaviour , in order to achieve this, namely,IPointerEnterHandler and IPointerExitHandler.
/// </summary>
public class OnMouseOver : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    /// <summary>
    /// The texture the pointer is changed to.
    /// </summary>
    [SerializeField]
    Texture2D mouse_tex;

    /// <summary>
    /// Function called when the pointer enters the button.
    /// </summary>
    /// <param name="eventData">
    /// The data sent by the EventSystems namespace.
    /// </param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(mouse_tex, Vector2.zero, CursorMode.Auto);
    }


    /// <summary>
    /// Function called when the pointer exits the button.
    /// </summary>
    /// <param name="eventData">
    /// The data sent by the EventSystems namespace.
    /// </param>
    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        //null defaults to the system pointer.
    }
}
