using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsMove", menuName = "State Machines/Conditions/Is Move")]
public class IsMoveSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsMove();
}

public class IsMove : Condition
{
	protected new IsMoveSO OriginSO => (IsMoveSO)base.OriginSO;
	protected Rigidbody rb;
	protected bool s = false;
	public override void Awake(StateMachine stateMachine)
	{
		rb = stateMachine.GetComponent<Rigidbody>();
	}
	
	protected override bool Statement()
	{
		if (s)
		{
			return rb.velocity.magnitude > 0.18f;
        }
		else
		{
            return rb.velocity.magnitude < 0.12f;
        }
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
