using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Player_2 : MonoBehaviour
{
    public float movementSpeed = 3;
    public float JumpForce = 4;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
            Vector3 characterScale = transform.localScale;
            if (Input.GetKeyDown(KeyCode.A) == true)
            { 
                characterScale.x = -1;
            }

            if (Input.GetKeyDown(KeyCode.D) == true)
            {
                characterScale.x = 1;
            }
            transform.localScale = characterScale;

            if (Input.GetKeyDown(KeyCode.W) && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
            {
                _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }
        
        
        
       
    }
}

