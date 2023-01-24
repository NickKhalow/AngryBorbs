using UnityEngine;
using UnityEngine.Events;


namespace Slingshots
{
    public class ShotPoint : MonoBehaviour
    {
        [SerializeField] private float maxDistance = 5;
        [Header("Debug")] [SerializeField] private Vector3 start;
        public UnityEvent<Vector3> release = new();
        private new Camera camera;


        private void Start()
        {
            camera = Camera.main;
            start = transform.position;
        }


        private void OnMouseDrag()
        {
            if (enabled == false)
            {
                return;
            }
            
            var target = camera!.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
            if (Vector3.Distance(start, target) < maxDistance)
            {
                transform.position = target;
            }
            else
            {
                var direction = (target - start).normalized * maxDistance;
                transform.position = start + direction;
            }
        }


        private void OnMouseUp()
        {
            var releasePosition = transform.position;
            transform.position = start;
            var delta = releasePosition - start;
            release?.Invoke(delta.normalized * (delta.magnitude / maxDistance));
        }
    }
}