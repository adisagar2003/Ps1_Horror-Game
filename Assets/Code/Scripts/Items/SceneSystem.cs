using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private Image sceneTransitionImage;
    [SerializeField] private float fadeSpeed = 10.0f;

    // events
    public delegate void SceneShift(string sceneName, float fadeTime);
    public static event SceneShift OnSceneShift;

    private void Start()
    {
        sceneTransitionImage = GameObject.Find("SceneTransitionFade").GetComponent<Image>();
    }
    private void OnEnable()
    {
        SceneSystem.OnSceneShift += ChangeScene;
    }

    private void OnDisable()
    {
        SceneSystem.OnSceneShift -= ChangeScene;
    }

    private void ChangeScene(string sceneName, float fadeTime)
    {
        StartCoroutine(MoveToNextScene(sceneName, fadeTime));
        StartCoroutine(FadeScreenToBlack());
    }

    private IEnumerator FadeScreenToBlack()
    {
        Color color = sceneTransitionImage.color;
        sceneTransitionImage.gameObject.SetActive(true);
        while (color.a < 1f)
        {
            color.a += fadeSpeed * Time.deltaTime;
            color.a = Mathf.Clamp01(color.a);
            sceneTransitionImage.color = color;
            yield return null;
        }
    }

    private IEnumerator MoveToNextScene(string sceneName, float fadeTime)
    {
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(sceneName);
    }

    public static void Trigger(string sceneName, float fadeTime)
    {
        OnSceneShift?.Invoke(sceneName, fadeTime);
    }
}
