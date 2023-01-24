#nullable enable
using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;


namespace Borbs
{
    [Serializable]
    public class BorbTransfer
    {
        [SerializeField] private float duration = 1;
        [SerializeField] private float jumpPower = 2;


        public IEnumerator Transfer(Borb borb, Vector3 target)
        {
            yield return borb.transform.DOJump(
                target,
                jumpPower,
                1,
                duration
            )!.WaitForCompletion();
        }
    }
}