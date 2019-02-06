﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public float inputX, inputY;
    private Vector2 playerPos;
    private BoxCollider2D boxCollider2d;
    private float moverSpeed;


    RaycastHit2D rayHit;
    int layerMask = 1 << 8;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2d = this.GetComponent<BoxCollider2D>();
        moverSpeed = 0.05f;
    }

    private void setColliderPos(Vector2 newPos) { 
        // set the collider location
        boxCollider2d.transform.SetPositionAndRotation(newPos, new Quaternion(0f, 0f, 0f, 0f));
    }

    private Vector2 getColliderCenterPos() {
        // get the collider centre
        return boxCollider2d.bounds.center;
    }

    private void MoveCharacter(float xMovement, float yMovement) {

        // get the current position and work out where we are moving to
        Vector2 currentPosition = getColliderCenterPos();
        Vector2 newPosition;
        if (xMovement == 0 || yMovement == 0)
        {
            newPosition = new Vector2(xMovement * moverSpeed, yMovement * moverSpeed) + currentPosition;
        }
        else {
            newPosition = new Vector2((xMovement * moverSpeed) / 2, (yMovement * moverSpeed) / 2) + currentPosition;
        }
        // we are moving to this position

        // we are moving to this position


        // make sure we arnt about to walk into an unpassible area
        if (Physics2D.BoxCast(currentPosition, new Vector2(0.3f,0.3f),0,new Vector2(inputX, inputY), moverSpeed * 2, layerMask))
        {
            Debug.Log("hit");
            //mover made contact with something
        }
        else
        {
            //there is space to move, move into it
            setColliderPos(newPosition);
        }


    }

    // Update is called once per frame
    void Update()
    {
        //move the character via input from controller
        MoveCharacter(inputX, inputY);
    }


}