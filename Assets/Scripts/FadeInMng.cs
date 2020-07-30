using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FadeInMng : MonoBehaviour {

    public float _DelayTime;

    public GameObject _Root;
    public GameObject _FadeIn;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(_DelayTime);

        GameObject obj = NGUITools.AddChild(_Root, _FadeIn);
        StartCoroutine(SceneChange(1.5f));
    }

    IEnumerator SceneChange(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("GameScene");
    }
}
