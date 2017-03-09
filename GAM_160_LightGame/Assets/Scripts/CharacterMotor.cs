using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class CharacterMotor : MonoBehaviour {

    public float walkingSpeed = 4;
    public float sneakSpeed = 1;

    [HideInInspector]
    public bool canMove = true;

    float speed;
    bool isSneaking = false;

    Vector3 moveDirection;
    Rigidbody rBody;

    void Awake()
    {
        rBody = GetComponent<Rigidbody>();

        rBody.constraints = RigidbodyConstraints.FreezeRotation; //Make sure rigidBody doesn't fall over
    }

    public void ReciveInput(float hor, float ver, bool sneak)
    {
        isSneaking = sneak;
        moveDirection = new Vector3(hor, 0, ver);
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
    }

    void Move()
    {
        speed = isSneaking ? sneakSpeed : walkingSpeed; //Set the speed depending on the input

        Vector3 newVelocity = transform.TransformDirection(moveDirection * speed); //Create a vector3 that is relative to the players direction.
        newVelocity.y = rBody.velocity.y; //Set the new y velocity to the rigidbodys y velocity 
        rBody.velocity = newVelocity;
    }
}
