using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class shake : MonoBehaviour
{
    public static shake Instance { get; private set; }
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    public float duration = 1f;

    void Start()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void StartShake(float time)
    {
        

        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 1f; //change this number for intennsity
        duration = time;

        StartCoroutine(Shaking());
    }
    IEnumerator Shaking()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;

            yield return null;

        }

    }




}
