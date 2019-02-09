using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterMover characterMover;
    private CharacterAnimator characterAnimator;

    private enum PlayerDirection{ N,NE,E,SE,S,SW,W,NW};
    private PlayerDirection currentPlayerDirection;
    private bool isAttacking;
    private bool isMoving = false;


        // we will need this c# magic for our animation state when its in
        //public bool isMovingTest
        //{
        //    set
        //    {
        //        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) { isMoving = false; }
        //        else { isMoving = true; }
        //    }
        //    get { return isMoving; }
        //}


    // Start is called before the first frame update
    void Start()
    {
 
        characterMover = this.GetComponent<CharacterMover>();
        characterAnimator = this.GetComponent<CharacterAnimator>();

    }

    // Update is called once per frame
    void Update()
    {


        // using controller input to move player
        characterMover.inputY = Input.GetAxis("Vertical");
        characterMover.inputX = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) { isMoving = false; }
        else { isMoving = true; }
        // work out if we are attacking this will work but not like this
        // TODO: change to use a state machine
        if (Input.GetAxis("Action") > 0) { isAttacking = true; }
        else { isAttacking = false; }

        // set direction and animation states
        SetDirection(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        characterAnimator.UpdateAnimationState(isMoving, isAttacking, (float)currentPlayerDirection);


    }



    // TODO:  move this to mover abstract class dont wanna keep pasting this
    void SetDirection(float inX, float inY) {

        if (inX == 0 && inY > 0)
        {
            currentPlayerDirection = PlayerDirection.N;
        }
        else if (inX > 0 && inY > 0)
        {
            currentPlayerDirection = PlayerDirection.NE;
        }
        else if (inX > 0 && inY == 0)
        {
            currentPlayerDirection = PlayerDirection.E;
        }
        else if (inX > 0 && inY < 0)
        {
            currentPlayerDirection = PlayerDirection.SE;
        }
        else if (inX == 0 && inY < 0)
        {
            currentPlayerDirection = PlayerDirection.S;
        }
        else if (inX < 0 && inY < 0)
        {
            currentPlayerDirection = PlayerDirection.SW;
        }
        else if (inX < 0 && inY == 0)
        {
            currentPlayerDirection = PlayerDirection.W;
        }
        else if (inX < 0 && inY > 0)
        {
            currentPlayerDirection = PlayerDirection.NW;
        }
    }


}
