using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Three_match_create : MonoBehaviour
{
    public static Action<List<Fruit>> ReCreate;

    public GameObject tile;
    
    private int tile_pool_number = 5;
    private GameObject[,] Tiles = new GameObject[8, 8];

    public Fruit[] Fruit;

    // Start is called before the first frame update
    void Start()
    {
        InitTileLocal();
        InitFruitLayout();

        ReCreate += ReCreateFruit;
    }

    private void InitTileLocal()
    {
        for(int i = 0; i < Tiles.GetLength(0); i++)
        {
            for(int j = 0; j < Tiles.GetLength(1); j++)
            {
                GameObject t = Manager_ObjectPool.Instance.PopFromPool(tile_pool_number);
                Tiles[i, j] = t;
                Tiles[i, j].transform.localPosition = new Vector2(-2.1f + (j * 0.6f), 2.1f + (i * -0.6f));

                t.SetActive(true);
            }
        }
    }

    private void InitFruitLayout()
    {
        for (int i = 0; i < Three_match_rule.FruitLayout.GetLength(0); i++)
        {
            for (int j = 0; j < Three_match_rule.FruitLayout.GetLength(1); j++)
            {
                Fruit f = Manager_ObjectPool.Instance.PopFromPool(RandomFruitNum()).GetComponent<Fruit>();
                f.local.SetValue(i, j);
                Three_match_rule.FruitLayout[i, j] = f;
                Three_match_rule.FruitLayout[i, j].transform.localPosition = Tiles[i, j].transform.localPosition;

                f.gameObject.SetActive(true);
            }
        }
    }

    private int RandomFruitNum()
    {
        return Random.Range(0, 5);
    }

    public void ReCreateFruit(List<Fruit> _destroyed_local)
    {
        for(int i = 0; i < _destroyed_local.Count; i++)
        {
            Fruit fruit = Manager_ObjectPool.Instance.PopFromPool(RandomFruitNum()).GetComponent<Fruit>();
            fruit.local.SetValue(_destroyed_local[i].local);
            fruit.transform.position = _destroyed_local[i].transform.position;
            //Add layout
            Three_match_rule.FruitLayout[_destroyed_local[i].local.First, _destroyed_local[i].local.Second] = fruit;

            fruit.gameObject.SetActive(true);

        }
    }
}
