using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraShake", menuName = "ScriptableObjects/NewCameraShake")]
public class CameraShakeScriptableObject : ScriptableObject
{
    [Header("DEFAULT CAMERA SHAKE VALUES")]
    public float DefaultAmplitudeGain;
    public float DefaultFrequencyGain;

    [Header("TANK SHELL FIRED CAMERA SHAKE VALUES")]
    public float TankShellFiredAmplitudeGain;
    public float TankShellFiredFrequencyGain;
    public float TankShellFiredShakeTime;

    [Header("EXPLOSION CAMERA SHAKE VALUES")]
    public float ExplosionAmplitudeGain;
    public float ExplosionFrequencyGain;
    public float ExplosionShakeTime;
}
