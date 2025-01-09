using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Route))]
public class RouteEditor : Editor
{
    [SerializeField] private float radius = 0.5f;
    private void OnSceneGUI()
    {
        var route = target as Route;

        Handles.color = Color.green;
        var postitions = route.points.Select(t => t.position).ToArray();
        Handles.DrawPolyLine(postitions);
        Handles.DrawLine(postitions[0], postitions.Last());

        Handles.color = Color.red;
        foreach (var point in route.points)
        {
            Handles.DrawWireArc(point.position, Vector3.up, point.right, 360f, radius);
            Handles.Label(point.position, point.name);
        }
    }
}