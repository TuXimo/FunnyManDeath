using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void SetNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void PauseGame ()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame ()
    {
        Time.timeScale = 1;
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }


    [SerializeField] private AudioMixer _audioMixer;
    
    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat("volume", volume);
    }
}
