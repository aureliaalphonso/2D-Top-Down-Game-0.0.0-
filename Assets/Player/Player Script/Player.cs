using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Move info")]
    public float moveSpeed = 1f;

    [Header("Dash info")]
    [SerializeField] private float dashCoolDown;
    private float dashUsageTimer;
    public float dashSpeed;
    public float dashDuration;

    
    
    #region Componenets

    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    public Vector2 movement;
    public Vector2 facingDir { get; private set; } = Vector2.right;

    #endregion


    #region States

    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }

    public PlayerDashState dashState { get; private set; }


    public PlayerPrimaryAttack primaryAttack { get; private set; }



    #endregion

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        dashState = new PlayerDashState(this, stateMachine, "Dash");

        primaryAttack = new PlayerPrimaryAttack(this, stateMachine, "Attack");


    }

    private void Start()
    {
        stateMachine.Initialize(idleState);
    }


    private void Update()
    {
        stateMachine.currentState.Update();

        if (movement.sqrMagnitude > 0)
        {
            facingDir = movement.normalized;
        }

        CheckForDashInput();
    }



    public void CheckForDashInput()
    {
        dashUsageTimer -= dashCoolDown;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dashUsageTimer = dashCoolDown;
            stateMachine.ChangeState(dashState);
        }
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }
}