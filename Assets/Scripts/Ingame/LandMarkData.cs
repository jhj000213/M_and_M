using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMarkData : MonoBehaviour {

    const int _MaxStationLevel = 5;
   
    public int[] _NeedUpgradeCostList = new int[_MaxStationLevel];
    public int[] _AllowanceList = new int[_MaxStationLevel];
    

    void Start()
    {
        ListInit();
        


    }
    

    void ListInit()
    {
        int StartAllowance = 100;
        int StartUpgradeCost = 50000;
        _NeedUpgradeCostList[0] = StartUpgradeCost;
        _AllowanceList[0] = StartAllowance;

        for(int i=1;i<_MaxStationLevel;i++)
        {
            _NeedUpgradeCostList[i] = (int)(_NeedUpgradeCostList[i - 1] * 1.1f);
            _AllowanceList[i] = (int)(_AllowanceList[i - 1] * 1.1f);
        }
    }
}
