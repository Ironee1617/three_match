using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Three_match_rule : MonoBehaviour
{
    private static Three_match_rule instance;
    public static Three_match_rule Instance { get { return instance; } }

    public static Fruit[,] FruitLayout = new Fruit[8, 8];


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
            bool match_check = false;

            //StartCoroutine(f_fruit.Move(secondPos));
            //StartCoroutine(s_fruit.Move(firstPos));

            LayoutSwap(f_fruit, s_fruit);

            
        }
        else return;
    }

    private bool CheckMatchRule(Fruit f_fruit, Fruit s_fruit)
    {
        if (CheckMatch(f_fruit) == false && CheckMatch(s_fruit) == false)
            return true;
        return false;
    }

    private void LayoutSwap(Fruit f_fruit, Fruit s_fruit)
    {
        Fruit temp = f_fruit;
        FruitLayout[f_fruit.local.First, f_fruit.local.Second] = s_fruit;
        FruitLayout[s_fruit.local.First, s_fruit.local.Second] = temp;

        f_fruit.LocalSwap(s_fruit);
    }

    private bool CheckMatch(Fruit fruit)
    {
        List<Fruit> list = new List<Fruit>();

        if (Three_match_check.Check(FruitLayout, fruit)) return true;

        return false;
    }

    private bool Check(Fruit fruit1, Fruit fruit2)
    {
        return fruit1.fruit_Color == fruit2.fruit_Color;
    }


    private void MatchFail(Fruit f_fruit, Fruit s_fruit)
    {
        Vector2 firstPos = s_fruit.transform.position;
        Vector2 secondPos = f_fruit.transform.position;

        //StartCoroutine(f_fruit.Move(secondPos));
        //StartCoroutine(s_fruit.Move(firstPos));

        LayoutSwap(f_fruit, s_fruit);
    }
}
