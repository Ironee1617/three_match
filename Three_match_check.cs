using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class Three_match_check : MonoBehaviour
{
    public static Func<Fruit[,], Fruit, bool> Check;

    public Pair<int, int>[] dir = new Pair<int, int>[4];

    private void InitDirection()
    {
        dir[0] = new Pair<int, int>(-1, 0);
        dir[1] = new Pair<int, int>(1, 0);
        dir[2] = new Pair<int, int>(0, -1);
        dir[3] = new Pair<int, int>(0, 1);
    }

    private void Start()
    {
        InitDirection();

        Check += CheckToMatch;
    }

    #region Move_And_Check
    private bool CheckToMatch(Fruit[,] _layout, Fruit _fruit)
    {
        List<Fruit> checked_fruit = new List<Fruit>();
        List<Fruit> destroy_fruit = new List<Fruit>();

        destroy_fruit.Add(_fruit);
        VerticalCheck(_layout, _fruit, checked_fruit, destroy_fruit);
        HorizontalCheck(_layout, _fruit, checked_fruit, destroy_fruit);

        if(destroy_fruit.Count > 2)
        {
            Manager_Score.Instance.ScorePoints(destroy_fruit.Count * 10);
            FruitToDestroy(destroy_fruit);
            return true;
        }
        return false;
    }

    private void VerticalCheck(Fruit[,] _layout, Fruit _fruit, List<Fruit> _checked_fruit, List<Fruit> _destroy_fruit)
    {
        Recursion(_layout, _fruit, 0, _checked_fruit);
        Recursion(_layout, _fruit, 1, _checked_fruit);

        if (_checked_fruit.Count > 1) _destroy_fruit.AddRange(_checked_fruit);
        _checked_fruit.Clear();
    }

    private void HorizontalCheck(Fruit[,] _layout, Fruit _fruit, List<Fruit> _checked_fruit, List<Fruit> _destroy_fruit)
    {
        Recursion(_layout, _fruit, 2, _checked_fruit);
        Recursion(_layout, _fruit, 3, _checked_fruit);

        if (_checked_fruit.Count > 1) _destroy_fruit.AddRange(_checked_fruit);
        _checked_fruit.Clear();
    }

    private void Recursion(Fruit[,] _layout, Fruit _fruit, int _dir_num, List<Fruit> _list)
    {
        switch (_dir_num)
        {
            case 0:
                if (_fruit.local.First == 0) return;
                break;
            case 1:
                if (_fruit.local.First == 7) return;
                break;
            case 2:
                if (_fruit.local.Second == 0) return;
                break;
            case 3:
                if (_fruit.local.Second == 7) return;
                break;
        } // need refactoring

        Fruit next_fruit = _layout[_fruit.local.First + dir[_dir_num].First, _fruit.local.Second + dir[_dir_num].Second];
        if (CheckToColor(_fruit, next_fruit))
        {
            _list.Add(next_fruit);
            Recursion(_layout, next_fruit, _dir_num, _list);
        }
    }

    private bool CheckToColor(Fruit _f_fruit, Fruit _s_fruit)
    {
        return _f_fruit.fruit_Color == _s_fruit.fruit_Color;
    }

    private void FruitToDestroy(List<Fruit> _destroy_fruit)
    {
        //need to fix it later
        for(int i = 0; i < _destroy_fruit.Count; i++)
        {
            _destroy_fruit[i].gameObject.SetActive(false);
        }

        Three_match_create.ReCreate(_destroy_fruit);


        _destroy_fruit.Clear();
    }
    #endregion

    public void AllCheck()
    {
        Fruit[,] layout = Three_match_rule.FruitLayout;
        List<Fruit> checked_fruit = new List<Fruit>();
        List<Fruit> destroy_fruit = new List<Fruit>();

        for (int i = 0; i < layout.GetLength(0); i++)
        {
            for(int j = 0; j < layout.GetLength(1); j++)
            {
                AllCheckDirection(layout, layout[i, j], 1, checked_fruit, destroy_fruit);
            } // need fix
        }
    }

    private void AllCheckDirection(Fruit[,] _layout, Fruit _fruit, int _dir, List<Fruit> _checked_fruit, List<Fruit> _destroy_fruit)
    {
        Recursion(_layout, _fruit, _dir, _checked_fruit);

        if (_checked_fruit.Count > 2) _destroy_fruit.AddRange(_checked_fruit);
        _checked_fruit.Clear();
    }
}
