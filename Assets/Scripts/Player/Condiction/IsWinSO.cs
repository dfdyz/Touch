using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsWin", menuName = "State Machines/Conditions/Is Win")]
public class IsWinSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsWin();
}

public class IsWin : Condition
{
	protected new IsWinSO OriginSO => (IsWinSO)base.OriginSO;
	protected PlayerEntity playerEntity;
	public override void Awake(StateMachine stateMachine)
	{
		playerEntity = stateMachine.GetComponent<PlayerEntity>();
	}
	
	protected override bool Statement()
	{
		return playerEntity.isWinning;
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
