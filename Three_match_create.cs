using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Three_match_create : MonoBehaviour
{
    public static Action ReCreate;

    public GameObject tile;
    private GameObject[,] Tiles = new GameObject[8, 8];

    public Fruit[] Fruit;

    // Start is called before the first frame update
    void Start()
    {
        InitTileLocal();
        InitFruitLayout();
    }

    private void InitTileLocal()
    {
        for(int i = 0; i < Tiles.GetLength(0); i++)
        {
            for(int j = 0; j < Tiles.GetLength(1); j++)
            {
                GameObject t = Instantiate(tile);
                Tiles[i, j] = t;
                Tiles[i, j].transform.localPosition = new Vector2(-2.1f + (j * 0.6f), 2.1f + (i * -0.6f));
            }
        }
    }

    private void InitFruitLayout()
    {
        for (int i = 0; i < Three_match_rule.FruitLayout.GetLength(0); i++)
        {
            for (int j = 0; j < Three_match_rule.FruitLayout.GetLength(1); j++)
            {
                Fruit f = Instantiate(Fruit[RandomFruitNum()]);
                f.local.SetValue(i, j);
                Three_match_rule.FruitLayout[i, j] = f;
                Three_match_rule.FruitLayout[i, j].transform.localPosition = Tiles[i, j].transform.localPosition;
            }
        }
    }

    private int RandomFruitNum()
    {
        return Random.Range(0, 5);
    }


}
