using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "Movement", menuName = "State Machines/Actions/Movement")]
public class MovementSO : StateActionSO
{
	protected override StateAction CreateAction() => new Movement();
}

public class Movement : StateAction
{
	protected new MovementSO OriginSO => (MovementSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
	}
	
	public override void OnUpdate()
	{
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
