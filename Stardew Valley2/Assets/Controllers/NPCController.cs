using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private CharacterMover characterMover;
    private CharacterAnimator characterAnimator;
    private CharDirection charDirection;


    public Vector2 CharacterDestination;
    public Vector2 currentPosition;

    private bool isAttacking;
    private bool isMoving = false;
    private float yVelocity = 0;
    private float xVelocity = 0;
    public GameObject followingTarget;





    // Start is called before the first frame update
    void Start()
    {
        // get scripts we need
        charDirection = this.GetComponent<CharDirection>();
        characterMover = this.GetComponent<CharacterMover>();
        characterAnimator = this.GetComponent<CharacterAnimator>();

    }

    // Update is called once per frame
    void Update()
    {

        if(followingTarget != null) FollowTargetObject();

        // resolve move positions
        ResolveMoveCharacter();
        // use the character mover to move 
        characterMover.inputX = xVelocity;
        characterMover.inputY = yVelocity;
        charDirection.SetDirection(xVelocity, yVelocity);

        // resolve state bools
        // to do: make this a state machine
        if (yVelocity == 0 && xVelocity == 0) { isMoving = false; }
        else { isMoving = true; }

        // update animation states
        // TODO: make this respect changes instead of calling every frame
        characterAnimator.UpdateAnimationState(isMoving, isAttacking, (float)charDirection.currentCharacterDirection);

    }

    // establish a direction to move in and move character
    void ResolveMoveCharacter() {
        // get the current position of the character
        currentPosition = transform.position;
        // work out the direction the character needs to move in
        // TODO: allow the character to navigate terrain
        Vector2 moveDirection = (CharacterDestination - currentPosition).normalized; 

        // if the character has reached destination (within .05)
        if (IsDestinationReached())
        {
            // dont move
            yVelocity = 0;
            xVelocity = 0;

        }
        else {
            // move the character promote to members
            yVelocity = moveDirection.y;
            xVelocity = moveDirection.x;

        }
        
    }
    private void FollowTargetObject() {
        CharacterDestination = followingTarget.transform.position;
    }


    // Return whether the destination is reached
    private bool IsDestinationReached() {
        // is destination within .05 of current position
        if (Vector2.Distance(CharacterDestination, currentPosition) < 0.05f)
        {
            // yes destination is reached
            return true;
        }
        else
        {
            // nope
            return false;
        }

    }
  



}
