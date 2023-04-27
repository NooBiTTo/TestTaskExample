using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelKey;
        public List<CraftStationsSpawnData> CraftStationSpawnDatas;
        public List<IngredientSpawnData> IngredientSpawnDatas;
        public Vector3 InitialPlayerPosition;
    }
}