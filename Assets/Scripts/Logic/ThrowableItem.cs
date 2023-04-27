using UnityEngine;

namespace Logic
{
    public class ThrowableItem : MonoBehaviour, IThrowable
    {
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private float strength = 1;

        public void Throw(Vector3 direction)
        {
            rigidbody.AddForce(direction.normalized * strength, ForceMode.Impulse);
        }
    }
}