using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsMissing", menuName = "State Machines/Conditions/Is Missing")]
public class IsMissingSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsMissing();
}

public class IsMissing : Condition
{
	protected new IsMissingSO OriginSO => (IsMissingSO)base.OriginSO;

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
