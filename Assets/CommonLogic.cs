using System.Linq;
using UnityEngine;

public static class CommonLogic
{
    public static GameObject FindClosestObject(string tag, Vector3 position)
    {
        return GameObject.FindGameObjectsWithTag(tag)
            .Where(p => p.transform.position != position)
            .OrderBy(p => Vector3.Distance(p.transform.position, position))
            .FirstOrDefault();
    }
}
