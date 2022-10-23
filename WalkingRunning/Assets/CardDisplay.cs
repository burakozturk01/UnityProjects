using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{
    public Card[] cards;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var card in cards)
        {
            Debug.Log(card);
        }
    }
}
