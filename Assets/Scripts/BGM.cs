using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]

public class BGM : MonoBehaviour
{
    public AudioClip regularBGM;
    public AudioClip storySeven;
    public AudioClip endOne;
    public AudioClip endTwo;
    private AudioSource source;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        switch (SceneManager.GetActiveScene().name)
        {
            case "Story_7":
                source.clip = storySeven;
                if(!source.isPlaying)
                    source.Play();
                break;
            case "End_1_leave":
                source.clip = endOne;
                if (!source.isPlaying)
                    source.Play();
                break;
            case "End_2_awake":
                source.clip = endTwo;
                if (!source.isPlaying)
                    source.Play();
                break;
            default:
                source.clip = regularBGM;
                if (!source.isPlaying)
                    source.Play();
                break;
        }
    }
}
