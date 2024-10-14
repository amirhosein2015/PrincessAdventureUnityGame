using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    public float speed = 8;

    public float jumpForce = 10;
    public float gravity = -20;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public bool ableToMakeADoubleJump = true;

    public Animator animator;
    public Transform model;


    public AudioSource source;
    public AudioClip Win;







    void Update()
    {
        if (PlayerManager.gameOver)
        {
            //play death animation
            animator.SetTrigger("die");

            //disable the script
            this.enabled = false;
        }

        //Take the horizontal input to move the player
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;
        animator.SetFloat("speed", Mathf.Abs(hInput));

        //Check if the player is on the ground
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        if (isGrounded)
        {
            direction.y = -1;
            ableToMakeADoubleJump = true;

            Jumping();

            FireAttack();

            IceAttack();

            SnowMagic();


        }
        else
        {
            direction.y += gravity * Time.deltaTime;//Add Gravity
            if (ableToMakeADoubleJump && Input.GetButtonDown("Jump"))
            {
                DoubleJump();
            }
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Fireball Attack"))
            return;


        if (animator.GetCurrentAnimatorStateInfo(0).IsName("IceAttack"))
            return;



        if (animator.GetCurrentAnimatorStateInfo(0).IsName("SnowMagic"))
            return;


        //Flip the player
        if (hInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
            model.rotation = newRotation;
        }

        //Move the player using the character controller
        controller.Move(direction * Time.deltaTime);

        //Reset Z Position
        if (transform.position.z != 0)
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        //win level
        if (PlayerManager.winLevel)
        {
            source.clip = Win;
            source.Play();
            animator.SetTrigger("win");
            this.enabled = false;
        }
    }

    private void DoubleJump()
    {
        //Double Jump
        animator.SetTrigger("doubleJump");
        direction.y = jumpForce;
        ableToMakeADoubleJump = false;
    }
    private void Jump()
    {
        //Jump
        direction.y = jumpForce;
    }

//-----------------------------------------For Clean 
   void FireAttack()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("fireBallAttack");
            //FireBallAttack();
        }
    }


   void IceAttack()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            animator.SetTrigger("IceAttack");
            //IceAttack();
        }

    }



  void SnowMagic()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            animator.SetTrigger("SnowMagic");
            //SnowMagic();
        }
    }




 void Jumping()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }




    //--------------------------------Touch

   public void PntFireAttack()
    {
            animator.SetTrigger("fireBallAttack");
        }


    public void PntIceAttack()
    {
        animator.SetTrigger("IceAttack");
    }


    public void PntSnowAttack()
    {
        animator.SetTrigger("SnowMagic");
    }


    public void PntJump()
    {
        Jump();
    }



}
