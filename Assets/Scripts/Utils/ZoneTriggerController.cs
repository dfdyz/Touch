using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class BoolEvent : UnityEvent<bool, GameObject> { }

public class ZoneTriggerController : MonoBehaviour
{
	[SerializeField] private BoolEvent _enterZone = default;
	[SerializeField] private LayerMask _layers = default;

	private Collider _coll;

	private void Awake()
	{
		_coll = GetComponent<Collider>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if ((1 << other.gameObject.layer & _layers) != 0)
		{
			_enterZone.Invoke(true, other.gameObject);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if ((1 << other.gameObject.layer & _layers) != 0)
		{
			_enterZone.Invoke(false, other.gameObject);
		}
	}
}
