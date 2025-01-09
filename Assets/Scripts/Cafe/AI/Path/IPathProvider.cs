using UnityEngine;

namespace Cafe.AI.Path
{
    public interface IPathProvider
    {
        Vector3 GetNextPosition();
    }
}