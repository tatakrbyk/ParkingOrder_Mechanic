using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;
    public float countTracks, numberOfMoves;
    public bool _victory, _lose;
    void Start()
    {
        if (gameManagerInstance == null)
            gameManagerInstance = this;

        countTracks = GameObject.FindGameObjectsWithTag("path").Length;
        numberOfMoves = countTracks + 5; // have x moves left 

    }

    public void Victory()
    {
        if(countTracks.Equals(0) && !_lose)
        {
            _victory = true;
            Debug.Log("You Win");
        }
    }

    public void Lose()
    {
        if(_lose | numberOfMoves.Equals(0) && !_victory)
        {
            _lose = true;
            Debug.Log("You Wont");
        }
    }
}
