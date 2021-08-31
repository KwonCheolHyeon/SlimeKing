using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int amountCoin;
    public float jellyHeal;

    

    void Update()
    {
        healtUp();
        

    }
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        Score.coinAmount += 1;
        amountCoin += 1;
        GameManager.jellyHp = jellyHeal;
        Destroy(gameObject);
        
        
    }
    

        void healtUp() //게이지 업!
         {
        if (amountCoin >= 0)
        {
            jellyHeal = 0.25f;
        }
        else if (amountCoin >= 10 && amountCoin <= 30)
        {
            jellyHeal = 0.20f;
        }
        else if (amountCoin >= 30 && amountCoin <=50)
        {
            jellyHeal = 0.15f;
        }
        else
        {
            jellyHeal = 0.10f;
        }

    }



}
