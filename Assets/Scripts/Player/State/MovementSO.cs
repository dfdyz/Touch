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
	protected PlayerEntity player;

	public override void Awake(StateMachine stateMachine)
	{
		player = stateMachine.GetComponent<PlayerEntity>();
	}

	public override void OnUpdate()
	{



	}

    public override void OnFixedUpdate()
    {
        Rigidbody rb = player.rb;

        Vector3 dir = player.GetDiraction();
        float maxSpeed = player.getMaxSpeed();
        Vector3 targetVelocy = dir.normalized * maxSpeed;

        Vector3 currentVelocy = rb.velocity;

        Vector3 Fn = targetVelocy.normalized - currentVelocy.normalized;  //方向修正补偿力
        Vector3 F = targetVelocy - currentVelocy;  //修正力

        float fnArg = 8f*player.getMass();
        float fArg = player.getAccelerate(currentVelocy.magnitude);

        F = F * fArg + Fn * fnArg;

        rb.AddForce(F, ForceMode.Force);
    }

    public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
