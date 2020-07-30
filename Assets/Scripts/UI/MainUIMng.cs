using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIMng : MonoBehaviour {

    public UI2DSprite _CarUserGaze;
    public UI2DSprite _YearsGaze;
    public UI2DSprite _GoldGaze;

    public UILabel _YearsLabel;
    public UILabel _PopulationLabel;
    public UILabel _GoldLabel;

    void Update()
    {
        _CarUserGaze.fillAmount = StateMng.Data._NowCarUser / StateMng.Data._MaxCarUser;
        _YearsGaze.fillAmount = StateMng.Data._NowYearsGaze / StateMng.Data._MaxYearsGaze;
        _GoldGaze.fillAmount = StateMng.Data._NowGoldGaze / StateMng.Data._MaxGoldGaze;

        _YearsLabel.text = StateMng.Data._Years.ToString();
        SetGoldLabel();
        SetPopulationLabel();
    }

    void SetPopulationLabel()
    {
        int population = StateMng.Data._Populations;
        //population = 1500;

        int first = population % 1000;
        int second = (population % 1000000 - first)/1000;
        int third = (population % 1000000000 - second - first)/1000000;

        string firsts = first.ToString();
        string seconds = second.ToString();
        string thirds = third.ToString();
        if (first == 0)
            firsts = "000";
        if (second == 0)
            seconds = "000";
        if (third == 0)
            thirds = "000";

        if (population < 1000)
        {
            _PopulationLabel.text = firsts;
            if (firsts == "000")
                firsts = "0";
            _PopulationLabel.text = firsts;
        }
        else if (population < 1000000)
            _PopulationLabel.text = seconds + "," + firsts;
        else
            _PopulationLabel.text = thirds + "," + seconds + "," + firsts;
    }

    void SetGoldLabel()
    {
        int gold = StateMng.Data._GoldValue;
        //gold = 987654132;

        int first = gold % 1000;
        int second = (gold % 1000000 - first) / 1000;
        int third = (gold % 1000000000 - second - first) / 1000000;

        string firsts = first.ToString();
        string seconds = second.ToString();
        string thirds = third.ToString();
        if (first == 0)
            firsts = "000";
        if (second == 0)
            seconds = "000";
        if (third == 0)
            thirds = "000";

        if(first<100)
        {
            if(second !=0)
            {
                firsts = "0" + first.ToString();
                if (first < 10)
                    firsts = "00" + first.ToString();
            }
            
        }
        if (second < 100)
        {
            if(third!=0)
            {
                seconds = "0" + second.ToString();
                if (second < 10)
                    seconds = "00" + second.ToString();
            }
            
        }
        

        if (gold < 1000)
        {
            _GoldLabel.text = firsts;
            if (firsts == "000")
                firsts = "0";
            _GoldLabel.text = firsts;
        }
        else if (gold < 1000000)
            _GoldLabel.text = seconds + "," + firsts;
        else
            _GoldLabel.text = thirds + "," + seconds + "," + firsts;
    }
}
