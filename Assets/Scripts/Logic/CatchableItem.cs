using UnityEngine;

namespace Logic
{
    public class CatchableItem : MonoBehaviour, ICatchable
    {
        [SerializeField] private Transform itemRoot;
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private Collider collider;

        public void Catch(Transform holdingPoint)
        {
            collider.enabled = false;
            rigidbody.isKinematic = true;
            itemRoot.parent = holdingPoint;
            itemRoot.transform.localPosition = Vector3.zero;
            itemRoot.transform.localRotation = Quaternion.identity;
            rigidbody.detectCollisions = false;
        }

        public void Drop()
        {
            itemRoot.parent = null;
            collider.enabled = true;
            rigidbody.isKinematic = false;
            rigidbody.detectCollisions = true;
        }
    }
}