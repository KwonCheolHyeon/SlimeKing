using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;
    
    public static int coinAmount=0;
    
    
    void Start()
    {
        
        text = GetComponent<Text>();

        

    }
    


    void Update()
    {
        if (JumpKing.regam) 
        {
            coinAmount = 0;
            
        }

        text.text = coinAmount.ToString();
    }
    

}
