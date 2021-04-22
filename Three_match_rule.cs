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

    private Raycast2D raycast;
    private Queue<Fruit> queue = new Queue<Fruit>();


    void Start()
    {
        raycast = GetComponent<Raycast2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            raycast.InputClick();
            
            if (raycast.touchedObject != null)
            {
                if (queue.Count < 2) queue.Enqueue(raycast.touchedObject.GetComponent<Fruit>());
            }

            if (queue.Count.Equals(2)) CheckFruit();
            raycast.touchedObject = null;
        }
        if (Input.GetMouseButtonUp(0))
        {
            
        }
    }

    private void CheckFruit()
    {
        Fruit f_fruit = queue.Dequeue();
        Fruit s_fruit = queue.Dequeue();

        if (f_fruit.gameObject == s_fruit.gameObject) return;

        if (f_fruit.PassibleToMove(s_fruit)) 
        {
            Vector2 firstPos = f_fruit.transform.position;
            Vector2 secondPos = s_fruit.transform.position;

            StartCoroutine(f_fruit.Move(secondPos));
            StartCoroutine(s_fruit.Move(firstPos));

            f_fruit.LocalSwap(s_fruit);


        }
        else return;
    }

    private bool CheckThreeMatch()
    {

        return false;
    }

    private bool Check()
    {
        return false;
    }


    private void ThreeMatchFail()
    {

    }
}
