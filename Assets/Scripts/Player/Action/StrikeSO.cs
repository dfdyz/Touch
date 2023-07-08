﻿using UnityEngine;
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

	public override void Awake(StateMachine stateMachine)
	{
		player = stateMachine.GetComponent<PlayerEntity>();
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
