#nullable enable
using System;
using UnityEngine;


namespace Borbs
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Borb : MonoBehaviour
    {
        private new Rigidbody2D rigidbody = null!;


        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>()!;
            rigidbody.isKinematic = true;
        }


        public void Launch(Vector3 direction)
        {
            rigidbody.isKinematic = false;
            rigidbody.AddForce(direction, ForceMode2D.Impulse);
        }
    }
}