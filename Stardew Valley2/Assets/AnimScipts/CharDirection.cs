using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharDirection : MonoBehaviour
{
    public enum CharacterDirection { N, NE, E, SE, S, SW, W, NW };
    public CharacterDirection currentCharacterDirection;

    // work out the direction the character is facing 
    // TODO: promote this into an abstract 
    public void SetDirection(float inX, float inY)
    {

        if (inX == 0 && inY > 0)
        {
            currentCharacterDirection = CharacterDirection.N;
        }
        else if (inX > 0 && inY > 0)
        {
            currentCharacterDirection = CharacterDirection.NE;
        }
        else if (inX > 0 && inY == 0)
        {
            currentCharacterDirection = CharacterDirection.E;
        }
        else if (inX > 0 && inY < 0)
        {
            currentCharacterDirection = CharacterDirection.SE;
        }
        else if (inX == 0 && inY < 0)
        {
            currentCharacterDirection = CharacterDirection.S;
        }
        else if (inX < 0 && inY < 0)
        {
            currentCharacterDirection = CharacterDirection.SW;
        }
        else if (inX < 0 && inY == 0)
        {
            currentCharacterDirection = CharacterDirection.W;
        }
        else if (inX < 0 && inY > 0)
        {
            currentCharacterDirection = CharacterDirection.NW;
        }
    }

    public Vector2 getVectorDirection() {
        Vector2 direction;
        switch (currentCharacterDirection)
        {
            case CharacterDirection.N:
                direction = new Vector2(0, 1);
                break;
            case CharacterDirection.NE:
                direction = new Vector2(1, 1);
                break;
            case CharacterDirection.E:
                direction = new Vector2(1, 0);
                break;
            case CharacterDirection.SE:
                direction = new Vector2(1, -1);
                break;
            case CharacterDirection.S:
                direction = new Vector2(0, -1);
                break;
            case CharacterDirection.SW:
                direction = new Vector2(-1, -1);
                break;
            case CharacterDirection.W:
                direction = new Vector2(-1, 0);
                break;
            case CharacterDirection.NW:
                direction = new Vector2(-1, 1);
                break;
            default:
                direction = new Vector2(0, 0);
                break;
        }
            return direction;
    }
}
