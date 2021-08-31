using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonEvent : MonoBehaviour
{
  //  GameObject Player;
    //JumpKing jumpKing;
   
    void Start()
    {
    
      //  Player = GameObject.Find("player");
        //jumpKing = Player.GetComponent<JumpKing>();


    }

    // Update is called once per frame
    void LateUpdate()
    {
        JumpBtnTF();
    }
    void Update()
    {
       // JumpBtnTF();
    }
    /*
    public void LeftBtnDown()
    {
        JumpKing.LeftMove = true;
    }
    public void LeftBtnUp() 
    {
        JumpKing.LeftMove = false;
    }
    public void RightBtnDown()
    {
        JumpKing.RightMove = true;
    }

    public void RightBtnUp()
    {
        JumpKing.RightMove = false;
    }
    */
    public void JumpBtnTF()
    {
        if (JumpKing.btnTF == false)
        {

            // GetComponent<Button>().interactable = false;
            //this.GetComponent<Button>().enabled = false;

        }
        else 
        {
        
            // GetComponent<Button>().interactable = true;
            //this.GetComponent<Button>().enabled = true;
        }
    
    }
}
