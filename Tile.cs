using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum TILE_STATE
    {
        Idle,
        Enter,
        Out,
        Full
    }

    public TILE_STATE tile_State;
    public Fruit fruit;

    public Tile[] near_Tile = new Tile[6];

    Coroutine cor;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StateCheck());
    }


    public IEnumerator StateCheck()
    {
        while (true)
        {
            switch (tile_State)
            {
                case TILE_STATE.Idle:
                    State_Idle();
                    break;
                case TILE_STATE.Out:
                    State_Out();
                    break;
            }
            yield return null;
        }
    }

    void State_Idle()
    {
        if (fruit != null)
        {
            tile_State = TILE_STATE.Enter;
            State_Enter();
            return;
        }
    }

    public void State_Enter()
    {
        //및 타일이 없거나 || 현 타일에 블록이 없을 때
        if (near_Tile[3] == null || fruit == null)
        {
            tile_State = TILE_STATE.Full;
            return;
        }

        //밑타일이 비었을때
        if (near_Tile[3].fruit == null)
        {
            near_Tile[3].fruit = fruit;
            tile_State = TILE_STATE.Out;
            if (fruit.moved == false)
            {
                StartCoroutine(fruit.Move(near_Tile[3].transform.localPosition));
            }
            else
            {
                fruit.AddVector(near_Tile[3].transform.localPosition);
            }
        }
        else if (near_Tile[3].fruit != null && near_Tile[2] == null && near_Tile[4].fruit != null)
        {
            tile_State = TILE_STATE.Full;
        }
        else if (near_Tile[3].fruit != null && near_Tile[2].fruit == null)
        {
            near_Tile[2].fruit = fruit;
            tile_State = TILE_STATE.Out;
            if (fruit.moved == false)
            {
                StartCoroutine(fruit.Move(near_Tile[2].transform.localPosition));
            }
            else
            {
                fruit.AddVector(near_Tile[2].transform.localPosition);
            }
        }
        else if (near_Tile[3].fruit != null && near_Tile[4] == null && near_Tile[2].fruit != null)
        {
            tile_State = TILE_STATE.Full;
        }
        else if (near_Tile[3].fruit != null && near_Tile[2].fruit != null && near_Tile[4].fruit == null)
        {
            near_Tile[4].fruit = fruit;
            tile_State = TILE_STATE.Out;
            if (fruit.moved == false)
            {
                StartCoroutine(fruit.Move(near_Tile[4].transform.localPosition));
            }
            else
            {
                fruit.AddVector(near_Tile[4].transform.localPosition);
            }
        }
        
        if(tile_State == TILE_STATE.Enter)
        {
            tile_State = TILE_STATE.Full;
        }
        
    }

    void State_Out()
    {
        fruit = null;
        tile_State = TILE_STATE.Idle;
    }
}
