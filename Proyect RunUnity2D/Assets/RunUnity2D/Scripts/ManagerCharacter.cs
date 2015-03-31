using UnityEngine;
using System.Collections;


public class ManagerCharacter : MonoBehaviour
{
    // Var public
    public float forceJump = 100.0f;                // Force to jump character
    public GameObject characterRigi;                // Prefab Character  
    public Transform checkGround;                   // Check Ground  
    public LayerMask maskGround;                    // Mask Ground

    // Var privates
    private float checkRatio = 0.1f;                // Ratio Ground
    private bool inGrounded = true;                 // Aux character Grounded
    private bool doubleJump = false;                // Aux character Two Jump
    private Animator animator;                      // Animator character

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
        // if get button mouse 0 or touch (SmartPhone), character run
        if ((inGrounded || !doubleJump) && Input.GetMouseButtonDown(0))
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
}