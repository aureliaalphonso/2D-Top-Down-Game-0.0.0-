using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{

    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        

        if (movement.sqrMagnitude == 0)
        {
            player.anim.SetFloat("lastHorizontal", movement.x);
            player.anim.SetFloat("lastVertical", movement.y);
            
            stateMachine.ChangeState(player.idleState);
        }

    }

    
}