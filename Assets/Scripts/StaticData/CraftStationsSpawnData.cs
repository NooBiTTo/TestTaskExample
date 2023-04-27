using System;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    public class CraftStationsSpawnData
    {
        [SerializeField] private Vector3 position;
        public Vector3 Position => position;

        public CraftStationsSpawnData(Vector3 position)
        {
            this.position = position;
        }
    }
}