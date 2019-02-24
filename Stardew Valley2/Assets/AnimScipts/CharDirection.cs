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
}
