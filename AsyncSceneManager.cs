using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject loadingScreenUI;

    [SerializeField] private Slider slider;

    [SerializeField] private AudioSource music;

    private void Start()
    {
        music = GetComponent<AudioSource>();
    }
    public void LoadScene(int sceneToLoad)
    {
        menuUI.SetActive(false);
        loadingScreenUI.SetActive(true);
        music.Play();

        StartCoroutine(loadLevelASync(sceneToLoad));

    }
    IEnumerator loadLevelASync(int sceneToLoad)
    {
        yield return new WaitForSecondsRealtime(10);
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(sceneToLoad);
        
        if (!loadScene.isDone) 
        {
            float progressValue = Mathf.Clamp01(loadScene.progress / 0.9f);
            slider.value = progressValue;
            yield return null;
        }
    }
}
