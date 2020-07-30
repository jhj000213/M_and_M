using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMark : MonoBehaviour {

    //public LandMarkData _Data;
    public UILabel _MinusPopulationLabel_1;
    public UILabel _MinusPopulationLabel_2;
    public UILabel _LevelLabel_1;
    public UILabel _LevelLabel_2;
    public UILabel _StationNameLabel_1;
    public UILabel _StationNameLabel_2;
    public UILabel _NeedGoldLabel;

    public string _StationName;
    public int _StationLevel;
    public int _MinusPopulation;
    public int _NeedUpgradeGold;

    int _NeedGoldAddingValue = 100;
    int _NGV = 10;

    void Start()
    {
        _StationLevel = 1;
        //_MinusPopulation = _Data._AllowanceList[_StationLevel];
        //_NeedUpgradeGold = _Data._NeedUpgradeCostList[_StationLevel];

        _MinusPopulation = 100;
        _NeedUpgradeGold = 100;
    }

    void Update()
    {
        //_MinusPopulation = _Data._AllowanceList[_StationLevel-1];
        //_NeedUpgradeGold = _Data._NeedUpgradeCostList[_StationLevel-1];

        _MinusPopulationLabel_1.text = _MinusPopulation.ToString();
        _LevelLabel_1.text = _StationLevel.ToString();
        _StationNameLabel_1.text = _StationName;
        _MinusPopulationLabel_2.text = _MinusPopulation.ToString();
        _LevelLabel_2.text = _StationLevel.ToString();
        _StationNameLabel_2.text = _StationName;
        _NeedGoldLabel.text = _NeedUpgradeGold.ToString() + " ￦";
    }

    public void Upgrading()
    {
        if(StateMng.Data._GoldValue>=_NeedUpgradeGold)
        {
            StateMng.Data._GoldValue -= _NeedUpgradeGold;
            _StationLevel++;
            _MinusPopulation += 100;
            _NeedUpgradeGold += _NeedGoldAddingValue;
            _NGV+=5;
            _NeedGoldAddingValue = _NGV * 10;
        }
        
    }
    
}
