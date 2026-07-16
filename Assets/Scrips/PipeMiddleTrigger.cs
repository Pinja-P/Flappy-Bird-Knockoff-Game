using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PipeMiddleTrigger : MonoBehaviour
{
    public TheBird Bird;

    void Start()
    {
        Bird = GameObject.FindGameObjectWithTag("TheBird").GetComponent<TheBird>();
    }
    

    // If bird passes between pipes increase score
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Bird.birdIsAlive == true && collision.gameObject.layer == 3)
        {
            //  logic.Instance addScore(1);
            LogicScript.Instance.addScore(1);
            AudioManager.Instance.PlaySFX("Points");
        }

    }

}
