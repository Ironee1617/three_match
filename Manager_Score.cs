using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Score : MonoBehaviour
{
    private static Manager_Score _instance;
    public static Manager_Score Instance
    {
        get {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(Manager_Score)) as Manager_Score;
            }
            return _instance; 
        }
    }

    public Text score_text;
    public int Score { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = Score.ToString();
    }
}
