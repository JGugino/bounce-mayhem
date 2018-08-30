using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public static BallController instance;

    public bool isPC;

    private int damageDone = 0;

    [SerializeField]
    private float throwForce = 1.5f, jumpForce = 3.5f;

    private Vector2 startPos, endPos, swipe;

    private Rigidbody ballRB;

    private bool isJumping = false;

    private void Awake()
    {
        instance = this;
    }

    void Start () {
        ballRB = GetComponent<Rigidbody>();
	}
	
	void Update () {
        if (!isPC)
        {
            mobileSwipe();
            mobileJump();
        }
        else if(isPC)
        {
            pcSwipe();
            pcJump();
        }
	}

    #region Mobile Controls
    private void mobileSwipe()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            startPos = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position);
        }
        else if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            endPos = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position);
            preformSwipe();
        }
    }

    private void mobileJump()
    {
        if (!isJumping)
        {
            if ((Input.touchCount > 0) && (Input.GetTouch(1).phase == TouchPhase.Began))
            {
                preformJump();
            }
        }
    }
    #endregion

    #region PC Controls
    private void pcSwipe()
    {
        if ((Input.GetMouseButtonDown(0)))
        {
            startPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }else if ((Input.GetMouseButtonUp(0)))
        {
            endPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            preformSwipe();
        }
    }

    private void pcJump()
    {
        if (!isJumping)
        {
            if (Input.GetButtonDown("Jump"))
            {
                preformJump();
            }
        }
    }
    #endregion

    private void preformJump()
    {
        ballRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJumping = true;
    }

    private void preformSwipe()
    {
        swipe = endPos - startPos;

        if (swipe.y > 0)
        {
            ballRB.AddForce(Vector3.forward * throwForce, ForceMode.Impulse);
        }

        if (swipe.y < 0)
        {
            ballRB.AddForce(Vector3.back * throwForce, ForceMode.Impulse);
        }

        if (swipe.x > 0)
        {
            ballRB.AddForce(Vector3.right * throwForce, ForceMode.Impulse);
        }

        if (swipe.x < 0)
        {
            ballRB.AddForce(Vector3.left * throwForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string otherName = collision.collider.name;

        if (otherName == "Ground")
        {
            isJumping = false;
        }
    }

    #region Getters
    public int getDamageDone()
    {
        return damageDone;
    }
    #endregion

    #region Setters/Adders
    public void addToDamage(int _damageToAdd)
    {
        int damageAfter = damageDone + _damageToAdd;

        damageDone = damageAfter;

        Debug.Log("Damage Done: " + damageDone);
    }
    #endregion
}
