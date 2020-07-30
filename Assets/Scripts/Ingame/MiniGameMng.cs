using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MiniGameMng : MonoBehaviour {

    public Animator _CameraAnimator;

    public GameObject _BlockGrid;
    public GameObject _BlockObject;

    public UI2DSprite _PointGaze;

    public bool _CanPlaying;

    public List<int> _BlockList = new List<int>();
    public List<MiniGameNode> _BlockList_Obj = new List<MiniGameNode>();
    int _MaxBlockList = 7;

    public AudioClip _Audio1;
    public AudioClip _Audio2;


    void Start()
    {
        _CanPlaying = true;
        for (int i = 0; i < _MaxBlockList; i++)
        {
            CreateBlock();
        }
    }

    void Update()
    {
        _PointGaze.fillAmount = StateMng.Data._MiniGamePoint / 20000.0f;
        _BlockList_Obj[0].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CrashBlock(0);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            CrashBlock(1);
        }
    }

    void CrashBlock(int num)
    {
        Destroy(_BlockList_Obj[0].gameObject);
        _BlockList_Obj.RemoveAt(0);
        for (int i = 0; i < _BlockList_Obj.Count; i++)
        {
            _BlockList_Obj[i].MoveDown();
        }
        //_BlockGrid.hideInactive = !_BlockGrid.hideInactive;
        if (num == _BlockList[0])
            HitBlock(num);
        else
            WrongBlock( num);
        _BlockList.RemoveAt(0);
        CreateBlock();
    }

    void CreateBlock()
    {
        int num = Random.Range(0, 2);
        _BlockList.Add(num);

        GameObject obj = NGUITools.AddChild(_BlockGrid, _BlockObject);
        
        obj.GetComponent<MiniGameNode>().Init(num);
        _BlockList_Obj.Add(obj.GetComponent<MiniGameNode>());
        obj.transform.localPosition = new Vector3(0, (_BlockList_Obj.Count - 1) * 130, 0);
        //_BlockGrid.hideInactive = !_BlockGrid.hideInactive;

    }



    void HitBlock(int num)
    {
        StateMng.Data._MiniGamePoint += 250;
        if (StateMng.Data._SoundOn)
            AudioSource.PlayClipAtPoint(_Audio1, Vector2.zero, 1);
    }
    void WrongBlock(int num)
    {
        if (StateMng.Data._SoundOn)
            AudioSource.PlayClipAtPoint(_Audio2, Vector2.zero, 1);
        _CameraAnimator.SetTrigger("shake");
        StateMng.Data._MiniGamePoint -= 500;
        if (StateMng.Data._MiniGamePoint <= 0.0f)
            StateMng.Data._MiniGamePoint = 0;

    }

    public void PressLeft()
    {
        CrashBlock(0);
    }

    public void PressRight()
    {
        CrashBlock(1);
    }
}
