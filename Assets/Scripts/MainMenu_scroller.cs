using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

        for (int i = 0; i < childcount; i++)
        {
            temp = transform.GetChild(i).GetComponent<RectTransform>();
            children.Add(temp);
        }

        children[incenter].GetComponent<Animator>().enabled = true;
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

        invisiblemovement -= 1;
        if (invisiblemovement < 0)
            invisiblemovement += childcount;

        yield return null;

        children[invisiblemovement].gameObject.SetActive(false);
        children[incenter].GetComponent<Animator>().enabled = false;
        children[incenter].localScale = Vector3.one;

        Vector2 temp = children[0].anchoredPosition;

        yield return null;

        for (int i = 0; i < childcount - 1; i++)
            children[i].DOLocalMove(children[i + 1].anchoredPosition, lerptime, true);

        children[childcount - 1].DOLocalMove(temp, lerptime, true).OnComplete(() => Changebool(invisiblemovement));

        yield return null;

        incenter -= 1;

        if (incenter < 0)
            incenter += childcount;
    }

    IEnumerator MoveDown()
    {
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
