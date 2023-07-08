using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsStun", menuName = "State Machines/Conditions/Is Stun")]
public class IsStunSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsStun();
}

public class IsStun : Condition
{
	protected new IsStunSO OriginSO => (IsStunSO)base.OriginSO;
    protected PlayerEntity player;
    public override void Awake(StateMachine stateMachine)
	{
        player = stateMachine.GetComponent<PlayerEntity>();
    }
	
	protected override bool Statement()
	{
		return player.isStun();
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
