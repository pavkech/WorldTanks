using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using YG;
using ShadowResolution = UnityEngine.Rendering.Universal.ShadowResolution;


public class IngameQualitySettings : MonoBehaviour
{
    [SerializeField] Button _lowButton;
    [SerializeField] Button _midButton;
    [SerializeField] Button _highButton;
    [SerializeField] private Color32 _defaultQualityButtonColor;
    [SerializeField] private Color32 _chosenQualityButtonColor;

    private void Start()
    {
        _lowButton.onClick.AddListener(SetLowQuality);
        _midButton.onClick.AddListener(SetMidQuality);
        _highButton.onClick.AddListener(SetHighQuality);

        int qualityIndex = YG2.saves.qualityIndex;

        setupQuality(qualityIndex);
    }

    private void OnDisable()
    {
        _lowButton.onClick.RemoveAllListeners();
        _midButton.onClick.RemoveAllListeners();
        _highButton.onClick.RemoveAllListeners();
    }

    public void setupQuality(int index)
    {
        if (index == 0)
        {
            SetLowQuality();
        }
        else if (index == 1)
        {
            SetMidQuality();
        }
        else if (index == 2)
        {
            SetHighQuality();
        }
    }

    private void SetLowQuality()
    {
        YG2.saves.qualityIndex = 0;

        setupShadowDistance(0);
        MainLightShadowResolution = ShadowResolution._512;

        dropButtons();
        _lowButton.GetComponent<Image>().color = _chosenQualityButtonColor;
        QualitySettings.globalTextureMipmapLimit = 2;

        YG2.SaveProgress();
    }

    private void SetMidQuality()
    {
        YG2.saves.qualityIndex = 1;

        setupShadowDistance(30);
        MainLightShadowResolution = ShadowResolution._512;

        QualitySettings.globalTextureMipmapLimit = 1;


        dropButtons();
        _midButton.GetComponent<Image>().color = _chosenQualityButtonColor;

        YG2.SaveProgress();
    }

    private void SetHighQuality()
    {
        YG2.saves.qualityIndex = 2;

        setupShadowDistance(50);
        MainLightShadowResolution = ShadowResolution._2048;

        dropButtons();
        _highButton.GetComponent<Image>().color = _chosenQualityButtonColor;
        QualitySettings.globalTextureMipmapLimit = 0;

        YG2.SaveProgress();
    }

    private void setupShadowDistance(int value)
    {
        QualitySettings.shadowDistance = value;
        UniversalRenderPipelineAsset urp = (UniversalRenderPipelineAsset)GraphicsSettings.currentRenderPipeline;
        urp.shadowDistance = value;
    }

    private void dropButtons()
    {
        _lowButton.GetComponent<Image>().color = _defaultQualityButtonColor;
        _midButton.GetComponent<Image>().color = _defaultQualityButtonColor;
        _highButton.GetComponent<Image>().color = _defaultQualityButtonColor;
    }

    private System.Type universalRenderPipelineAssetType;
    private FieldInfo mainLightShadowmapResolutionFieldInfo;

    private void InitializeShadowMapFieldInfo()
    {
        universalRenderPipelineAssetType = (GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset).GetType();
        mainLightShadowmapResolutionFieldInfo = universalRenderPipelineAssetType.GetField("m_MainLightShadowmapResolution", BindingFlags.Instance | BindingFlags.NonPublic);
    }

    private ShadowResolution MainLightShadowResolution
    {
        get
        {
            if (mainLightShadowmapResolutionFieldInfo == null)
            {
                InitializeShadowMapFieldInfo();
            }
            return (ShadowResolution)mainLightShadowmapResolutionFieldInfo.GetValue(GraphicsSettings.currentRenderPipeline);
        }
        set
        {
            if (mainLightShadowmapResolutionFieldInfo == null)
            {
                InitializeShadowMapFieldInfo();
            }
            mainLightShadowmapResolutionFieldInfo.SetValue(GraphicsSettings.currentRenderPipeline, value);
        }
    }
}