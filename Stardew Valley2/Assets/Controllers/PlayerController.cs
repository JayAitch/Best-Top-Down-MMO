using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterMover characterMover;
    private CharacterAnimator characterAnimator;
    private CharDirection charDirection;

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
        charDirection = this.GetComponent<CharDirection>();
        characterMover = this.GetComponent<CharacterMover>();
        characterAnimator = this.GetComponent<CharacterAnimator>();

    }

    // Update is called once per frame
    void Update()
    {


        // using controller input to move player
        characterMover.inputY = Input.GetAxis("Vertical")/4;
        characterMover.inputX = Input.GetAxis("Horizontal")/4;

        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) { isMoving = false; }
        else { isMoving = true; }
        // work out if we are attacking this will work but not like this
        // TODO: change to use a state machine
        if (Input.GetAxis("Action") > 0) { isAttacking = true; }
        else { isAttacking = false; }

        // set direction and animation states
        charDirection.SetDirection(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        characterAnimator.UpdateAnimationState(isMoving, isAttacking, (float)charDirection.currentCharacterDirection);


    }



}
