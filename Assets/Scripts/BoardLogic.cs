using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardLogic : MonoBehaviour
{
    
    /*
     * TODO: add randomizers for the 3 bool properties in the list and have public numbers that
     * can change the max amount of them can be true so that it leaves the rest false once it has enough.
    */
    
    public int totalNumberOfSpaces = 100;
     
    // Start is called before the first frame update
    private void Start()
    {
        CreateGameBoardData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //the properties each space can hold on the board
    private readonly struct SpaceProperties
    {
        public SpaceProperties(int inSpaceNumbers, bool inDoesItHaveSpirit, bool inDoesItHaveStartCurrent, bool inDoesItHaveEndCurrent)
        {
            SpaceNumber = inSpaceNumbers;
            DoesItHaveSpirit = inDoesItHaveSpirit;
            DoesItHaveStartCurrent = inDoesItHaveStartCurrent;
            DoesItHaveEndCurrent = inDoesItHaveEndCurrent;
        }

        private int SpaceNumber { get; }
        private bool DoesItHaveSpirit { get;}
        private bool DoesItHaveStartCurrent { get; }
        private bool DoesItHaveEndCurrent { get; }
        
        public override string ToString() => $"({SpaceNumber}, {DoesItHaveSpirit}, {DoesItHaveStartCurrent}, {DoesItHaveEndCurrent})";
    }

    // function to create the board game data. Should be called at the start if the scene.
    private void CreateGameBoardData()
    {
        var gameBoard = new List<SpaceProperties>();

        for (var i = 1; i <= totalNumberOfSpaces; i++)
        {
            var temp = new SpaceProperties(i, false, false, false);
            gameBoard.Add(temp);
            
            // comment out when no longer testing
            // Debug.Log(temp.ToString());
        }
    }
}
