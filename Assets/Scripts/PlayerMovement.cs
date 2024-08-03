using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Walk,
    Attack,
    Interact,
    Stagger
}

public class PlayerMovement : MonoBehaviour
{
    public Transform checkpointTransform;
    public int playerHealth = 5;
    public PlayerState currentState;
    public float moveSpeed = 4f;
    private Rigidbody2D rb;
    private Vector3 movement;
    private Animator animator;
    public AudioSource playerHurt;
    [SerializeField] AudioManager audioManager;
    [SerializeField] GameObject inventoryPanel;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = checkpointTransform.position;
        currentState = PlayerState.Walk;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        //Player Movement
        if (currentState == PlayerState.Walk &&
            Input.GetKeyDown("w") ||
            Input.GetKeyDown("a") ||
            Input.GetKeyDown("s") ||
            Input.GetKeyDown("d"))
        {
            audioManager.SfxStep();
        }
        //else if (currentState != PlayerState.Walk &&
        //    Input.GetKeyUp("w") ||
        //    Input.GetKeyUp("a") ||
        //    Input.GetKeyUp("s") ||
        //    Input.GetKeyUp("d"))
        //{
        //}

        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            movement = Vector3.zero;
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        if (Input.GetButtonDown("Attack") && currentState != PlayerState.Attack
            && currentState != PlayerState.Stagger)
        {
            if (!(!DialogueManager.GetInstance().dialogueIsPlaying && inventoryPanel.activeSelf))
            {
                StartCoroutine(AttackCo());
            }
        }
        else if (currentState == PlayerState.Walk || currentState == PlayerState.Idle)
        {
            AnimationMove();
        }
    }

    IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.Attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.Walk;
    }


    private void AnimationMove()
    {
        if (movement != Vector3.zero)
        {
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
            audioManager.SfxStepStop();
        }
    }

    void FixedUpdate()
    {
        movement.Normalize();
        rb.MovePosition(transform.position + moveSpeed * movement * Time.deltaTime);
    }

    public void Knock(float knockTime)
    {
        StartCoroutine(KnockCo(knockTime));
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (rb != null)
        {
            playerHealth--;
            playerHurt.Play();
            //Debug.Log("Attacked");
            yield return new WaitForSeconds(knockTime);
            rb.velocity = Vector2.zero;
            currentState = PlayerState.Idle;
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            checkpointTransform = collision.gameObject.transform;
        }
    }

    public void RespawnPlayer()
    {
        transform.position = checkpointTransform.position;
    }
}
