using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualcam;
    [SerializeField] private CameraShakeScriptableObject cameraShakeSO;

    private float currentFrequencyGain;
    private float currentAmplitudeGain;
    private CinemachineBasicMultiChannelPerlin camNoise;

    private void Awake()
    {
        currentFrequencyGain = cameraShakeSO.DefaultFrequencyGain;
        currentAmplitudeGain = cameraShakeSO.DefaultAmplitudeGain;
        camNoise = virtualcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Start()
    {
        GameService.Instance.EventService.OnBattleEventOccurred += InitiateBattleEventCameraShake;
    }
    private void Update()
    {
        UpdateCamera(currentFrequencyGain, currentAmplitudeGain);
    }
    private void OnDestroy()
    {
        GameService.Instance.EventService.OnBattleEventOccurred -= InitiateBattleEventCameraShake;
    }

    private void UpdateCamera(float frequencyGain, float amplitudeGain)
    {
        camNoise.m_FrequencyGain = frequencyGain;
        camNoise.m_AmplitudeGain = amplitudeGain;
    }
    private void InitiateBattleEventCameraShake(BattleEventType battleEvent)
    {
        float cameraShakeTime;
        switch (battleEvent)
        {
            case BattleEventType.TankShellFired:
                currentAmplitudeGain = cameraShakeSO.TankShellFiredAmplitudeGain;
                currentFrequencyGain = cameraShakeSO.TankShellFiredFrequencyGain;
                cameraShakeTime = cameraShakeSO.TankShellFiredShakeTime;
                break;

            case BattleEventType.ShellExplosion:
                currentAmplitudeGain = cameraShakeSO.ExplosionAmplitudeGain;
                currentFrequencyGain = cameraShakeSO.ExplosionFrequencyGain;
                cameraShakeTime = cameraShakeSO.ExplosionShakeTime;
                break;
            default:
                cameraShakeTime = 0.0f;
                break;
        }
        StartCoroutine(CameraShakeCoroutine(cameraShakeTime));
    }

    private IEnumerator CameraShakeCoroutine(float cameraShakeTime)
    {
        float currentShakeTime = cameraShakeTime;

        while (currentShakeTime >= 0.0f)
        {
            currentShakeTime -= Time.deltaTime;
            yield return null;
        }
        currentAmplitudeGain = cameraShakeSO.DefaultAmplitudeGain;
        currentFrequencyGain = cameraShakeSO.DefaultFrequencyGain;
    }
}
