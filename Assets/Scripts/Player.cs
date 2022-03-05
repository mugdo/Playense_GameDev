using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKeyWasPress;
    private float horizontalInput;
    // private float VerticallInput;
    private Rigidbody getComponent;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        getComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPress = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
        // VerticallInput = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        if(!isGrounded)
        {
            return;
        }
        getComponent.velocity = new Vector3(horizontalInput, getComponent.velocity.y, 0);
        if(jumpKeyWasPress)
        {
            getComponent.AddForce(Vector3.up*10, ForceMode.VelocityChange);
            jumpKeyWasPress = false;
        }
        
        // getComponent.velocity = new Vector3(0,VerticallInput, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded =false;
    }
    private void OnTrigggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
        }
    }
}
