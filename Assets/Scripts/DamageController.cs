using UnityEngine;
using UnityEngine.PostProcessing;

public class DamageController : MonoBehaviour {

    #region Variables

    [SerializeField] PostProcessingProfile postProcessingProfile;
    [SerializeField] DamageStatesSettings damageStatesSettings;

    DamageState tempDamageState;

    int damageStateIndex = 0;

    float t = 0;

    #endregion


    #region Unity lifecycle

    // Use this for initialization
    void Start () {
        EnablePostProcess(false);
        tempDamageState = new DamageState();
    }
	
	// Update is called once per frame
	void Update () {
        if (damageStateIndex > 0)
        {
            LerpValues();
            UpdatePostProcessValues();
        }

    }

    #endregion


    #region Public methods

    public void SetIndexOfDamage(int index)
    {
        if (index < 1 && index >= damageStatesSettings.DamageStates.Count)
        {
            throw new System.ArgumentOutOfRangeException("Incorrect index");
        }

        t = 0;

        damageStateIndex = index;
    }

    private void EnablePostProcess(bool enable)
    {
        postProcessingProfile.depthOfField.enabled = enable;
        postProcessingProfile.motionBlur.enabled = enable;
        postProcessingProfile.vignette.enabled = enable;
    }

    private void LerpValues()
    {
        if(damageStateIndex >= 1)
        {
            EnablePostProcess(true);
        }

        var currentDamageState = damageStatesSettings.DamageStates[damageStateIndex];
        var previousDamageState = damageStatesSettings.DamageStates[damageStateIndex - 1];

        t += Time.deltaTime / currentDamageState.Duration;
        
        var focusDistance = Mathf.Lerp(currentDamageState.FocusDistance, previousDamageState.FocusDistance, t);
        var frameBlending = Mathf.Lerp(currentDamageState.FrameBlending, previousDamageState.FrameBlending, t);
        var vignetteIntenity = Mathf.Lerp(currentDamageState.VignetteIntensity, previousDamageState.VignetteIntensity, t);

        tempDamageState.SetFocusDistance(focusDistance);
        tempDamageState.SetFrameBlending(frameBlending);
        tempDamageState.SetVignetteIntensity(vignetteIntenity);

        if (t >= 1)
        {
            t = 0;
            damageStateIndex--;
        }

        if (damageStateIndex < 1)
        {
            EnablePostProcess(false);
        }

        Debug.LogWarning(damageStateIndex);
    }

    private void UpdatePostProcessValues()
    {
        var depthOfFieldSettings = postProcessingProfile.depthOfField.settings;
        depthOfFieldSettings.focusDistance = tempDamageState.FocusDistance;
        postProcessingProfile.depthOfField.settings = depthOfFieldSettings;

        var motionBlur = postProcessingProfile.motionBlur.settings;
        motionBlur.frameBlending = tempDamageState.FrameBlending;
        postProcessingProfile.motionBlur.settings = motionBlur;

        var vignette = postProcessingProfile.vignette.settings;
        vignette.intensity = tempDamageState.VignetteIntensity;
        postProcessingProfile.vignette.settings = vignette;
    }

    private void OnDestroy()
    {
        EnablePostProcess(false);
    }

    #endregion
}
