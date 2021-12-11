using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScreen : MonoBehaviour
{
    public static FadeScreen instance;
    private Animator _anim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);

        _anim = GetComponent<Animator>();
    }

    public void FadeToScene(int sceneIndex)
    {
        _anim.enabled = true;
        StartCoroutine(AnimateSceneLoad(sceneIndex));
    }
    public void FadeInScreen()
    {
        _anim.Play("FadeInScreen");
    }

    public void FadeOutScreen()
    {
        _anim.Play("FadeOutScreen");
    }

    IEnumerator AnimateSceneLoad(int sceneIndex)
    {
        Time.timeScale = 1;
        FadeOutScreen();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneIndex);
        FadeInScreen();
    }
}
