using TweenPeaks.Loops;
using UnityEditor;
using UnityEngine;

namespace TweenPeaks.Editor
{
    [CustomEditor(typeof(MoveLoop))]
    [CanEditMultipleObjects]
    public class MoveLoopEditor : UnityEditor.Editor
    {
        private MoveLoop MoveLoop { get { return target as MoveLoop; } }

        private Vector2 Center { get { return MoveLoop.transform.position; } }
        private Vector2 StartPoint { get { return Center + MoveLoop.Offset; } }
        private Vector2 FinishPoint { get { return StartPoint - MoveLoop.Offset.normalized * MoveLoop.Length; } }
        private float Length1 { get { return MoveLoop.Offset.magnitude; }}
        private float Length2 { get { return MoveLoop.Length - Length1; }}

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.BeginVertical();

            Vector2 newStartPoint = EditorGUILayout.Vector2Field("Start point", StartPoint - Center) + Center;
            if (newStartPoint != StartPoint)
                UpdateStartPoint(newStartPoint);

            Vector2 newFinishPoint = EditorGUILayout.Vector2Field("Finish point", FinishPoint - Center) + Center;
            if (newFinishPoint != FinishPoint)
                UpdateFinishPoint(newFinishPoint);

            float newLength = EditorGUILayout.FloatField("Length", MoveLoop.Length);
            if (!Mathf.Approximately(newLength, MoveLoop.Length))
                UpdateLength(newLength);

            EditorGUILayout.EndVertical();
        }

        private void UpdateStartPoint(Vector2 newStartPoint)
        {
            float oldLength2 = Length2;
            MoveLoop.Offset = newStartPoint - Center;
            MoveLoop.Length = oldLength2 + Length1;
            EditorUtility.SetDirty(MoveLoop);
        }

        private void UpdateFinishPoint(Vector2 newFinishPoint)
        {
            float newLength2 = Vector2.Distance(Center, newFinishPoint);
            MoveLoop.Length = Length1 + newLength2;
            EditorUtility.SetDirty(MoveLoop);
        }

        private void UpdateLength(float newLength)
        {
            MoveLoop.Offset = MoveLoop.Offset * newLength / MoveLoop.Length;
            MoveLoop.Length = newLength;
            EditorUtility.SetDirty(MoveLoop);
        }

        public void OnSceneGUI()
        {
            float handleSize = HandleUtility.GetHandleSize(Center) * 0.1f;

            if (EditorApplication.isPlaying)
            {
                Vector3 startPoint = MoveLoop.StartPoint + (Vector2)MoveLoop.transform.parent.position;
                Vector3 finishPoint = MoveLoop.FinishPoint + (Vector2)MoveLoop.transform.parent.position;
                Handles.DrawWireCube(startPoint, Vector3.one * handleSize);
                Handles.DrawWireCube(finishPoint, Vector3.one * handleSize);
                Handles.DrawLine(startPoint, finishPoint);
            }
            else
            {
                if (MoveLoop.Offset == Vector2.zero || Mathf.Approximately(MoveLoop.Length, 0f))
                {
                    MoveLoop.Offset = new Vector2(0f, 50f);
                    MoveLoop.Length = 50f;
                }

                Handles.DrawLine(StartPoint, FinishPoint);

                Handles.color = Color.blue;
                Vector2 newStartPoint = Handles.FreeMoveHandle(StartPoint, Quaternion.identity, handleSize, Vector2.one, Handles.CubeHandleCap);
                if (newStartPoint != StartPoint)
                    UpdateStartPoint(newStartPoint);

                Handles.color = Color.white;
                Vector2 newFinishPoint = Handles.FreeMoveHandle(FinishPoint, Quaternion.identity, handleSize, Vector2.one, Handles.CubeHandleCap);
                if (newFinishPoint != FinishPoint)
                    UpdateFinishPoint(newFinishPoint);
            }
        }
    }
}