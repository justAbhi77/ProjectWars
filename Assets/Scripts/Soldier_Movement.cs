using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Soldier_Movement : MonoBehaviour
{
    [SerializeField]
    int range = 2;

    [SerializeField]
    LineRenderer pathrender;

    [SerializeField]
    bool working = false;

    [SerializeField]
    List<Vector3> path;

    [SerializeField]
    float waitforseconds=3,lerpvalue=3;

    public static Soldier_Movement self;

    WaitForSeconds wait;

    void Awake()
    {
        self = this;
        path = new List<Vector3>();
        wait = new WaitForSeconds(waitforseconds);
    }

    public void move(Vector3 pos)
    {
        pathrender.positionCount = 0;
        if (working)
            return;

        int dis = (int)(Mathf.Abs(pos.x - transform.position.x) + Mathf.Abs(pos.y - transform.position.y));

        if (dis > range)
        {
            Debug.Log("Range error Given " + dis + " Expected " + range);
            return;
        }

        working = true;

        Debug.Log(dis + " " + pos);

        StartCoroutine(FindPathandmove(pos));
    }

    IEnumerator FindPathandmove(Vector3 Dest_pos)
    {
        yield return StartCoroutine(FindPath(Dest_pos));

        yield return Guimove();
    }

    IEnumerator FindPath(Vector3 dest_pos)
    {
        path.Clear();

        yield return null;

        float newMovementCostToNeighbour;

        List<Node> openlist = new List<Node>();
        List<Node> closedlist = new List<Node>();

        openlist.Add(new Node(transform.position));

        Node current;
        yield return null;

        while (openlist.Count > 0)
        {
            current = openlist[0];

            openlist.Remove(current);

            yield return wait;

            closedlist.Add(current);

            if ((Vector2)current.position == (Vector2)dest_pos)
            {
                Node n = closedlist[closedlist.IndexOf(current)];
                
                Debug.Log("path start");
                int i = 0;
                pathrender.positionCount = 0;

                yield return null;

                while (n.parent != null)
                {
                    pathrender.positionCount++;
                    Debug.Log(n.position+" "+n.cost);
                    pathrender.SetPosition(i, n.position);
                    path.Add(n.position);
                    n = n.parent;
                    i++;

                    yield return null;
                }
                
                yield return null;

                pathrender.positionCount++;
                Debug.Log(transform.position);
                pathrender.SetPosition(i, transform.position);
                Debug.Log("path end");

                yield return null;

                path.Reverse();

                yield return null;

                break;
            }
            yield return null;

            foreach (Node neighbour in getneighbours(current.position))
            {
                if (closedlist.Contains(neighbour))
                    continue;

                newMovementCostToNeighbour = getCost(dest_pos, neighbour.position);

                neighbour.cost = newMovementCostToNeighbour;
                neighbour.parent = current;

                if (!openlist.Contains(neighbour))
                    openlist.Add(neighbour);
            }

            openlist = openlist.OrderBy(a => a.cost).ToList();

            Debug.Log("Openlist start");
            foreach (Node node in openlist)
                Debug.Log(node.position + " " + node.cost);
            Debug.Log("Openlist end");

            yield return null;
        }
    }

    List<Node> getneighbours(Vector3 current)
    {
        List<Node> neighbours = new List<Node>();

        Vector3 curpos;

        RaycastHit2D hitinfo;

        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if ((i == 0 && j == 0) || (Mathf.Abs(i) + Mathf.Abs(j) == 2))
                    continue;

                curpos = current + new Vector3(i, j, 0);
                curpos.z = -1.5f;

                hitinfo = Physics2D.Raycast(curpos, Vector3.forward * 2);

                Debug.DrawRay(curpos, Vector3.forward * 2, Color.red, 15f);

                if (hitinfo.collider != null)
                {
                    curpos.z = hitinfo.transform.position.z - 0.5f;
                    neighbours.Add(new Node(curpos));
                }
            }
        }

        return neighbours;
    }

    float getCost(Vector3 dest,Vector3 pos)
    {
        int dis = (int)(Mathf.Abs(dest.x - pos.x) + Mathf.Abs(dest.y - pos.y));

        RaycastHit2D hitinfo = Physics2D.Raycast(pos, Vector3.forward * 2);

        if (hitinfo.collider.gameObject.name.Contains("Road"))
            return dis + .7f;

        else if (hitinfo.collider.gameObject.name.Contains("Plain"))
            return dis + 1;
        
        return dis + 2;
    }

    IEnumerator Guimove()
    {
        for(int i = 0; i < path.Count; i++)
        {
            while ((transform.position - path[i]).sqrMagnitude > Mathf.Epsilon)
            {
                transform.position = Vector3.MoveTowards(transform.position, path[i], lerpvalue * Time.deltaTime);
                yield return null;
            }

            transform.position = path[i];
            yield return null;
        }

        working = false;
    }

}
