using Logic;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(CraftStationSpawnMarker))]
    public class CraftStationSpawnMarkerEditor : UnityEditor.Editor
    {
        private const float gizmoAlpha = 0.5f;
        private static Vector3 gizmoCenterOffset = new Vector3(0f, 0.9f, 0.5f);
        private static Vector3 gizmoSize = new Vector3(1.9f, 1.8f, 1.3f);

        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(CraftStationSpawnMarker spawner, GizmoType type)
        {
            if (!Application.IsPlaying(spawner.gameObject))
            {
                var gizmoColor = Color.red;
                gizmoColor.a = gizmoAlpha;
                Gizmos.color = gizmoColor;

                Gizmos.DrawCube(spawner.transform.position + gizmoCenterOffset, gizmoSize);
            }
        }
    }
}