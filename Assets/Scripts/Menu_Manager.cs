using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject main_menu,options_menu;

    void Start()
    {
        options_menu.SetActive(false);
        main_menu.SetActive(true);
    }

    public void Startbtn()
    {
        SceneManager.LoadSceneAsync(1);
    }

    /// <summary>
    /// Flips the Gameobject from active to inactive;
    /// </summary>
    public void optionsbtn()
    {
        // activeSelf returns the local active state of this GameObject.
        // Since the gameobjects here are all Parents so both activeSelf and activeInHierarchy work the same here.
        options_menu.SetActive(!options_menu.activeSelf);
        main_menu.SetActive(!main_menu.activeSelf);

        // Manual call to clear the mouse pointer after menu change
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        
        // see Unity Manual for further explaination on GameObject.activeSelf
    }

    /// <summary>
    /// Quit the application entirely.
    /// </summary>
    public void quit()
    {
        Debug.Log("Quitting Application");
        Application.Quit();
    }

}
