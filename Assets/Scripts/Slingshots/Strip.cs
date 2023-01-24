#nullable enable
using UnityEngine;


namespace Slingshots
{
    [RequireComponent(typeof(LineRenderer))]
    public class Strip : MonoBehaviour
    {
        [SerializeField] private Transform target = null!;
        private LineRenderer lineRenderer = null!;
        private const int PointCount = 2;
        private const int StartPoint = 0;
        private const int EndPoint = 1;


        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>()!;
            lineRenderer.positionCount = PointCount;
            lineRenderer.SetPosition(StartPoint, transform.position);
        }


        private void Update()
        {
            lineRenderer.SetPosition(EndPoint, target.position);
        }
    }
}