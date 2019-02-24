using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerManager;


    private void Awake()
    {
        if (PlayerManager.instance == null);
        //Instantiate gameManager prefab
        Instantiate(playerManager);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
