using System;
using Logic;
using StaticData;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(IngredientSpawnMarker))]
    public class IngredientSpawnMarkerEditor : UnityEditor.Editor
    {
        private const float gizmoAlpha = 0.5f;
        private static Vector3 gizmoSize = new Vector3(0.3f, 0.3f, 0.3f);

        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(IngredientSpawnMarker spawner, GizmoType type)
        {
            if (!Application.IsPlaying(spawner.gameObject))
            {
                Color gizmoColor = Color.black;

                switch (spawner.TypeId)
                {
                    case IngredientTypeId.Red:
                        gizmoColor = Color.red;
                        break;
                    case IngredientTypeId.Green:
                        gizmoColor = Color.green;
                        break;
                    case IngredientTypeId.Blue:
                        gizmoColor = Color.blue;
                        break;
                    case IngredientTypeId.Yellow:
                        gizmoColor = Color.yellow;
                        break;
                    case IngredientTypeId.Magenta:
                        gizmoColor = Color.magenta;
                        break;
                    case IngredientTypeId.Cyan:
                        gizmoColor = Color.cyan;
                        break;
                    case IngredientTypeId.White:
                        gizmoColor = Color.white;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                gizmoColor.a = gizmoAlpha;
                Gizmos.color = gizmoColor;
                Gizmos.DrawCube(spawner.transform.position, gizmoSize);
            }
        }
    }
}