using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {

    public int _InPeopleValue;

    public int _LineNumber;
    public UI2DSprite _OutSprite;
    public Color[] _OutColor = new Color[4];
    public UILabel _LineNumberLabel;
    public UILabel _InPeopleValueLabel;


    public AudioClip _Audio;

    List<GameObject> _MovePositonList;
    Vector3 _NowDestinationPos;
    int _NowPositionListNum;
    int _NowPositionListNumIncrease;

    public List<GameObject> _LandMarkPositonList;
    //Vector3 _NowNextLandMarkPos;
    public int _LandMarkPositonListNum;
    public int _LandMarkPositonListNumIncrease;

    public bool _LandCheck;
    float _MoveSpeed;

    bool _LabelAlpha;

    
	void Start ()
    {

	}

    public void Init(int linenumber,bool forward,int inpopulation)
    {
        _LandCheck = true;
        _LineNumber = linenumber;
        _MoveSpeed = 100.0f;
        _InPeopleValue = inpopulation;
        _LineNumberLabel.text = linenumber.ToString();
        
        if (_LineNumber == 1)
        {
            _MovePositonList = MapInfo.Data._Line_First_Position;
            _LandMarkPositonList = MapInfo.Data._LandMark_First_Position;
            _OutSprite.color = _OutColor[0];
            _InPeopleValueLabel.color = _OutColor[0];
        }
        else if (_LineNumber == 2)
        {
            _MovePositonList = MapInfo.Data._Line_Second_Position;
            _LandMarkPositonList = MapInfo.Data._LandMark_Second_Position;
            _OutSprite.color = _OutColor[1];
            _InPeopleValueLabel.color = _OutColor[1];
        }
        else if (_LineNumber == 3)
        {
            _MovePositonList = MapInfo.Data._Line_Third_Position;
            _LandMarkPositonList = MapInfo.Data._LandMark_Third_Position;
            _OutSprite.color = _OutColor[2];
            _InPeopleValueLabel.color = _OutColor[2];
        }
        else if (_LineNumber == 4)
        {
            _MovePositonList = MapInfo.Data._Line_Fourth_Position;
            _LandMarkPositonList = MapInfo.Data._LandMark_Fourth_Position;
            _OutSprite.color = _OutColor[3];
            _InPeopleValueLabel.color = _OutColor[3];
        }

        if (forward)
        {
            _NowPositionListNum = 0;
            _NowPositionListNumIncrease = 1;
            _LandMarkPositonListNum = 0;
            _LandMarkPositonListNumIncrease = 1;
        }
        else
        {
            _NowPositionListNum = _MovePositonList.Count-1;
            _NowPositionListNumIncrease = -1;
            _LandMarkPositonListNum = _LandMarkPositonList.Count-1;
            _LandMarkPositonListNumIncrease = -1;
        }

        transform.localPosition = _MovePositonList[_NowPositionListNum].transform.localPosition;
        _NowPositionListNum+=_NowPositionListNumIncrease;
        _NowDestinationPos = _MovePositonList[_NowPositionListNum].transform.localPosition;
        //_NowNextLandMarkPos = _LandMarkPositonList[_LandMarkPositonListNum].transform.localPosition;
    }

    internal void Init(int linenumber, bool v1, float v2)
    {
        throw new NotImplementedException();
    }

    void Update ()
    {
        MoveNextPositon();
        _InPeopleValueLabel.text = _InPeopleValue.ToString();
        if (_InPeopleValue <= 0 && !_LabelAlpha)
        {
            _LabelAlpha = true;
            _InPeopleValueLabel.GetComponent<Animator>().SetTrigger("des");
        }
	}

    void MoveNextPositon()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, _NowDestinationPos, Time.smoothDeltaTime * _MoveSpeed * StateMng.Data._Accelerator);
        if(Vector3.Distance(transform.localPosition,_NowDestinationPos)<2.0f)
        {
            _NowPositionListNum+=_NowPositionListNumIncrease;
            if(_NowPositionListNumIncrease==1)
            {
                if (_NowPositionListNum >= _MovePositonList.Count)
                    RemoveSelf();
                else
                    _NowDestinationPos = _MovePositonList[_NowPositionListNum].transform.localPosition;
            }
            else
            {
                if (_NowPositionListNum < 0)
                    RemoveSelf();
                else
                    _NowDestinationPos = _MovePositonList[_NowPositionListNum].transform.localPosition;
            }
        }


        if(_LandCheck)
        {
            if (Vector3.Distance(transform.localPosition, _LandMarkPositonList[_LandMarkPositonListNum].transform.localPosition) < 20.0f)
            {
                LandMark obj = _LandMarkPositonList[_LandMarkPositonListNum].GetComponent<LandMark>();
                CheckLandMark(obj);
                _LandMarkPositonListNum += _LandMarkPositonListNumIncrease;

                if (_LandMarkPositonListNumIncrease == 1 && _LandMarkPositonListNum >= _LandMarkPositonList.Count)
                    _LandCheck = false;
                else if (_LandMarkPositonListNumIncrease == -1 && _LandMarkPositonListNum < 0)
                    _LandCheck = false;
            }
        }
    }
    void RemoveSelf()
    {
        StateMng.Data._NowCarUser += _InPeopleValue;
        Destroy(gameObject);
    }

    void CheckLandMark(LandMark obj)
    {
        if (StateMng.Data._SoundOn)
            AudioSource.PlayClipAtPoint(_Audio, Vector2.zero, 1);
        _InPeopleValue -= obj._MinusPopulation;
        if (_InPeopleValue <= 0.0f)
            _InPeopleValue = 0;
    }
}
