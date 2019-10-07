using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour
{
    public GameObject settingsPanel;

    private void Start()
    {
        settingsPanel.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenSettings()
    {
        // 설정창 열기
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        // 설정창 닫기
        settingsPanel.SetActive(false);
    }
}
