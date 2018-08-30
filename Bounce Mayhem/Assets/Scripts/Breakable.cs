using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{

    [SerializeField]
    private int itemValue = 0;

    private bool isBroken = false;

    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        string otherName = collision.collider.name;

        if (otherName == "Ground")
        {
            if (!isBroken)
            {
                BallController.instance.addToDamage(itemValue);
                isBroken = true;
            }
        }
    }
}
