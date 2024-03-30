using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTrail : MonoBehaviour
{
    public Transform objectToFollow;
    public int maxPoints = 100; // Maximum number of points in the line trail
    public float pointSpacing = 0.1f; // Distance between each point

    private LineRenderer lineRenderer;
    private Vector3[] points;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        points = new Vector3[maxPoints];
    }

    private void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        // Shift points array to make room for new point
        for (int i = points.Length - 1; i > 0; i--)
        {
            points[i] = points[i - 1];
        }

        // Add new point at the current position of the object
        points[0] = objectToFollow.position;

        // Update the LineRenderer with the new points
        lineRenderer.positionCount = Mathf.Min(maxPoints, points.Length);
        lineRenderer.SetPositions(points);
    }
}