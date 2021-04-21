using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public FRUITCOLOR block_Color;
    public Pair<int, int> local =  new Pair<int, int>();

    Queue<Vector3> end_Vector = new Queue<Vector3>();

    public IEnumerator Move(Vector3 e_vector, float _speed = 100f)
    {
        end_Vector.Enqueue(e_vector);
        while (true)
        {
            try
            {
                if (this.transform.position == end_Vector.Peek())
                {
                    end_Vector.Dequeue();
                }
                if (end_Vector.Count == 0)
                {
                    end_Vector.Clear();
                    break;
                }
                this.transform.position = Vector3.MoveTowards(this.transform.position, end_Vector.Peek(), _speed * Time.deltaTime);
            }
            catch (MissingReferenceException e)
            {
                break;
            }
            yield return null;
        }

    }

    public IEnumerator Swap(Vector3 e_vector, System.Action callback, float _speed = 100)
    {
        while (true)
        {
            try
            {
                if (this.transform.position == e_vector)
                {
                    callback();
                    break;
                }
                this.transform.position = Vector3.MoveTowards(this.transform.position, e_vector, _speed * Time.deltaTime);
            }
            catch (MissingReferenceException e)
            {
                break;
            }
            yield return null;
        }
    }

    public void AddVector(Vector3 _vector)
    {
        end_Vector.Enqueue(_vector);
    }
}
