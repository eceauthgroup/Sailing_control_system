using System;
using UnityEngine;

namespace UnityStandardAssets.Water
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(WaterBase))]
    public class GerstnerDisplace : Displace
    {
        public float Amplitude { get; set; }
        public Vector3 WaveDirection { get; set; }
    }
}
