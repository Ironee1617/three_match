using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class Three_match_check : MonoBehaviour
{


    private void Start()
    {
        
    }

























    ////public delegate void Check(Fruit fruit);
    ////public static Check check;

    //public static Action<Fruit> check;
    //public static Func<bool> end_check;

    //List<List<Fruit>> checked_fruit = new List<List<Fruit>>(4);
    //private enum DIRECTION
    //{
    //    Up,
    //    Down,
    //    Right,
    //    Left
    //}
    //// up down left right
    //Pair<int, int>[] Direction;

    //List<Fruit> destroy_fruit = new List<Fruit>();

    //void Start()
    //{
    //    Direction = new Pair<int, int>[4];
    //    Direction[0] = new Pair<int, int>(-1, 0);
    //    Direction[1] = new Pair<int, int>(1, 0);
    //    Direction[2] = new Pair<int, int>(0, -1);
    //    Direction[3] = new Pair<int, int>(0, 1);

    //    while (checked_fruit.Count < 4)
    //        checked_fruit.Add(new List<Fruit>());

    //    check += AddClickFruit;
    //    //check += FruitCheck;
    //    check += UpCheck;
    //    check += DownCheck;
    //    check += RightCheck;
    //    check += LeftCheck;

    //    end_check += MatchCheck;
    //}

    //public static void ChainFunc()
    //{

    //}

    //private void AddClickFruit(Fruit fruit)
    //{
    //    destroy_fruit.Add(fruit);
    //}
    ////private void FruitCheck(Fruit fruit)
    ////{
    ////    for(int dir = 0; dir < 4; dir++)
    ////    {
    ////        Pair<int, int> local = Direction[dir];
    ////        Fruit check_fruit = Three_match_rule.FruitLayout[fruit.local.First + local.First, fruit.local.Second + local.Second];
    ////        if (fruit.fruit_Color == check_fruit.fruit_Color)
    ////        {
    ////            EqualColor(checked_fruit, dir, check_fruit, FruitCheck);
    ////        }
    ////    }
    ////}
    //#region CHECK
    //public void UpCheck(Fruit fruit)
    //{
    //    if (fruit.local.First == 0) return;
    //    Fruit up_fruit = Three_match_rule.FruitLayout[fruit.local.First - 1, fruit.local.Second];
    //    if (fruit.fruit_Color == up_fruit.fruit_Color)
    //    {
    //        EqualColor(checked_fruit, (int)DIRECTION.Up, up_fruit, UpCheck);
    //    }
    //}

    //public void DownCheck(Fruit fruit)
    //{
    //    if (fruit.local.First == 7) return;
    //    Fruit down_fruit = Three_match_rule.FruitLayout[fruit.local.First + 1, fruit.local.Second];
    //    if (fruit.fruit_Color == down_fruit.fruit_Color)
    //    {
    //        EqualColor(checked_fruit, (int)DIRECTION.Down, down_fruit, DownCheck);
    //    }
    //}

    //public void RightCheck(Fruit fruit)
    //{
    //    if (fruit.local.Second == 7) return;
    //    Fruit right_fruit = Three_match_rule.FruitLayout[fruit.local.First, fruit.local.Second + 1];
    //    if (fruit.fruit_Color == right_fruit.fruit_Color)
    //    {
    //        EqualColor(checked_fruit, (int)DIRECTION.Right, right_fruit, RightCheck);
    //    }
    //}

    //public void LeftCheck(Fruit fruit)
    //{
    //    if (fruit.local.Second == 0) return;
    //    Fruit left_fruit = Three_match_rule.FruitLayout[fruit.local.First, fruit.local.Second - 1];
    //    if (fruit.fruit_Color == left_fruit.fruit_Color)
    //    {
    //        EqualColor(checked_fruit, (int)DIRECTION.Left, left_fruit, LeftCheck);
    //    }
    //}
    //#endregion

    //private void EqualColor(List<List<Fruit>> list, int dir, Fruit fruit, Action<Fruit> check_func)
    //{
    //    list[dir].Add(fruit);
    //    if (list[dir].Count < 2)
    //        check_func(fruit);
    //    else
    //        return;
    //}

    //private void ListInit()
    //{
    //    for(int i = 0; i < checked_fruit.Count; i++)
    //    {
    //        checked_fruit[i].Clear();
    //    }

    //    while (checked_fruit.Count < 4)
    //        checked_fruit.Add(new List<Fruit>());
    //}

    //private bool MatchCheck()
    //{
    //    List<int> match_line = new List<int>();

    //    ThreeMatchCheck(match_line);
    //    ThreeMatchCheckTwo(match_line);
    //    for(int i = 0; i < match_line.Count; i++) { Debug.Log(i + " = " + match_line[i]); }
    //    if (match_line.Count != 0)
    //    {
    //        //FourMatchCheck(match_line);
    //        DestroyFruit(ListInit);
    //    }
    //    else if (match_line.Count == 0)
    //        return false;

    //    destroy_fruit.Clear();
    //    return true;
    //}

    //private void DestroyFruit(Action Callback)
    //{
    //    for (int i = destroy_fruit.Count - 1; i >= 0; i--)
    //    {
    //        destroy_fruit[i].gameObject.SetActive(false);
    //    }

    //    Callback();
    //}

    //private void ThreeMatchCheck(List<int> list)
    //{
    //    for (int i = 0; i < checked_fruit.Count; i++)
    //    {
    //        if (checked_fruit[i].Count.Equals(2))
    //        {
    //            destroy_fruit.AddRange(checked_fruit[i]);
    //            list.Add(i);
    //        }
    //    }
    //}


    //// need refactoring
    //private void ThreeMatchCheckTwo(List<int> list)
    //{
    //    for (int i = 0; i < checked_fruit.Count / 2; i++)
    //    {
    //        if (checked_fruit[i].Count > 0)
    //        {
    //            if(checked_fruit[i+2].Count > 0)
    //            {
    //                Debug.Log(1);
    //                destroy_fruit.AddRange(checked_fruit[i]);
    //                destroy_fruit.AddRange(checked_fruit[i+2]);
    //                list.Add(i);
    //                list.Add(i + 2);
    //            }
    //        }
    //    }
    //}

    //private void FourMatchCheck(List<int> list)
    //{
    //    if(list.Count != 0)
    //    {
    //        for(int i = 0; i < list.Count; i++)
    //        {
    //            int j = list[i] < 2 ? list[i] + 2 : list[i] - 2;

    //            if (checked_fruit[j].Count == 1)
    //                destroy_fruit.AddRange(checked_fruit[j]);
    //        }
    //    }
    //}
}
