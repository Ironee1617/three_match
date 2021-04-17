using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Three_match_rule : MonoBehaviour
{
    public GameObject[,] FruitLayout = new GameObject[8, 8];

    private GameObject touchedFruit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mp = Input.mousePosition;
            mp = Camera.main.ScreenToWorldPoint(mp);

            RaycastHit2D hit = Physics2D.Raycast(mp, transform.forward, 15f, 1 << 6);
            if(hit)
            {
                touchedFruit = hit.transform.gameObject;
            }
        }
    }
}
