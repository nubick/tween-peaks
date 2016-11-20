using Assets.Scripts.Utils.TweenPeaks.Loops;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Utils.TweenPeaks.Editor
{
    [CustomEditor(typeof(MoveLoop))]
    public class MoveLoopEditor : UnityEditor.Editor
    {
        private MoveLoop _moveLoop;

        public void OnEnable()
        {
            _moveLoop = target as MoveLoop;
        }

        public void OnSceneGUI()
        {
            Vector3 targetPosition = _moveLoop.transform.position + _moveLoop.Offset;
            Handles.DrawLine(_moveLoop.transform.position, targetPosition);

            Vector3 newTargetPosition = Handles.FreeMoveHandle(targetPosition, Quaternion.identity, HandleUtility.GetHandleSize(targetPosition)*0.1f, Vector3.one, Handles.CubeCap);
            _moveLoop.Offset = newTargetPosition - _moveLoop.transform.position;
        }
    }
}
