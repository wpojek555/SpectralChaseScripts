using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject settingsUI;
    [SerializeField] private AudioSource music;

    public AsyncSceneManager sceneManager;

    private void Start()
    {
        sceneManager = GameObject.FindFirstObjectByType<AsyncSceneManager>().GetComponent<AsyncSceneManager>();
    }
    public void PlayClickEvent()
    {
        sceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        music.Stop();
    }
    public void MenuClickEvent()
    {
        menuUI.SetActive(true);
        settingsUI.SetActive(false);
    }
    public void SettingClickEvent()
    {
        menuUI.SetActive(false);
        settingsUI.SetActive(true);
    }
    public void QuitClickEvent()
    {
        Application.Quit();
    }
}
