using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
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
            SceneManager.LoadScene("Level_0");
        }
    }
}
