using UnityEngine;
using System.Collections;


public class ManagerCharacter : MonoBehaviour
{
    //Var public
    public float forceJump = 100.0f;                // Force to jump character
    public GameObject characterRigi;

    private void Start()
    {
        // Assig character - var
        characterRigi = this.gameObject;
    }

    private void Update()
    {
        // if get button mouse 0 or touch (SmartPhone), character run
        if (Input.GetMouseButtonDown(0))
        {
            // Add force in X for run
            characterRigi.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceJump));
        }
    }
}