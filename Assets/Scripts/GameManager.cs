using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject clearText;
    [SerializeField] AudioClip goalSound;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void GameOver()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GameClear()
    {
        audioSource.PlayOneShot(goalSound);
        clearText.SetActive(true);
    }
}
