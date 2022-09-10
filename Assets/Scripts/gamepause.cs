using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamepause : MonoBehaviour
{
    [SerializeField]
    GameObject pausemenu;

    [SerializeField]
    Slider slider_value;

    [SerializeField]
    bool paused=true;

    Soldier_Movement soldier_ref;

    private void Start()
    {
        slider_value.value = music.obj.getvolume();
    }

    public void pausegame()
    {
        pausemenu.SetActive(paused);
        if (paused)
        {
            soldier_ref = Soldier_Movement.self;
            Soldier_Movement.self = null;
        }
        else
            Soldier_Movement.self = soldier_ref;
        paused = !paused;
    }

    public void backtomenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void OnValuechanged(float value)
    {
        music.obj.onslidervaluechange(value);
    }
}
