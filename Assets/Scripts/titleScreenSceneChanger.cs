using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(AudioSource))]
public class titleScreenSceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeUntilSceneChange = 0f;
    public bool startTimer;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void LoadScene(string Level_0)
    {
        audioSource.Play();
        startTimer = true;
    }

    public void Quit()
    {
        Application.Quit();
        
    }

    private void Update()
    {
        if (startTimer)
        {
            timeUntilSceneChange += Time.deltaTime;
            if(timeUntilSceneChange > 0.8f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
