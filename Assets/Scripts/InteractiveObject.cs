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
		
		m_AnimNames = new string[animation.GetClipCount()];
		int index = 0;
		foreach(AnimationState anim in animation)
		{
			m_AnimNames[index] = anim.name;
			index++;
		}
	}
	
 	public void TriggerInteraction()
	{
		if(!animation.isPlaying)
			{
			Debug.Log("Interactive object");
			switch (m_State) 
			{
			case eInteractiveState.Active:
				animation.Play(m_AnimNames[1]);
				m_State = eInteractiveState.Inactive;
				break;
			case eInteractiveState.Inactive:
				animation.Play(m_AnimNames[0]);
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
