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
    protected Animator anim;

    public override void Awake(StateMachine stateMachine)
	{
        player = stateMachine.GetComponent<PlayerEntity>();
        anim = player.GetComponentInChildren<Animator>();
	}
	
	public override void OnUpdate()
	{
		player.rb.velocity = Vector3.zero;
	}
	
	public override void OnStateEnter()
	{
		player.SetHitBoxPosY(3);
		anim.SetBool("Miss",true);
        AudioMgr.Instance.PlaySound(AudioMgr.SoundType.Hit, AudioMgr.Instance.Sound_miss);
    }
	
	public override void OnStateExit()
	{
		anim.SetBool("Miss",false);
		player.SetHitBoxPosY(0);
    }
}
