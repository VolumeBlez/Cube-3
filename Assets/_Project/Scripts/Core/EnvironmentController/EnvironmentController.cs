using System;
using UnityEngine;

namespace VB
{
    [Serializable]
    public struct FogProperties
    {
        public Color Color;
        public float Intensity;
    }

    [RequireComponent(typeof(RenderSettings))]
    public class EnvironmentController : MonoBehaviour
    {
        [Header("Background Settings")]
        [SerializeField] private GameObject _backgroundObject;
        [SerializeField] private FogProperties _lightFog;
        [SerializeField] private FogProperties _darkFog;

        [Header("Skybox Settings")]
        [SerializeField] private Material _daySkybox;
        [SerializeField] private GameObject _sunObject;

        [Header("Night Settings")]
        [SerializeField] private Material _nightSkybox;
        [SerializeField] private GameObject _moonObject;

        public void ClearSky()
        {
            _backgroundObject.SetActive(false);
            DisableFog();
        }

        public void EnableDarkFog()
        {
            _backgroundObject.SetActive(true);
            EnableFog(_darkFog.Color, _darkFog.Intensity);
        }

        public void EnableLightFog()
        {
            _backgroundObject.SetActive(true);
            EnableFog(_lightFog.Color, _lightFog.Intensity);
        }

        public void SetDayMode()
        {
            RenderSettings.skybox = _daySkybox;
            RenderSettings.ambientIntensity = 1f;
            _moonObject.SetActive(false);
            _sunObject.SetActive(true);
        }

        public void SetNightMode()
        {
            RenderSettings.skybox = _nightSkybox;
            RenderSettings.ambientIntensity = 0.3f;
            _moonObject.SetActive(true);
            _sunObject.SetActive(false);
        }

        private void EnableFog(Color fogColor, float fogDensity)
        {
            RenderSettings.fog = true;
            RenderSettings.fogColor = fogColor;
            RenderSettings.fogDensity = fogDensity;
        }

        private void DisableFog()
        {
            RenderSettings.fog = false;
        }
    }
}
