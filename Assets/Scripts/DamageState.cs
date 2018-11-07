using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DamageState
{
    #region Variables

    [Header("Depth of field settings")]
    [Range(0.1f, 10f)]
    [SerializeField] float focusDistance;

    [Header("Motion blur settings")]
    [Range(0,1f)]
    [SerializeField] float frameBlending;

    [Header("Vignette settings")]
    [Range(0,0.4f)]
    [SerializeField] float vignetteIntensity;

    [Header("Duration")]
    [SerializeField] float durationInSeconds;

    #endregion


    #region Properties

    public float FocusDistance => focusDistance;

    public float FrameBlending => frameBlending;

    public float VignetteIntensity => vignetteIntensity;

    public float Duration => durationInSeconds;

    #endregion


    #region Setters

    public void SetFocusDistance(float focusDistance)
    {
        this.focusDistance = focusDistance;
    }

    public void SetFrameBlending(float frameBlending)
    {
        this.frameBlending = frameBlending;
    }

    public void SetVignetteIntensity(float vignetteIntensity)
    {
        this.vignetteIntensity = vignetteIntensity;
    }

    #endregion
}

