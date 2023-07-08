using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "Miss", menuName = "State Machines/Actions/Miss")]
public class MissSO : StateActionSO
{
	protected override StateAction CreateAction() => new Miss();
}

public class Miss : StateAction
{
	protected new MissSO OriginSO => (MissSO)base.OriginSO;

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
