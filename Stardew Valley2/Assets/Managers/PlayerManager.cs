using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public GameObject playerCharcter;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            //Remove duplicate singletons
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Call the InitGame function to initialize players
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {

        Instantiate(playerCharcter);

        //Call the SetupScene function of the BoardManager script, pass it current level number.
        Debug.Log("Game UP");

    }



    //Update is called every frame.
    void Update()
    {

    }
}
