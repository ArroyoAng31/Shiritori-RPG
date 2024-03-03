using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rules : MonoBehaviour
{
    public GameObject Panel;
    public Animator animator;

    public void OpenPanel()
    {
        animator.SetBool("IsOpen", true);
        /*if(Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
       // Panel.SetActive(!Panel.activeSelf); */
    }
   public void ClosePanel()
    {
        animator.SetBool("IsOpen", false);
    }
}
