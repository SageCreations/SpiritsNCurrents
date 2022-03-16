using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

public class CardLogic : MonoBehaviour
{
    // public variables so they can be edited in the editor

    public string[] numberFaceType =
    {
        "Zero",
        "One",
        "Two",
        "Three",
        "Four",
        "Five",
        "Six",
        "Seven",
        "Eight",
        "Nine"
    };
    
    public string[] actionFaceType = 
    {
        "DrawTwo",
        "Reverse",
        "Skip"
    };

    public string[] wildFaceType =
    {
        "WildCard",
        "WildDrawFourCard"
    };
        
    public string[] colorType =
    {
        "Red",
        "Blue",
        "Yellow",
        "Green"
    };
    
    private readonly List<CardProperties> Deck = new List<CardProperties>();
    
    // Start is called before the first frame update
    void Start()
    {
        CreateDeckData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateDeckData()
    { 
        CreateNumberedCards();
        CreateActionCards();
        CreateWildCards();

        Shuffle(Deck);

        foreach (var t in Deck)
        {
            Debug.Log(t.ToString());
        }
        

    }

    void CreateNumberedCards()
    {
        // create zeros
        var colorCount = 0;
        for (var i = 1; i <= 4; i++, colorCount++)
        {
            Deck.Add(new CardProperties(numberFaceType[0], colorType[colorCount]));
        }
        
        // create the rest of numbered cards
        // this will loop through each face card after zero
        for (var i = 1; i < numberFaceType.Length; i++)
        {
            // this will loop through each color
            for (var j = 0; j < colorType.Length; j++)
            {
                // this will loop twice so that there are two of each color
                for (var k = 0; k < 2; k++)
                { 
                    Deck.Add(new CardProperties(numberFaceType[i], colorType[j]));
                }
            }
        }
    }

    void CreateActionCards()
    {
        for (var i = 0; i < actionFaceType.Length; i++)
        {
            // this will loop through each color
            for (var j = 0; j < colorType.Length; j++)
            {
                // this will loop twice so that there are two of each color
                for (var k = 0; k < 2; k++)
                { 
                    Deck.Add(new CardProperties(actionFaceType[i], colorType[j]));
                }
            }
        }
    }

    void CreateWildCards()
    {
        // there are only two types so this will loop twice
        for (var i = 0; i < wildFaceType.Length; i++)
        {
            // this will create 4 of each type
            for (var j = 0; j < 4; j++)
            {
                Deck.Add(new CardProperties(wildFaceType[i], "None"));
            }
        }
    }


    //using uno cards as a deck
    private readonly struct CardProperties
    {
        public CardProperties(string inCardFace, string inCardColor)
        {
            CardFace = inCardFace;
            CardColor = inCardColor;
        }

        private string CardFace { get; }
        private string CardColor { get; }

        public override string ToString() => $"({CardFace}, {CardColor},)";
    }



    void Shuffle<T>(IList<T> list)
    {
        var provider = new RNGCryptoServiceProvider();
        var n = list.Count;
        while (n > 1)
        {
            var box = new byte[1];
            do provider.GetBytes(box);
            while (!(box[0] < n * (Byte.MaxValue / n)));
            var k = (box[0] % n);
            n--;
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
    




}
