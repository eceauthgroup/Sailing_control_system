using System;
using UnityEngine;

namespace UnityStandardAssets.Water
{
    [RequireComponent(typeof(WaterBase))]
    [ExecuteInEditMode]
    public class SpecularLighting : MonoBehaviour
    {
        public Transform specularLight;
        private WaterBase m_WaterBase;


        public void Start()
        {
            m_WaterBase = GetComponent<WaterBase>();
        }


        public void Update()
        {
            if (!m_WaterBase)
            {
                m_WaterBase = GetComponent<WaterBase>();
            }

            if (specularLight && m_WaterBase.GetSharedMaterial())
            {
                m_WaterBase.GetSharedMaterial().SetVector("_WorldLightDir", specularLight.transform.forward);
            }
        }
    }
}
