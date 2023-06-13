using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndMenu : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    public void ClickOn()
    {
        clickSound.Play();
        Invoke("Quit", 1f);
    }
    private void Quit()
    {
        Application.Quit();
    }
}
