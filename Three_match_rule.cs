using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Three_match_rule : MonoBehaviour
{
    public GameObject[,] FruitLayout = new GameObject[8, 8];
    
    private GameObject touchedTile;
    public GameObject TouchedTile
    {
        get { return touchedTile; }
        set { touchedTile = value; }
    }

    private Raycast2D<Fruit> raycast;
    private Queue<Fruit> queue = new Queue<Fruit>();


    void Start()
    {
        raycast = GetComponent<Raycast2D<Fruit>>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(raycast.InputClick()) {
                if (queue.Count < 1) queue.Enqueue(raycast.InputClick());
                else CheckFruit();
            }
        }
    }

    private void CheckFruit()
    {
        Fruit f_fruit = queue.Dequeue();
        Fruit s_fruit = queue.Dequeue();



        queue.Clear();
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
