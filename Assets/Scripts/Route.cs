using System.Linq;
using UnityEngine;

public class Route : MonoBehaviour
{
    public Transform[] points;

    private void Awake()
    {
        //var transforms = GetComponentsInChildren<Transform>();
        //points = transforms.Select(t => t.position).ToArray();
    }
}
