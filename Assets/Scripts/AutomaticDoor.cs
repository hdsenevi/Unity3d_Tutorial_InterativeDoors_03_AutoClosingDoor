using UnityEngine;
using System.Collections;

public class AutomaticDoor : InteractiveObject 
{
	public override void OnAnimComplete()
	{
		Invoke("TriggerInteraction", 2f);
		Debug.Log("OnAnimComplete AutomaticDoor");
	}
}
