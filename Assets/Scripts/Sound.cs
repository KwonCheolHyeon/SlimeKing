using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*{
public class Scound : MonoBehaviour
/*{

 
         moveInput = Input.GetAxis("Horizontal");


        if (jumpValue == 0.0f && isGrounded)
        {
            rb.velocity  = new Vector2(moveInput* walkSpeed, rb.velocity.y);
        }

        if (Input.GetKey("space") && isGrounded )
        {
            jumpValue += 0.03f;
            Debug.Log("첫번째 성공");
        }

    if (Input.GetKeyDown("space") && isGrounded)
        {

        rb.velocity = new Vector2(0.0f, rb.velocity.y);
        animator.Play("BeforeJump", -1, 0);
        Debug.Log("두번째 성공");
        }


    if (jumpValue >= 10f && isGrounded && Input.GetKeyUp("space"))
        {
        jumpValue = 10;

        PlaySound("JUMP");
        float tempx = moveInput * walkSpeed * 1.5f;
        float tempy = jumpValue;
        rb.velocity = new Vector2(tempx, tempy);
        Debug.Log("세번째 성공");
        Invoke("ResetJump", 0.1f);
        }

if (Input.GetKeyUp("space"))
{
    if (isGrounded)
    {
        PlaySound("JUMP");
        rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
        Debug.Log("네번째 성공");
        jumpValue = 0.0f;
    }

}
}

      void ResetJump()
    {
        Debug.Log("ResetJump 성공");
        //canJump = false;
        jumpValue = 0;


    }



}
*/