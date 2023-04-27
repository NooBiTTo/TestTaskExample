using UnityEngine;

namespace Logic
{
    public interface ICatchable
    {
        void Catch(Transform holdingPoint);
        void Drop();
    }
}