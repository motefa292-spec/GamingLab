using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // متغيرات الحركة والقفز[cite: 129]
    public float moveSpeed; 
    public float jumpHeight; 
    
    // أزرار التحكم[cite: 129]
    public KeyCode Spacebar; 
    public KeyCode L; 
    public KeyCode R; 

    // متغيرات التحقق من ملامسة الأرض[cite: 135]
    public Transform groundCheck; 
    public float groundCheckRadius; 
    public LayerMask whatIsGround; 
    private bool grounded; 

    void Start()
    {
        
    }

    // تُستدعى هذه الدالة للتحقق من الفيزياء وملامسة الأرض[cite: 139]
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // تُستدعى هذه الدالة في كل إطار (Frame) للتحكم في الحركة[cite: 141]
    void Update()
    {
        // القفز (يُسمح به فقط إذا كان اللاعب يلامس الأرض)[cite: 141]
        if (Input.GetKeyDown(Spacebar) && grounded) 
        {
            Jump(); 
        }

        // الحركة لليسار[cite: 141]
        if (Input.GetKey(L)) 
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            
            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        // الحركة لليمين[cite: 141]
        if (Input.GetKey(R)) 
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            
            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    // دالة تنفيذ القفز[cite: 131]
    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
}