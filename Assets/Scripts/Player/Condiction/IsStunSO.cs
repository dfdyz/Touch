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

	public override void Awake(StateMachine stateMachine)
	{
	}
	
	protected override bool Statement()
	{
		return true;
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
