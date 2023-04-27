using Logic;
using UnityEngine;

namespace Player
{
    public class PlayerObjectCatcher
    {
        private readonly Transform catchPoint;
        private ICatchable catchedObject;
        public ICatchable CatchedObject => catchedObject;

        public PlayerObjectCatcher(Transform catchPoint)
        {
            this.catchPoint = catchPoint;
        }

        public void ThrowCatchedObject(Vector3 direction)
        {
            if (catchedObject is MonoBehaviour catchableGameObject)
            {
                if (catchableGameObject.TryGetComponent(out IThrowable throwableObject))
                {
                    DropCatchedObject();
                    throwableObject?.Throw(direction);
                }
            }
        }

        public void DropCatchedObject()
        {
            if (CatchedObject != null)
            {
                catchedObject.Drop();
                catchedObject = null;
            }
        }

        public void CatchAimedObject(ICatchable catchableObject)
        {
            if (catchableObject != null && catchedObject == null)
            {
                catchableObject.Catch(catchPoint);
                catchedObject = catchableObject;
            }
        }
    }
}