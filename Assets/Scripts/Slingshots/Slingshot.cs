#nullable enable
using Borbs;
using System.Collections;
using UnityEngine;
using Utils;


namespace Slingshots
{
    public class Slingshot : MonoBehaviour
    {
        [SerializeField] private BorbTransfer borbTransfer = new();
        [SerializeField] private float power = 10;
        [SerializeField] private float count = 3;
        [Header("Dependencies")] [SerializeField]
        private ShotPoint shotPoint = null!;
        [SerializeField] private BorbSource borbSource = null!;


        private void Awake()
        {
            shotPoint.EnsureNotNull();
            borbSource.EnsureNotNull();
        }


        private IEnumerator Start()
        {
            for (int i = 0; i < count; i++)
            {
                var borb = borbSource.NextBorb();
                yield return SeatBorb(borb);
                yield return WaitShot(borb);
            }

            print($"Game Over");
                
        }


        private IEnumerator WaitShot(Borb borb)
        {
            var done = false;

            void Shot(Vector3 direction)
            {
                done = true;
                //print($"Direction {direction}");
                borb.EnsureNotNull().Launch(-direction * power);
            }

            shotPoint.release!.AddListener(Shot);
            // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
            while (done == false)
            {
                borb.transform.position = shotPoint.transform.position;
                yield return null;
            }

            shotPoint.release.RemoveListener(Shot);
        }


        private IEnumerator SeatBorb(Borb borb)
        {
            shotPoint.enabled = false;
            yield return borbTransfer.Transfer(borb, shotPoint.transform.position);
            shotPoint.enabled = true;
        }
    }
}