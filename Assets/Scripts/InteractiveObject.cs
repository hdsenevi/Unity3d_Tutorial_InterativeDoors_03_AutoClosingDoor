using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Animation))]
public class InteractiveObject : MonoBehaviour 
{
	public enum eInteractiveState
	{
		Active, 	//Open
		Inactive, 	//Close
	}
	
	private eInteractiveState 	m_State;
	private string[]			m_AnimNames;
	
	void Start()
	{
		m_State = eInteractiveState.Inactive;
		
		m_AnimNames = new string[GetComponent<Animation>().GetClipCount()];
		int index = 0;
		foreach(AnimationState anim in GetComponent<Animation>())
		{
			m_AnimNames[index] = anim.name;
			index++;
		}
	}
	
 	public void TriggerInteraction()
	{
		if(!GetComponent<Animation>().isPlaying)
			{
			Debug.Log("Interactive object");
			switch (m_State) 
			{
			case eInteractiveState.Active:
				GetComponent<Animation>().Play(m_AnimNames[1]);
				m_State = eInteractiveState.Inactive;
				break;
			case eInteractiveState.Inactive:
				GetComponent<Animation>().Play(m_AnimNames[0]);
				m_State = eInteractiveState.Active;
				break;
			default:
			 	break;
			}
		}
	}
	
	public virtual void OnAnimComplete()
	{
		Debug.Log("OnAnimComplete InteractiveObject");
	}
}
