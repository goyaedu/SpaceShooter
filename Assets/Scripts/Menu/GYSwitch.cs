using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GYSwitch : MonoBehaviour
{
    public RectTransform handleRectTransform;
    public MenuCtrl menuCtrl;

    bool isOn;      // True: On, False: Off

    private void Start()
    {
        isOn = false;
        handleRectTransform.anchoredPosition = new Vector2(-13, 0);
    }

    public void OnClickSwitch()
    {
        if (isOn == false)
        {
            isOn = true;
            handleRectTransform.anchoredPosition = new Vector2(13, 0);
        }
        else
        {
            isOn = false;
            handleRectTransform.anchoredPosition = new Vector2(-13, 0);
        }
        menuCtrl.SwitchIsOn(isOn);
    }
}
