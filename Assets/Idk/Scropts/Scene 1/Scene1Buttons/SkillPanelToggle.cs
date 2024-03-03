using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanelToggle : MonoBehaviour
{
    public GameObject panel;

    public void panelToggle()
    {
        panel.SetActive(!panel.activeSelf);
    }
}
