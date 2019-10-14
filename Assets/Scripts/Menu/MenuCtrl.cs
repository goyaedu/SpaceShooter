using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour
{
    public GameObject settingsPanel;

    AudioSource audioSource;
    Coroutine settingsCoroutine;

    private void Start()
    {
        settingsPanel.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);

        if (settingsCoroutine != null) StopCoroutine(settingsCoroutine);
        settingsCoroutine = StartCoroutine(openAndCloseSettings(true, 1));
    }

    public void CloseSettings()
    {

        if (settingsCoroutine != null) StopCoroutine(settingsCoroutine);
        settingsCoroutine = StartCoroutine(openAndCloseSettings(false, 1, () =>
        {
            settingsPanel.SetActive(false);
        }));
    }

    // Switch를 위한 함수
    public void SwitchIsOn(bool isOn)
    {
        if (isOn == true)
            audioSource.Play();
        else
            audioSource.Pause();
    }

    IEnumerator openAndCloseSettings(bool isOpen, float duration, Action callback = null)
    {
        CanvasGroup canvasGroup = settingsPanel.GetComponent<CanvasGroup>();
        float currentTime = 0;

        while (currentTime < duration)
        {
            if (isOpen)
                canvasGroup.alpha = Mathf.Lerp(0, 1, currentTime / duration);
            else
                canvasGroup.alpha = Mathf.Lerp(1, 0, currentTime / duration);

            currentTime += Time.deltaTime;
            yield return null;
        }
        callback.Invoke();
    }
}
