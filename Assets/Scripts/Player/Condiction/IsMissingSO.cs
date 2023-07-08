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
    protected PlayerEntity player;

    public override void Awake(StateMachine stateMachine)
	{
        player = stateMachine.GetComponent<PlayerEntity>();
    }
	
	protected override bool Statement()
	{
		return player.isMiss;
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
