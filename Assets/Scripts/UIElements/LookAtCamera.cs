using UnityEngine;

namespace UIElements
{
    public class LookAtCamera : MonoBehaviour
    {
        private Camera followedCamera;

        private void Update()
        {
            Quaternion rotation = followedCamera.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.back, rotation * Vector3.up);
        }

        public void Construct(Camera followedCamera)
        {
            this.followedCamera = followedCamera;
        }
    }
}