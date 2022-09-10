using UnityEngine;
using UnityEngine.UI;

public class music : MonoBehaviour
{
    public static music obj;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    Slider slider_value;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (obj != null)
        {
            audioSource.volume = obj.getvolume();
            Destroy(obj.gameObject);
        }
        obj = this;
        DontDestroyOnLoad(gameObject);
        slider_value.value = audioSource.volume;
    }

    public void onslidervaluechange(float value)
    {
        audioSource.volume = value;
    }

    public float getvolume()
    {
        return audioSource.volume;
    }
}
