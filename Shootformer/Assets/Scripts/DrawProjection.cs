using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawProjection : MonoBehaviour
{

    Gun gun;
    LineRenderer lineRenderer;

    //number of points rendered by line renderer
    public int linePoints = 50;

    //distance between the points
    public float timeBetweenPoints = 0.1f;

    //layers that will prevent line being drawn
    public LayerMask CollidableLayers;

    // Start is called before the first frame update
    void Start()
    {
        gun = GetComponent<Gun>();
        lineRenderer = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.positionCount = linePoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = gun.NadeShootPoint.position;
        Vector3 startingVelocity = gun.NadeShootPoint.up * gun.nadeVelocity;
        for (float t = 0; t < linePoints; t += timeBetweenPoints)
        {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y / 2f * t * t;
            points.Add(newPoint);

            if(Physics.OverlapSphere(newPoint, 2, CollidableLayers).Length > 0)
            {
                lineRenderer.positionCount = points.Count;
                break;
            }
        }

        lineRenderer.SetPositions(points.ToArray());

    }
}
