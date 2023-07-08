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

    protected PlayerEntity player;

    public override void Awake(StateMachine stateMachine)
	{
        player = stateMachine.GetComponent<PlayerEntity>();
    }
	
	public override void OnUpdate()
	{
		player.rb.velocity = Vector3.zero;
	}
	
	public override void OnStateEnter()
	{
		player.SetHitBoxPosY(3);
	}
	
	public override void OnStateExit()
	{
        player.SetHitBoxPosY(0);
    }
}
