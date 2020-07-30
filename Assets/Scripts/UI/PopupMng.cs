using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupMng : MonoBehaviour {

    public GameObject _PopupLayer_MiniGame;
    
    public GameObject _PopupLayer_Option;
    public UISprite _SoundButton;


    public AudioClip _Audio;

    public void OpenLayer(GameObject layer)
    {
        if (StateMng.Data._SoundOn)
            AudioSource.PlayClipAtPoint(_Audio, Vector2.zero, 1);
        layer.transform.parent.gameObject.SetActive(true);
        layer.GetComponent<Animator>().SetTrigger("open");
    }

    public void CloseLayer(GameObject layer)
    {
        if (StateMng.Data._SoundOn)
            AudioSource.PlayClipAtPoint(_Audio, Vector2.zero, 1);
        layer.GetComponent<Animator>().SetTrigger("close");
        StartCoroutine(CloseLayer_C(0.5f, layer.transform.parent.gameObject));
    }

    IEnumerator CloseLayer_C(float time,GameObject obj)
    {
        yield return new WaitForSeconds(time);

        obj.SetActive(false);
    }

    public void OpenMiniGame()
    {
        if (StateMng.Data._SoundOn)
            AudioSource.PlayClipAtPoint(_Audio, Vector2.zero, 1);
        _PopupLayer_MiniGame.SetActive(true);
    }

    public void CloseMiniGame()
    {
        if (StateMng.Data._SoundOn)
            AudioSource.PlayClipAtPoint(_Audio, Vector2.zero, 1);
        _PopupLayer_MiniGame.SetActive(false);
    }

    public void SoundButtonHit()
    {
        if (StateMng.Data._SoundOn)
            AudioSource.PlayClipAtPoint(_Audio, Vector2.zero, 1);
        if (_SoundButton.spriteName == "soundon")
            _SoundButton.spriteName = "soundoff";
        else
            _SoundButton.spriteName = "soundon";
        StateMng.Data._SoundOn = !StateMng.Data._SoundOn;
    }

    public void OpenOption()
    {
        if (StateMng.Data._SoundOn)
            AudioSource.PlayClipAtPoint(_Audio, Vector2.zero, 1);
        _PopupLayer_Option.SetActive(true);
    }

    public void CloseOption()
    {
        if (StateMng.Data._SoundOn)
            AudioSource.PlayClipAtPoint(_Audio, Vector2.zero, 1);
        _PopupLayer_Option.SetActive(false);
    }
}
