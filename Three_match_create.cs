using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Three_match_create : MonoBehaviour
{
    public GameObject tile;
    private GameObject[,] Tiles = new GameObject[8, 8];

    public Fruit[] Fruit;

    private Three_match_rule rule;
    // Start is called before the first frame update
    void Start()
    {
        rule = GetComponent<Three_match_rule>();

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
        for (int i = 0; i < rule.FruitLayout.GetLength(0); i++)
        {
            for (int j = 0; j < rule.FruitLayout.GetLength(1); j++)
            {
                Fruit f = Instantiate(Fruit[RandomFruitNum()]);
                f.local.SetValue(i, j);
                rule.FruitLayout[i, j] = f.gameObject;
                rule.FruitLayout[i, j].transform.localPosition = Tiles[i, j].transform.localPosition;
            }
        }
    }

    private int RandomFruitNum()
    {
        return Random.Range(0, 5);
    }
}
