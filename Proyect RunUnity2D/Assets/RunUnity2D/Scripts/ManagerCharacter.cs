/*******************************************************
    Autor: Antonio Mateo [ lPinchol ]
    Date:  31-05-2015
********************************************************/

using UnityEngine;
using System.Collections;


public class ManagerCharacter : MonoBehaviour
{
    // Var public
    public float forceJump = 11.0f;                 // Force to jump character
    public GameObject characterRigi;                // Prefab Character  
    public Transform checkGround;                   // Check Ground  
    public LayerMask maskGround;                    // Mask Ground
    public float speed = 1.0f;                      // Speed character

    // Var privates
    private float checkRatio = 0.1f;                // Ratio Ground
    private bool inGrounded = true;                 // Aux character Grounded
    private bool doubleJump = false;                // Aux character Two Jump
    private Animator animator;                      // Animator character
    private bool Runing = false;                    // Aux character runing

    /// <summary>
    /// Initialize var
    /// </summary>
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Load Start Script
    /// </summary>
    private void Start()
    {
        // Assig character - var
        characterRigi = this.gameObject;
    }

    /// <summary>
    /// Load Physic
    /// </summary>
    private void FixedUpdate()
    {
        if (Runing)
        {
            characterRigi.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, characterRigi.GetComponent<Rigidbody2D>().velocity.y);
        }
        animator.SetFloat("VelocidadX", characterRigi.GetComponent<Rigidbody2D>().velocity.x);
        inGrounded = Physics2D.OverlapCircle(checkGround.position, checkRatio, maskGround);
        animator.SetBool("isGrounded", inGrounded);
        if (inGrounded)
        {
            doubleJump = false;
        }
    }

    /// <summary>
    /// Load 24/s
    /// </summary>
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Runing)
            {
                // if get button mouse 0 or touch (SmartPhone), character junp
                if (inGrounded || !doubleJump)
                {
                    // Apply velocity
                    characterRigi.GetComponent<Rigidbody2D>().velocity = new Vector2(characterRigi.GetComponent<Rigidbody2D>().velocity.x, forceJump);
                    // Add force in X for run
                    characterRigi.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceJump));

                    // Double Jump
                    if (!doubleJump && !inGrounded)
                    {
                        doubleJump = true;
                    }
                }
            }
            else
            {
                Runing = true;
            }
        }
    }
}