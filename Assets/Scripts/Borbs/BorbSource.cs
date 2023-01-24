#nullable enable
using UnityEngine;
using Utils;


namespace Borbs
{
    public class BorbSource : MonoBehaviour
    {
        [SerializeField] private Borb borbPrefab = null!;


        private void Awake()
        {
            borbPrefab.EnsureNotNull();
        }


        public Borb NextBorb()
        {
            return Instantiate(borbPrefab, transform.position, Quaternion.identity)!;
        }
    }
}