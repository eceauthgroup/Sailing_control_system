using UnityEngine;

namespace UnityStandardAssets.Water
{
    public class WaterWaveController : MonoBehaviour
    {
        public WindController windController;
        public GerstnerDisplace gerstnerDisplace;

        [SerializeField]
        private Vector2 waveDirection;

        public Vector2 WaveDirection
        {
            get { return waveDirection; }
            set { waveDirection = value; }
        }

        private void Update()
        {
            if (windController != null && gerstnerDisplace != null)
            {
                Quaternion windRotation = WindController.WindRotation;
                Vector2 waveDirection = new Vector2(windRotation.eulerAngles.x, windRotation.eulerAngles.y);
                gerstnerDisplace.WaveDirection = waveDirection;
            }
        }
    }
}


