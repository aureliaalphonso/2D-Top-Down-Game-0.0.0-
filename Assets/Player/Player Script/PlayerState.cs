using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : Player
{
    protected PlayerStateMachine stateMachine;
    public Player player;

    public Rigidbody2D rb;

    protected float stateTimer;
    private string animBoolName;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)

    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        rb = player.rb;

    }

    public virtual void Update()
    {

        stateTimer -= Time.deltaTime;
        
        player.movement.x = Input.GetAxisRaw("Horizontal");
        player.movement.y = Input.GetAxisRaw("Vertical");

        player.anim.SetFloat("Horizontal", player.movement.x);
        player.anim.SetFloat("Vertical", player.movement.y);
        player.anim.SetFloat("Speed", player.movement.sqrMagnitude);
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }
    
}


