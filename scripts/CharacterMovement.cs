using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public TextMeshProUGUI hpText;
    public int hp;

    private Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateUI();
    }

    void Update()
    {
        // Input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Check if character is moving, and rotate if necessary
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            // rb.rotation = angle;
        }
    }

    void FixedUpdate()
    {
        // Movement
        rb.velocity = moveDirection * moveSpeed;
    }
    void OnTriggerEnter2D(Collider2D col){
        Debug.Log("hit zombie");
        hp -= 1;
        UpdateUI();

    }
    void UpdateUI(){
        hpText.text = hp.ToString();
    }
}
