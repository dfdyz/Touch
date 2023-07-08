using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsStrike", menuName = "State Machines/Conditions/Is Strike")]
public class IsStrikeSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsStrike();
}

public class IsStrike : Condition
{
	protected new IsStrikeSO OriginSO => (IsStrikeSO)base.OriginSO;

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
