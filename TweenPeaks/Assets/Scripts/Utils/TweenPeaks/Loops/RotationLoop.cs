using UnityEngine;

namespace Assets.Scripts.Utils.TweenPeaks.Loops
{
    public class RotationLoop : MonoBehaviour
    {
        public float Speed = 45f;

        public void Update()
        {
            transform.Rotate(0f, 0f, Speed * Time.deltaTime);
        }
    }
}