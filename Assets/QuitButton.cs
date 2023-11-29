using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    public float timer = 0;
    public bool startTimer = false;
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Click()
    {
        audioSource.Play();
        startTimer = true;
    }

    private void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
        }
        if (timer > 0.5f)
        {
            Application.Quit();
        }
    }
}
