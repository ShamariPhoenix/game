using UnityEngine;
public static class TransformExtensions
{
    public static void SetPosition2D(this Transform transform, Vector2 position)
    {
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }
}