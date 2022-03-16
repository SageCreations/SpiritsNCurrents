using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int numberOfPlayers; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private struct PlayerInfo
    {
        public PlayerInfo(int inCurrentOccupiedSpace)
        {
            
            CurrentOccupiedSpace = inCurrentOccupiedSpace;
            GameObject gameObject = null;
            CardsHeld = gameObject.AddComponent<CardLogic>();
            //CardsHeld = "";
        }
        
        private int CurrentOccupiedSpace { get; }
        // what cards the player has, so probably a var of type card from the card logic script
        private CardLogic CardsHeld;
        
    }

    void CreatePlayerData()
    {
        
    }
}
