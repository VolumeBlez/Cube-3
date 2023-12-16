using UnityEngine;

public class SceneRenderSettings : MonoBehaviour
{
    [Header("Fog Properties")]
    [SerializeField] private GameObject _bg;
    [SerializeField] private Color _lightFogColor;
    [SerializeField] private float _lightFogIntensity;
    [SerializeField] private Color _darkFogColor;
    [SerializeField] private float _darkForIntensity;

    [Header("Day Properties")]
    [SerializeField] private Material _daySkybox;
    [SerializeField] private GameObject _sun;

    [Header("Night Properties")]
    [SerializeField] private Material _nightSkybox;
    [SerializeField] private GameObject _moon;

    public void ClearSky()
    {
        _bg.SetActive(false);
        RenderSettings.fog = false;
    }

    public void DarkFog()
    {
        _bg.SetActive(true);
        RenderSettings.fog = true;
        RenderSettings.fogColor = _darkFogColor;
        RenderSettings.fogDensity = _darkForIntensity;
    }

    public void LightFog()
    {
        _bg.SetActive(true);
        RenderSettings.fog = true;
        RenderSettings.fogColor = _lightFogColor;
        RenderSettings.fogDensity = _lightFogIntensity;
    }

    public void SetDay()
    {
        RenderSettings.skybox = _daySkybox;
        RenderSettings.ambientIntensity = 1;
        _moon.SetActive(false);
        _sun.SetActive(true);
    }

    public void SetNight()
    {
        RenderSettings.skybox = _nightSkybox;
        RenderSettings.ambientIntensity = 0.3f;
        _moon.SetActive(true);
        _sun.SetActive(false);
    }

}
