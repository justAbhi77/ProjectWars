using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Scrolls the menu.
/// </summary>
public class MainMenu_scroller : MonoBehaviour
{
    List<RectTransform> children;

    int childcount, invisiblemovement = 0, incenter;

    [SerializeField]
    bool working = false;

    [SerializeField]
    float lerptime = .5f;

    void Start()
    {
        children = new List<RectTransform>();
        RectTransform temp;

        childcount = transform.childCount;

        incenter = childcount / 2;
        //The center most child will be at the center of the screen.

        for (int i = 0; i < childcount; i++)
        {
            temp = transform.GetChild(i).GetComponent<RectTransform>();
            children.Add(temp);
        }

        children[incenter].GetComponent<Animator>().enabled = true;
        //Animating the centermost child for visual feedback.
    }

    void Update()
    {
        if (working)
            return;
        if (Input.GetKey(KeyCode.UpArrow))
            StartCoroutine(MoveUp());
        else if (Input.GetKey(KeyCode.DownArrow))
            StartCoroutine(MoveDown());
    }

    IEnumerator MoveUp()
    {
        working = true; 

        yield return null; 

        /*During Right shift the last element should cycle to the front of the list
          thus the visual feedback for the last element should be turned off.
        */
        invisiblemovement -= 1;
        if (invisiblemovement < 0)
            invisiblemovement += childcount;

        yield return null;

        children[invisiblemovement].gameObject.SetActive(false); //last element turned off
        children[incenter].GetComponent<Animator>().enabled = false;
        children[incenter].localScale = Vector3.one;

        //Right Shifting list

        Vector2 temp = children[0].anchoredPosition;

        yield return null;

        for (int i = 0; i < childcount - 1; i++)
            children[i].DOLocalMove(children[i + 1].anchoredPosition, lerptime, true);

        children[childcount - 1].DOLocalMove(temp, lerptime, true).OnComplete(() => Changebool(invisiblemovement));

        /*After the right shift has occured, the respective animations and gameobjects 
          need to be switched on.
        */
        yield return null;

        //The center pointer needs to be updated

        incenter -= 1;

        if (incenter < 0)
            incenter += childcount;
    }

    IEnumerator MoveDown()
    {
        /*
         Same as MoveUp() method
         The list is left shifted not right.
        */

        working = true;

        yield return null;

        children[invisiblemovement].gameObject.SetActive(false);
        children[incenter].GetComponent<Animator>().enabled = false;
        children[incenter].localScale = Vector3.one;

        Vector2 temp = children[childcount - 1].anchoredPosition;

        yield return null;

        for (int i = childcount - 1; i > 0; i--)
            children[i].DOLocalMove(children[i - 1].anchoredPosition, lerptime, true);

        children[0].DOLocalMove(temp, lerptime, true).OnComplete(() => Changebool(invisiblemovement, 1));

        incenter = (incenter + 1) % childcount;
    }

    void Changebool(int n, int v = -1)
    {
        working = false;

        children[n].gameObject.SetActive(true);

        if (v != -1)
            invisiblemovement = (invisiblemovement + 1) % childcount;

        children[incenter].GetComponent<Animator>().enabled = true;
    }
}
