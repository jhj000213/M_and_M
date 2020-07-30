using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameNode : MonoBehaviour {

    public int _VectorNum;

    public UISprite _LeftImage;
    public UISprite _RightImage;

    bool _Moving;
    Vector3 _TargetPos;
    

    public void Init(int vnum)
    {
        _VectorNum = vnum;
        if (_VectorNum == 0)
        {
            _LeftImage.spriteName = "node_on";
        }
        else
        {
            _RightImage.spriteName = "node_on";
        }
    }

    void Update()
    {
        if (_Moving)
            transform.localPosition = Vector3.Lerp(transform.localPosition, _TargetPos, Time.smoothDeltaTime * 20 * StateMng.Data._Accelerator);
    }

    public void MoveDown()
    {
        //transform.localPosition -= new Vector3(0, 170, 0);
        //transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition - new Vector3(0, 170, 0), Time.smoothDeltaTime * 50);
        _Moving = true;
        _TargetPos = transform.localPosition - new Vector3(0, 130, 0);
    }
}
