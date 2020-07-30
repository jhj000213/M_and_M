using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateMng : MonoBehaviour {

    private static StateMng instance = null;

    public static StateMng Data
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(StateMng)) as StateMng;
                if (instance == null)
                {
                    Debug.Log("no instance");
                }
            }
            return instance;
        }
    }

    public bool _SoundOn;

    public GameObject _Root;
    public GameObject _FadeIn;

    public float _NowCarUser;
    public float _MaxCarUser;
    public float _CarUserIncrease;

    public int _Populations;

    public int _GoldValue;
    public float _NowGoldGaze;
    public float _MaxGoldGaze;
    public float _GoldGazeSpeed;
    public int _MiniGamePoint;
    public int _GiveGold;

    public int _Years;
    public float _NowYearsGaze;
    public float _MaxYearsGaze;
    public float _YearsGazeSpeed;

    public bool _GameOver;

    public GameObject _GameOverPrefab;

    public float _Accelerator;
    bool _restart = false;

    void Start()
    {
        _SoundOn = true;
        _CarUserIncrease = 1.0f;
        _NowCarUser = 0.0f;
        _MaxCarUser = 200;

        _Populations = 1000;
        _GoldValue = 0;
        _GiveGold = 500;
        _Years = 2000;
        _YearsGazeSpeed = 250.0f / 20.0f;
        _MaxYearsGaze = 250.0f;
        _MaxGoldGaze = 100.0f;
    }

    void Update()
    {
        _Accelerator = 1.0f;
        if(Input.GetKey(KeyCode.Space))
        {
            _Accelerator = 5.0f;
        }

        if (!_GameOver)
        {
            _CarUserIncrease = _MaxCarUser / 100.0f;
            _MaxCarUser = _Populations / 5.0f;
            _NowCarUser -= Time.smoothDeltaTime * _CarUserIncrease * _Accelerator;
            if (_NowCarUser <= 0.0f)
                _NowCarUser = 0.0f;


            _NowYearsGaze += Time.smoothDeltaTime * _YearsGazeSpeed * _Accelerator;
            if (_NowYearsGaze >= 250.0f)
            {
                _NowYearsGaze -= 250.0f;
                _Years++;
                NextYear();
                GiveGold();
            }

            if (_NowCarUser >= _MaxCarUser)
            {
                _GameOver = true;
                _GameOverPrefab.SetActive(true);
            }
        }

    }

    void GiveGold()
    {
        int GiveGold = _GiveGold;
        float value = (float)_MiniGamePoint / 20000.0f;
        value += 0.5f;
        GiveGold = (int)(GiveGold * value);
        _GoldValue += GiveGold;
        _MiniGamePoint = 0;
        _GiveGold = (int)(_GiveGold * 1.1f);
    }

    void NextYear()
    {
        _Populations = (int)((float)_Populations * 1.2f);
    }

    public void Restart()
    {
        if(!_restart)
        {
            _restart = true;
            GameObject obj = NGUITools.AddChild(_Root, _FadeIn);
            StartCoroutine(SceneChange(1.5f));
        }
        
    }

    IEnumerator SceneChange(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("GameScene");
    }

}
