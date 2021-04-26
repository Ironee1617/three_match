using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Three_match_check : MonoBehaviour
{
    public delegate void Check(Fruit fruit);
    public Check check;

    void Start()
    {
        check += UpCheck;
        check += DownCheck;
        check += RightCheck;
        check += LeftCheck;
    }

    void UpCheck(Fruit fruit)
    {
        if(fruit.fruit_Color == Three_match_rule.Instance.FruitLayout[fruit.local.First, fruit.local.Second + 1].fruit_Color)
        {

        }
    }
    void DownCheck(Fruit fruit)
    {

    }
    void RightCheck(Fruit fruit)
    {

    }
    void LeftCheck(Fruit fruit)
    {

    }
}
