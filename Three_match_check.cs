using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Three_match_check : MonoBehaviour
{
    //public delegate void Check(Fruit fruit);
    //public static Check check;

    public static Action<Fruit> check;
    public static Action end_check;

    List<List<Fruit>> checked_fruit = new List<List<Fruit>>(4);
    private enum DIRECTION
    {
        Up,
        Down,
        Right,
        Left
    }

    List<Fruit> destroy_fruit = new List<Fruit>();

    void Start()
    {
        while(checked_fruit.Count < 4)
            checked_fruit.Add(new List<Fruit>());

        check += UpCheck;
        check += DownCheck;
        check += RightCheck;
        check += LeftCheck;

        end_check += MatchCheck;
    }

    private void UpCheck(Fruit fruit)
    {
        Fruit up_fruit = Three_match_rule.FruitLayout[fruit.local.First, fruit.local.Second + 1];
        if (fruit.fruit_Color == up_fruit.fruit_Color)
        {
            EqualColor(checked_fruit, (int)DIRECTION.Up, up_fruit, UpCheck);
        }
    }
    private void DownCheck(Fruit fruit)
    {
        Fruit down_fruit = Three_match_rule.FruitLayout[fruit.local.First, fruit.local.Second - 1];
        if (fruit.fruit_Color == down_fruit.fruit_Color)
        {
            EqualColor(checked_fruit, (int)DIRECTION.Down, down_fruit, DownCheck);
        }
    }
    private void RightCheck(Fruit fruit)
    {
        Fruit right_fruit = Three_match_rule.FruitLayout[fruit.local.First + 1, fruit.local.Second];
        if (fruit.fruit_Color == right_fruit.fruit_Color)
        {
            EqualColor(checked_fruit, (int)DIRECTION.Right, right_fruit, RightCheck);
        }
    }
    private void LeftCheck(Fruit fruit)
    {
        Fruit left_fruit = Three_match_rule.FruitLayout[fruit.local.First - 1, fruit.local.Second];
        if (fruit.fruit_Color == left_fruit.fruit_Color)
        {
            EqualColor(checked_fruit, (int)DIRECTION.Left, left_fruit, LeftCheck);
        }
    }

    private void EqualColor(List<List<Fruit>> list, int dir, Fruit fruit, Action<Fruit> check_func)
    {
        list[dir].Add(fruit);
        if (list[dir].Count < 1)
            check_func(fruit);
        else
            return;
    }

    private void ListInit()
    {
        for(int i = 0; i < checked_fruit.Count; i++)
        {
            checked_fruit[i].Clear();
        }
    }

    private void MatchCheck()
    {
        //bool match_success = false;
        List<int> match_line = new List<int>();

        ThreeMatchCheck(match_line);
        if (match_line.Count != 0)
            FourMatchCheck(match_line);
    }

    private void ThreeMatchCheck(List<int> list)
    {
        for(int i = 0; i < checked_fruit.Count; i++)
        {
            if (checked_fruit[i].Count.Equals(2))
            {
                destroy_fruit.AddRange(checked_fruit[i]);
                list.Add(i);
            }
        }
    }

    private void FourMatchCheck(List<int> list)
    {
        if(list.Count != 0)
        {
            for(int i = 0; i < list.Count; i++)
            {
                int j = list[i] < 2 ? list[i] + 2 : list[i] - 2;

                if (checked_fruit[j].Count == 1)
                    destroy_fruit.AddRange(checked_fruit[j]);
            }
        }
    }

    private bool FiveMatchCheck()
    {
        return false;
        //if (checked_fruit[i])
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
