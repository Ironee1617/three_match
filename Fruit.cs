using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fruit : MonoBehaviour
{ 

    public enum FRUITCOLOR
    {
        Blue,
        Red,
        Yellow,
        Green,
        Orange
    }
    public FRUITCOLOR fruit_Color;
    public Pair<int, int> local =  new Pair<int, int>();

    Queue<Vector3> end_Vector = new Queue<Vector3>();

    

    public IEnumerator Move(Vector2 e_vector, float _speed = 10f)
    {

        end_Vector.Enqueue(e_vector);
        while (true)
        {
            try
            {
                if (this.transform.position == end_Vector.Peek()) { end_Vector.Dequeue(); }
                if (end_Vector.Count == 0) { break; }
                this.transform.position = Vector3.MoveTowards(this.transform.position, end_Vector.Peek(), _speed * Time.deltaTime);
            }
            catch (MissingReferenceException )
            {
                break;
            }
            yield return null;
        }



    }

    public IEnumerator Swap(Vector3 e_vector, System.Action callback, float _speed = 30)
    {
        while (true)
        {

            if (this.transform.position == e_vector)
            {
                yield return new WaitForSeconds(0.2f);
                callback();
                break;
            }
            this.transform.position = Vector3.MoveTowards(this.transform.position, e_vector, _speed * Time.deltaTime);

            yield return null;
        }
    }

    public bool PassibleToMove(Fruit fruit)
    {
        if (Mathf.Abs(local.First - fruit.local.First) + Mathf.Abs(local.Second - fruit.local.Second) == 1) return true;
        else return false;
    }

    public void LocalSwap(Fruit fruit)
    {
        Pair<int, int> temp = local;
        local = fruit.local;
        fruit.local = temp;
    }
}
