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
            Debug.Log("ù��° ����");
        }

    if (Input.GetKeyDown("space") && isGrounded)
        {

        rb.velocity = new Vector2(0.0f, rb.velocity.y);
        animator.Play("BeforeJump", -1, 0);
        Debug.Log("�ι�° ����");
        }


    if (jumpValue >= 10f && isGrounded && Input.GetKeyUp("space"))
        {
        jumpValue = 10;

        PlaySound("JUMP");
        float tempx = moveInput * walkSpeed * 1.5f;
        float tempy = jumpValue;
        rb.velocity = new Vector2(tempx, tempy);
        Debug.Log("����° ����");
        Invoke("ResetJump", 0.1f);
        }

if (Input.GetKeyUp("space"))
{
    if (isGrounded)
    {
        PlaySound("JUMP");
        rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
        Debug.Log("�׹�° ����");
        jumpValue = 0.0f;
    }

}
}

      void ResetJump()
    {
        Debug.Log("ResetJump ����");
        //canJump = false;
        jumpValue = 0;


    }



}
*/