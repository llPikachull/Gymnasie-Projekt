using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float movementSpeed = 1;
    public float JumpForce = 1;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Input.GetKeyDown(KeyCode.A)
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        if (Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0) 
        {
            characterScale.x = -1;
        }
       
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
    }
}

