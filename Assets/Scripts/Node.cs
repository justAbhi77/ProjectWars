using UnityEngine;

public class Node
{
    public Vector3 position;

    public float cost;

    public Node parent;

    public Node(Vector3 pos)
    {
        position = pos;
    }

    public override int GetHashCode()
    {
        return (int)position.x ^ (int)position.y;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        if (obj is Node)
            return Equals(obj as Node);

        return false;
    }

    public bool Equals(Node obj)
    {
        return ((int)position.x == (int)obj.position.x) && ((int)position.y == (int)obj.position.y);
    }
}