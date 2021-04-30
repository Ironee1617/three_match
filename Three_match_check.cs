using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Three_match_check : MonoBehaviour
{
    //public delegate void Check(Fruit fruit);
    //public static Check check;

    public static Action<Fruit> check;

    List<List<Fruit>> checked_fruit = new List<List<Fruit>>(4);
    private enum DIRECTION
    {
        Up,
        Down,
        Right,
        Left
    }

    void Start()
    {
        while(checked_fruit.Count < 4)
            checked_fruit.Add(new List<Fruit>());

        check += UpCheck;
        check += DownCheck;
        check += RightCheck;
        check += LeftCheck;
    }

    void UpCheck(Fruit fruit)
    {
        Fruit up_fruit = Three_match_rule.FruitLayout[fruit.local.First, fruit.local.Second + 1];
        if (fruit.fruit_Color == up_fruit.fruit_Color)
        {
            EqualColor(checked_fruit, (int)DIRECTION.Up, up_fruit, (up_fruit) => { UpCheck(up_fruit); });
        }
    }
    void DownCheck(Fruit fruit)
    {
        Fruit down_fruit = Three_match_rule.FruitLayout[fruit.local.First, fruit.local.Second - 1];
        if (fruit.fruit_Color == down_fruit.fruit_Color)
        {
            EqualColor(checked_fruit, (int)DIRECTION.Down, down_fruit, (down_fruit) => { DownCheck(down_fruit); });
        }
    }
    void RightCheck(Fruit fruit)
    {
        Fruit right_fruit = Three_match_rule.FruitLayout[fruit.local.First + 1, fruit.local.Second];
        if (fruit.fruit_Color == right_fruit.fruit_Color)
        {
            EqualColor(checked_fruit, (int)DIRECTION.Right, right_fruit, (right_fruit) => { RightCheck(right_fruit); });
        }
    }
    void LeftCheck(Fruit fruit)
    {
        Fruit left_fruit = Three_match_rule.FruitLayout[fruit.local.First - 1, fruit.local.Second];
        if (fruit.fruit_Color == left_fruit.fruit_Color)
        {
            EqualColor(checked_fruit, (int)DIRECTION.Left, left_fruit, LeftCheck);
        }
    }

    void EqualColor(List<List<Fruit>> list, int dir, Fruit fruit, Action<Fruit> check_func)
    {
        list[dir].Add(fruit);
        if (list[dir].Count < 1)
            check_func(fruit);
        else
            return;
    }

    void ListInit()
    {
        for(int i = 0; i < 4; i++)
        {
            checked_fruit[i].Clear();
        }
    }

    //void Check_Fruit(Fruit fruit, DIRECTION direction)
    //{
    //    Fruit fruit = Three_match_rule.FruitLayout[fruit.local.First - 1, fruit.local.Second];
    //    if (fruit.fruit_Color == left_fruit.fruit_Color)
    //    {
    //        checked_fruit[(int)DIRECTION.Left].Add(left_fruit);
    //        if (checked_fruit[(int)DIRECTION.Left].Count < 2)
    //            UpCheck(left_fruit);
    //        else
    //            return;
    //    }
    //}
}
