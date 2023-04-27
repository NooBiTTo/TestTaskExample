using System.Linq;
using Logic;
using StaticData;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        private const string playerInitialPointTag = "PlayerInitialPoint";

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelStaticData levelData = (LevelStaticData) target;
            if (GUILayout.Button("Collect"))
            {
                levelData.IngredientSpawnDatas = FindObjectsOfType<IngredientSpawnMarker>()
                    .Select(ingredientSpawnMarker => new IngredientSpawnData
                    (ingredientSpawnMarker.TypeId,
                        ingredientSpawnMarker.transform.position))
                    .ToList();

                levelData.CraftStationSpawnDatas = FindObjectsOfType<CraftStationSpawnMarker>()
                    .Select(ingredientSpawnMarker => new CraftStationsSpawnData
                        (ingredientSpawnMarker.transform.position))
                    .ToList();

                levelData.LevelKey = SceneManager.GetActiveScene().name;
                levelData.InitialPlayerPosition = GameObject.FindWithTag(playerInitialPointTag).transform.position;
            }

            EditorUtility.SetDirty(target);
        }
    }
}