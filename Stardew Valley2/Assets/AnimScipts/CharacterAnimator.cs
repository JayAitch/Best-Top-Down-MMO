using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator charAnimator;
    private SpriteRenderer spriteRenderer;
    private int renderOrder;
  //  public enum AnimationDirection { N, NE, E, SE, S, SW, W, NW };
   // public AnimationDirection currentAnimationDirection = AnimationDirection.N;
    // passing down a float from cotroller direction state
    // needs more thinkings
    private float currentAnimationDirection = 0;

    //TODO: use these states instead of bools
    private enum AnimationState { WALKING, ATTACKING, IDLE };
    private AnimationState currentAnimationState = AnimationState.IDLE;
    // To be depricated
    private bool isMoving = false;
    private bool isAttacking = false;


    // Start is called before the first frame update
    void Start()
    {
        charAnimator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // update the animation state
    // TODO: change to use state instead of shitty poopy bools
   public void UpdateAnimationState(bool pisMoving, bool pisAttacking, float pAnimationDirection) {
        // promote to members and trigger anim change
        isMoving = pisMoving;
        isAttacking = pisAttacking;
        currentAnimationDirection = pAnimationDirection;
        ChangeAnim();
        renderOrder = (int)transform.position.y * -1; ;
    }

    // use members to change animation state
    public void ChangeAnim()
    {
        spriteRenderer.sortingOrder = renderOrder;
        charAnimator.SetFloat("FacingDirection", (float)currentAnimationDirection);
        charAnimator.SetBool("isWalking", isMoving);
        charAnimator.SetBool("isAttacking", isAttacking);
    }
}
