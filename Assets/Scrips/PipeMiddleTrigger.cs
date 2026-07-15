using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PipeMiddleTrigger : MonoBehaviour
{

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // If bird passes between pipes increase score
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            //  logic.Instance addScore(1);
            LogicScript.Instance.addScore(1);
        }

    }

}
