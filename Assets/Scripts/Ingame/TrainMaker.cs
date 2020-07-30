using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMaker : MonoBehaviour {

    float _NowTime_First;
    float _NowTime_Second;
    float _NowTime_Third;
    float _NowTime_Fourth;

    float _MakeDelayTime;

    public GameObject _Train;
    public GameObject _TrainRoot;

    float _LineDifferenceValue;


    void Start ()
    {
        _MakeDelayTime = 4.0f;
        _NowTime_First = _MakeDelayTime;
        _NowTime_Second = _MakeDelayTime;
        _NowTime_Third = _MakeDelayTime;
        _NowTime_Fourth = _MakeDelayTime;
    }
	
	void Update ()
    {
        _NowTime_First += Time.smoothDeltaTime * StateMng.Data._Accelerator;
        _NowTime_Second += Time.smoothDeltaTime * StateMng.Data._Accelerator;
        _NowTime_Third += Time.smoothDeltaTime * StateMng.Data._Accelerator;
        _NowTime_Fourth += Time.smoothDeltaTime * StateMng.Data._Accelerator;

        if(_NowTime_First>=_MakeDelayTime)
        {
            _LineDifferenceValue = 2;
            _NowTime_First -= _MakeDelayTime;
            MakeTrain(1);
        }
        if (_NowTime_Second >= _MakeDelayTime)
        {
            _LineDifferenceValue = 2;
            _NowTime_Second -= _MakeDelayTime;
            MakeTrain(2);
        }
        if (_NowTime_Third >= _MakeDelayTime)
        {
            _LineDifferenceValue = 2;
            _NowTime_Third -= _MakeDelayTime;
            MakeTrain(3);
        }
        if (_NowTime_Fourth >= _MakeDelayTime)
        {
            _LineDifferenceValue = 0.7f;
            _NowTime_Fourth -= _MakeDelayTime;
            MakeTrain(4);
        }
    }

    void MakeTrain(int linenumber)
    {


        GameObject train = NGUITools.AddChild(_TrainRoot, _Train);
        train.GetComponent<Train>().Init(linenumber,true,(int)(StateMng.Data._Populations/10.0f * _LineDifferenceValue));

        GameObject train1 = NGUITools.AddChild(_TrainRoot, _Train);
        train1.GetComponent<Train>().Init(linenumber,false, (int)(StateMng.Data._Populations / 10.0f * _LineDifferenceValue));
    }
}
