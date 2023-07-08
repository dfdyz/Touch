using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "Stun", menuName = "State Machines/Actions/Stun")]
public class StunSO : StateActionSO
{
	protected override StateAction CreateAction() => new Stun();
}

public class Stun : StateAction
{
	protected new StunSO OriginSO => (StunSO)base.OriginSO;

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
