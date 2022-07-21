using UnityEngine;

public class Tiles : MonoBehaviour
{
    [SerializeField]
    float hoveramount;

    void OnMouseDown()
    {
        if(Soldier_Movement.self)
            Soldier_Movement.self.move(transform.position);
    }

    void OnMouseEnter()
    {
        transform.localScale += Vector3.one * hoveramount;
    }

    void OnMouseExit()
    {
        transform.localScale -= Vector3.one * hoveramount;
    }
}