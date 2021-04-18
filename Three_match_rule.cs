using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Three_match_rule : MonoBehaviour
{
    public GameObject[,] FruitLayout = new GameObject[8, 8];

    private GameObject touchedFruit;
    // Start is called before the first frame update

    Vector2 touchPos;
    Vector2 endPos;
    float distance;
    int layerNum = 1 << 9;
    int nearNum;

    Tile cur_Tile = new Tile();
    Tile swi_Tile = new Tile();

    public bool[] possibility;


    // Start is called before the first frame update
    void Start()
    {
        possibility = new bool[2];
        possibility[0] = true;
        possibility[1] = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (possibility[0] && possibility[1])
            TouchTofruit();

        else if (Input.GetMouseButtonUp(0))
        {
            possibility[0] = true;
        }
    }

    void TouchTofruit()
    {
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 t_Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(t_Pos, transform.forward, 15f, layerNum);
                if (hit)
                {
                    cur_Tile = hit.transform.GetComponent<Tile>();
                    touchPos = t_Pos;
                }
            }

            if (Input.GetMouseButton(0) && cur_Tile != null)
            {
                endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                distance = Vector2.Distance(cur_Tile.transform.position, endPos);
                if (distance > 2.5f)
                {
                    Vector2 t_Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Debug.DrawRay(t_Pos, transform.forward * 10, Color.red, 0.3f);
                    RaycastHit2D hit = Physics2D.Raycast(t_Pos, transform.forward, 15f, layerNum);
                    if (hit)
                    {
                        swi_Tile = hit.transform.GetComponent<Tile>();

                        if (swi_Tile.fruit == null || swi_Tile.transform.localPosition != swi_Tile.fruit.transform.localPosition)
                            return;
                        for (int i = 0; i < 6; ++i)
                        {
                            if (cur_Tile.near_Tile[i] == swi_Tile)
                                break;
                            else if (i == 5 && cur_Tile.near_Tile[i] != swi_Tile)
                                return;
                        }

                        possibility[0] = false;
                        possibility[1] = false;
                        Switchfruit(cur_Tile.transform.localPosition, swi_Tile.transform.localPosition);
                    }
                }
            }
        }
    }

    void Switchfruit(Vector2 _cur, Vector2 _swi)
    {
        if (swi_Tile == null)
            return;
        try
        {
            for (int i = 0; i < cur_Tile.near_Tile.Length; ++i)
            {
                if (cur_Tile.near_Tile[i] == null)
                {
                    continue;
                }

                if (cur_Tile.near_Tile[i] == swi_Tile)
                {
                    nearNum = i;
                    break;
                }
            }
            Fruit temp = cur_Tile.fruit;
            cur_Tile.fruit = swi_Tile.fruit;
            swi_Tile.fruit = temp;



            StartCoroutine(cur_Tile.fruit.Swap(_cur, () =>
            {
            }, 30));

            //StartCoroutine(swi_Tile.fruit.Swap(_swi, () =>
            //{
            //    if (!Match.Instance.AllCheckStart(nearNum, cur_Tile, swi_Tile))
            //        Resetfruit(_cur, _swi);
            //    else
            //        Manager_Process.Instance.move -= 1;
            //}, 30));
        }
        catch (NullReferenceException e)
        {
            Debug.LogWarning("Bug - Nullref");
            possibility[0] = true;
            possibility[1] = true;
        }
    }

    void Resetfruit(Vector2 _cur, Vector2 _swi)
    {
        try
        {
            Fruit temp = cur_Tile.fruit;
            cur_Tile.fruit = swi_Tile.fruit;
            swi_Tile.fruit = temp;

            StartCoroutine(cur_Tile.fruit.Swap(_cur, () =>
            {
            }, 30));

            StartCoroutine(swi_Tile.fruit.Swap(_swi, () =>
            {
                possibility[1] = true;
            }, 30));
        }
        catch (NullReferenceException e)
        {
            Debug.LogWarning("Bug2 - Nullref");
            possibility[0] = true;
            possibility[1] = true;
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Vector3 mp = Input.mousePosition;
    //        mp = Camera.main.ScreenToWorldPoint(mp);

    //        RaycastHit2D hit = Physics2D.Raycast(mp, transform.forward, 15f, 1 << 6);
    //        if (hit)
    //        {
    //            touchedFruit = hit.transform.gameObject;
    //        }
    //    }
    //}
}
