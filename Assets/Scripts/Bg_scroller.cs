using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Scrolls the background image.
/// </summary>
public class Bg_scroller : MonoBehaviour
{
    /// <summary>
    /// Speed of the scrolling for the background.
    /// </summary>
    [SerializeField]
    Vector2 scroll_speed;

    /// <summary>
    /// Reference to the bg image.
    /// </summary>
    RawImage bg_image;

    /// <summary>
    /// Reference to the bg images's texture for movement.
    /// </summary>
    Rect image_rect;

    void Start()
    {
        bg_image = GetComponent<RawImage>();
        image_rect = new Rect(bg_image.uvRect.position, bg_image.uvRect.size);
    }

    void FixedUpdate()
    {
        bg_image.uvRect = image_rect;

        image_rect.position += scroll_speed * Time.deltaTime;
    }
}
