using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterMover characterMover;

    private Animator charAnimator;
    private enum AnimDirection{N,NE,E,SE,S,SW,W,NW};
    private AnimDirection currentAnimDirection;
    private float animationSensitivity = 0.05f;
    public bool isMoving;
    float yMotion = 0;// = inY;
    float xMotion = 0;// = inX;

    // Start is called before the first frame update
    void Start()
    {
 
        characterMover = this.GetComponent<CharacterMover>();
        charAnimator = this.GetComponent<Animator>();

        

    }

    // Update is called once per frame
    void Update()
    {
        //ChangeAnim();

        // get axis input
        characterMover.inputY = Input.GetAxis("Vertical");
        characterMover.inputX = Input.GetAxis("Horizontal");
        ChangeAnim(characterMover.inputX, characterMover.inputY);
        SetDirection(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Debug.Log(currentAnimDirection + "facing number"   + charAnimator.GetFloat("FacingDirection"));
    }


    float test(float inputN) {
        inputN = inputN + (Mathf.Pow(inputN, inputN) * 0.25f);
        inputN = Mathf.Round(inputN / 0.5f) * 0.5f;
        return inputN;
    }

    void SetDirection(float inX, float inY) {

        if (inX == 0 && inY > 0)
        {
            currentAnimDirection = AnimDirection.N;
        }
        else if (inX > 0 && inY > 0)
        {
            currentAnimDirection = AnimDirection.NE;
        }
        else if (inX > 0 && inY == 0)
        {
            currentAnimDirection = AnimDirection.E;
        }
        else if (inX > 0 && inY < 0)
        {
            currentAnimDirection = AnimDirection.SE;
        }
        else if (inX == 0 && inY < 0)
        {
            currentAnimDirection = AnimDirection.S;
        }
        else if (inX < 0 && inY < 0)
        {
            currentAnimDirection = AnimDirection.SW;
        }
        else if (inX < 0 && inY == 0)
        {
            currentAnimDirection = AnimDirection.W;
        }
        else if (inX < 0 && inY > 0)
        {
            currentAnimDirection = AnimDirection.NW;
        }
    }
    void ChangeAnim(float inX, float inY) {

        //Debug.Log(test(0.05f));


        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            if (isMoving)
            {
                // yMotion = yMotion + (Mathf.Pow(yMotion, yMotion) * 0.25f);
                //  yMotion = Mathf.Round(yMotion);
                //   xMotion = xMotion + (Mathf.Pow(xMotion, xMotion) * 0.25f);
                // xMotion = Mathf.Round(xMotion);
                isMoving = false;
            }
  

        }
        else
        {
            yMotion = inY;
            xMotion = inX;
            isMoving = true;

        }

        charAnimator.SetFloat("DirectionY", yMotion);
        charAnimator.SetFloat("DirectionX", xMotion);
        charAnimator.SetFloat("FacingDirection", (float)currentAnimDirection);
        charAnimator.SetBool("isWalking", isMoving);


        //Debug.Log(isMoving);
    }

}
