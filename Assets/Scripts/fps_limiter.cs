using UnityEngine;

/// <summary>
/// Limits the frame rate(FPS). 
/// </summary>
public class fps_limiter : MonoBehaviour
{
    /// <summary>
    /// The target frame rate.
    /// </summary>
    [SerializeField, Range(60, 144)]
    int target_framerate = 62;
    [SerializeField]
    bool fps_lmt;

    void Start()
    {
        if (fps_lmt)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = target_framerate;
        }
    }
}
