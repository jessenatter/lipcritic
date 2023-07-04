using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Screenshake : MonoBehaviour
{
    public static Screenshake Instance { get; private set; }
    public float shakeTimer;
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void shake(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
        }
        if (shakeTimer <= 0)
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
        }
    }


}
