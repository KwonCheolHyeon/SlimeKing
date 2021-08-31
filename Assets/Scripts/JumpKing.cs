using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class JumpKing : MonoBehaviour
{
    //PLAYER 스크립트


    //소리 모음
    //점프소리
    public AudioClip Jump;
    //맵 이동 소리
    public AudioClip MapChange;
    //낙사
    public AudioClip Drop;
    //배경음악
    public AudioClip BackGroundSound;
    //coin소리
    public AudioClip CoinSound;
    //게임 오버
    public AudioClip GameOverSound;

    AudioSource audioSource;

    // 소리 끝

    //점프킹 
    public GameObject Player;
    public float walkSpeed;
    public float moveInput;
    //public bool isGround;
    public static Rigidbody2D rb;
    public LayerMask groundMask;
    

    public PhysicsMaterial2D bounceMat, normalMat;
    public bool canJump = true;
    public float jumpValue = 0.0f;

    public Vector3 vec2;
    SpriteRenderer spriteRenderer;
    public Animator animator;

    //버튼 이동
    public static bool LeftMove = false;
    public static bool RightMove = false;
    public static bool JumpMove = false;
    Vector3 moveVelocity = Vector3.zero;

    //레이케스트
    public bool isGrounded;

    //죽음 이벤트 발동
    public static bool deathEvent = false;
    public bool deathone = true;

    //초기화 이벤트
    public static bool regam = false;
    public bool regamOnce = true;

    //버튼 비활성화 이벤트
    public static bool btnTF = true;

    //파티클 시스템 렌더러
    public static float particleC = 0;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //소리
        this.audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        
    }


    void Update()
    {
        

        /*
        moveInput = CrossPlatformInputManager.GetAxis("Horizontal");
        */

        moveInput = Input.GetAxis("Horizontal");

        particleC = moveInput;

       

        if (jumpValue == 0.0f && isGrounded)
        {
            rb.velocity  = new Vector2(moveInput * walkSpeed, rb.velocity.y);
        }

        if (moveInput < 0)
        {
            spriteRenderer.flipX = true;

        }
        else if (moveInput == 0) 
        {
            spriteRenderer.flipX = spriteRenderer.flipX;

        }
        else
        {
            spriteRenderer.flipX = false;
        }
      





        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.23f), new Vector2(0.6f, 0.04f), 0f, groundMask);

      
        
        if (isGrounded == false)
        {
            rb.sharedMaterial = bounceMat;
            btnTF = false;
        }
        else
        {
            btnTF = true;
            rb.sharedMaterial = normalMat;
            
        }


        
        /*
        if (CrossPlatformInputManager.GetButton("space") && isGrounded && canJump)
        {
            jumpValue += 10f * Time.deltaTime;
        }
     
        if (CrossPlatformInputManager.GetButtonDown("space") && isGrounded && canJump)
        { 
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
            animator.Play("BeforeJump", -1, 0);
        }

        
        if (jumpValue >= 10f && isGrounded && CrossPlatformInputManager.GetButtonUp("space"))
        {
            jumpValue = 10;
            PlaySound("JUMP");
            float tempx = moveInput * walkSpeed * 1.5f;
            float tempy = jumpValue;
            rb.velocity = new Vector2(tempx, tempy);
            Invoke("ResetJump", 0.1f);
            
        }


         if (CrossPlatformInputManager.GetButtonUp("space"))
        {
           
            if (isGrounded)
            {
                PlaySound("JUMP");
                rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
                animator.Play("Jumping", -1, 0);
                jumpValue = 0.0f;
            }
            canJump = true;

        }

        */

        
        
        //키보드 시작      

        if (Input.GetKey("space") && isGrounded && canJump)
        {
            jumpValue += 10f * Time.deltaTime;
            
        }

        if (Input.GetKeyDown("space") && isGrounded && canJump)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
            animator.Play("BeforeJump", -1, 0);
        }


        if (jumpValue >= 10f && isGrounded && Input.GetKeyUp("space"))
        {
            jumpValue = 10;
            PlaySound("JUMP");
            float tempx = moveInput * walkSpeed * 1.5f;
            float tempy = jumpValue;
            rb.velocity = new Vector2(tempx, tempy);
            Invoke("ResetJump", 0.2f);


        }

        if (Input.GetKeyUp("space"))
        {
            if (isGrounded)
            {
                
                PlaySound("JUMP");
                rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
                animator.Play("Jumping", -1, 0);
                jumpValue = 0.0f;
            }
            canJump = true;
        }




        // 키보드 종료

         
        //미끄럼 방지 
        if (moveInput == 0 && isGrounded == true)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }


        //게임 오버 이벤트 
        if (deathEvent == true &&  deathone) 
        {
            deathEvent = false;
            Debug.Log("deathEvent()");
            PlaySound("GameOverSound");
            DeathAni();
            deathone = false;
        }
        //새게임 이벤트
        if (regam && regamOnce) 
        {
            Debug.Log("regam()");
            regamOnce = false;
            regam = false;            
            deathone = true;
            regame();      
        }



         
    }
  
    void PlaySound(string action) 
    {
        switch (action) 
        {
            case "JUMP":
                audioSource.clip = Jump;
                break;
            case "DROP":
                audioSource.clip = Drop;
                break;
            case "MAP CHANGE":
                audioSource.clip = MapChange;
                break;
            case "BackGroundSound":
                audioSource.clip = BackGroundSound;
                break;
            case "CoinSound":
                audioSource.clip = CoinSound;
                break;
            case "GameOverSound":
                audioSource.clip = GameOverSound;
                break;

        }
        audioSource.Play();
    }

   private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.CompareTag("Drop"))//줄일수없다.
        {
            GameManager.discount = -1;
            Debug.Log(" 드랍");
            PlaySound("DROP");
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
            Player.transform.position = vec2;
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Coin"))
        {
            PlaySound("CoinSound");

        }
        if (other.transform.CompareTag("NextRoom"))
        {
            Debug.Log(" Get Next Room ");
            StageMgr.Instance.NextStage();
            PlaySound("MAP CHANGE");
        }
        // 낙사시 중간 세이브 포인트로 이동
        if (other.transform.CompareTag("Save"))
        { 
            vec2 = Player.transform.position;
            Debug.Log(" 위치 저장");
        }
        

    }
   
    void ResetJump()
    {
        
        //canJump = false;
        jumpValue = 0;
    }
    void CancanJump() 
    {
        
        if (isGrounded)
        {
            canJump = true;
        }

        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y-0.23f), new Vector2(0.6f, 0.04f));
    }


    void DeathAni() 
    {
        float speedy = 3f;
        this.GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log(" 데쓰애니");
        animator.Play("Die", -1, 0);
        rb.velocity = new Vector2(0.0f, 0f);
        rb.AddForce(Vector2.up * speedy, ForceMode2D.Impulse);
        Invoke("DeathAni2", 1f);
        
    }

    void DeathAni2() 
    {
        float speedy = 4f;
        rb.AddForce(Vector2.down * speedy, ForceMode2D.Impulse);
        GameManager.gameoverkey = true;
    }


    void regame() 
    {
        animator.Play("Idel", -1, 0);
        this.GetComponent<BoxCollider2D>().enabled = true;
        Debug.Log("regame()");
    }



}



