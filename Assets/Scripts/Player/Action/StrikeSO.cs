using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "Strike", menuName = "State Machines/Actions/Strike")]
public class StrikeSO : StateActionSO
{
	protected override StateAction CreateAction() => new Strike();
}

public class Strike : StateAction
{
	protected new StrikeSO OriginSO => (StrikeSO)base.OriginSO;
	protected PlayerEntity player;
	protected Vector3 v;

	public override void Awake(StateMachine stateMachine)
	{
		player = stateMachine.GetComponent<PlayerEntity>();
	}
	
	public override void OnUpdate()
	{
        player.rb.velocity = v * player.getMaxSpeed() * 1.4f;
    }
	
	public override void OnStateEnter()
	{
		v = player.GetDiraction().normalized;
		AudioMgr.Instance.PlaySound(AudioMgr.SoundType.Hit, AudioMgr.Instance.Sound_Strike);
    }
	
	public override void OnStateExit()
	{
        player.rb.velocity = v * player.getMaxSpeed() * 0.6f;
    }
}
