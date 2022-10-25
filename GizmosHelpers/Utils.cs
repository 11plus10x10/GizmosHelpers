using UnityEngine;

namespace GizmosHelpers
{
    public class Utils : MonoBehaviour
    {
        public static void DrawCross(Vector3 aimPoint, float width, Color color)
        {
            Gizmos.color = color;
            Gizmos.DrawLine(aimPoint + new Vector3(0, width, 0), aimPoint + new Vector3(0, -width, 0));
            Gizmos.DrawLine(aimPoint + new Vector3(width, 0, 0), aimPoint + new Vector3(-width, 0, 0));
            Gizmos.DrawLine(aimPoint + new Vector3(0, 0, width), aimPoint + new Vector3(0, 0, -width));
        }

        public static void DrawArrow(
            Vector3 pos,
            Vector3 direction,
            Color color,
            float size = 1f,
            float arrowHeadLength = 0.25f,
            float arrowHeadAngle = 20f)
        {
            Gizmos.color = color;
            Gizmos.DrawRay(pos, direction * size);

            var right = Quaternion.LookRotation(direction * size) *
                        Quaternion.Euler(0, 180 + arrowHeadAngle, 0) *
                        Vector3.forward * size;
            var left = Quaternion.LookRotation(direction * size) *
                       Quaternion.Euler(0, 180 - arrowHeadAngle, 0) *
                       Vector3.forward * size;
            
            Gizmos.DrawRay(pos + direction * size, right * arrowHeadLength);
            Gizmos.DrawRay(pos + direction * size, left * arrowHeadLength);
        }
    }
}
