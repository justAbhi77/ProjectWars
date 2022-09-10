using UnityEngine;

/// <summary>
/// Helper class for the pathfinding algorithm.
/// </summary>
public class Node
{
    public Vector3 position;

    public float cost;

    public Node parent;

    public Node(Vector3 pos)
    {
        position = pos;
    }

    /// <summary>
    /// Method for getting the Hashcode of the current position.
    /// </summary>
    /// <returns>
    /// The computed Hashcode
    /// </returns>
    public override int GetHashCode()
    {
        return (int)position.x ^ (int)position.y;
    }

    /// <summary>
    /// Overriding == for objects of this class.
    /// </summary>
    /// <param name="obj">
    /// The object to check.
    /// </param>
    /// <returns>
    /// Returns true if the positions of the two objects are equal otherwise false.
    /// </returns>
    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        if (obj is Node)
            return Equals(obj as Node);

        return false;
    }

    /// <summary>
    /// Checks the position of the objects.
    /// </summary>
    /// <returns>
    /// Return true is the objects are at same position.
    /// </returns>
    public bool Equals(Node obj)
    {
        return ((int)position.x == (int)obj.position.x) && ((int)position.y == (int)obj.position.y);
    }
}