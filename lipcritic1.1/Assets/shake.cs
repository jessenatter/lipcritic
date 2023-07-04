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

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 10f; //change this number for intennsity
        duration = time;

        StartCoroutine(Shaking());
    }
    IEnumerator Shaking()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            Debug.Log("shaking");
            elapsedTime += Time.deltaTime;
            yield return null;

        }

        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
    }




}
