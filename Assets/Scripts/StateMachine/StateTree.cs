using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "stateMachine/stateTree")]
public class StateTree : ScriptableObject 
{
	private State		m_CurrentState;
	[SerializeField] 
	private State    	m_DefaultState;
	[SerializeField] 
	private State[]  	m_states;

	public State CurrentState
	{
		get {return m_CurrentState;	}
		set{ m_CurrentState = value;}
	}
	public void InitStateTree(StateController controller)
	{
		if (m_states.Length > 0 && m_DefaultState == null)
			m_CurrentState = m_states [0];
		else
			m_CurrentState = m_DefaultState;
		m_CurrentState.InitState (controller);
	}

	public void ExitStateTree(StateController controller)
	{
		m_CurrentState.ExitState (controller);
	}


	public void UpdateStateTree(StateController controller)
	{
		m_CurrentState.UpdateState (controller);
		for (int i = 0; i < m_CurrentState._transitions.Length; i++) 
		{
			if (m_CurrentState._transitions [i]._condition.canTransit (controller))
				controller.TransitState (m_CurrentState._transitions [i]._transitTo);

		}
	}


	public void OnStateTreeCollisionEnter(Collision other,StateController controller)
	{
		m_CurrentState.OnStateCollisionEnter (other, controller);
	}

	public void OnStateTreeCollisionExit(Collision other,StateController controller)
	{
		m_CurrentState.OnStateCollisionExit (other, controller);
	}

	public void OnStateTreeTriggerEnter(Collider other,StateController controller)
	{
		m_CurrentState.OnStateTriggerEnter (other, controller);
	}

	public void OnStateTreeTriggerExit(Collider other,StateController controller)
	{
		m_CurrentState.OnStateTriggerExit (other, controller);
	}




}
