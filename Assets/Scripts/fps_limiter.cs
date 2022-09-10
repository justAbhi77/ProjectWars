using UnityEngine;

/// <summary>
/// Limits the frame rate per second(FPS). 
/// </summary>
public class fps_limiter : MonoBehaviour
{
    /// <summary>
    /// The target frame rate.
    /// </summary>
    // The Range fields provide a slider in the Editor.
    [SerializeField, Range(60, 144)]
    int target_framerate = 62;
    [SerializeField]
    bool fps_lmt=true;

    void Start()
    {
        if (fps_lmt)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = target_framerate;
        }
    }
}
