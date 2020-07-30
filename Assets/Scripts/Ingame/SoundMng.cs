using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMng : MonoBehaviour {

    public AudioSource _source;

    void Update()
    {
        if (StateMng.Data._SoundOn)
            _source.volume = 1;
        else
            _source.volume = 0;
    }
}
