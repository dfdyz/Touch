﻿using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class BoolEvent : UnityEvent<bool, GameObject> { }

/// <summary>
/// A generic class for a "zone", that is a trigger collider that can detect if an object of a certain type (layer) entered or exited it.
/// Implements <code>OnTriggerEnter</code> and <code>OnTriggerExit</code> so it needs to be on the same object that holds the Collider.
/// </summary>
public class ZoneTriggerController : MonoBehaviour
{
	[SerializeField] private BoolEvent _enterZone = default;
	[SerializeField] private LayerMask _layers = default;

	private Collider2D _coll;

	private void Awake()
	{
		_coll = GetComponent<Collider2D>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if ((1 << other.gameObject.layer & _layers) != 0)
		{
			_enterZone.Invoke(true, other.gameObject);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if ((1 << other.gameObject.layer & _layers) != 0)
		{
			_enterZone.Invoke(false, other.gameObject);
		}
	}

	private void AnimationHandler(int enable)
	{
		_coll.enabled = enable == 1;
	}
}
