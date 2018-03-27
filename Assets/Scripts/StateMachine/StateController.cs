using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour 
{
	public State _DefaultState;
	private State m_CurrentState;

	public virtual void OnEnable () 
	{
		
		m_CurrentState = _DefaultState;
		m_CurrentState.InitState (this);
	}

	public virtual void Update () 
	{
		m_CurrentState.UpdateState (this);
		for (int i = 0; i < m_CurrentState._transitions.Length; i++) 
		{
			if (m_CurrentState._transitions [i]._condition.canTransit (this))
				TransitState (m_CurrentState._transitions [i]._transitTo);

		}
	}

	public virtual void OnCollisionEnter(Collision collision)
	{
		m_CurrentState.OnStateCollisionEnter (collision,this);
	}

	public virtual void OnCollisionExit(Collision collision)
	{
		m_CurrentState.OnStateCollisionExit (collision,this);
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		m_CurrentState.OnStateTriggerEnter (other,this);
	}

	public virtual void OnTriggerExit(Collider other)
	{
		m_CurrentState.OnStateTriggerExit (other,this);
	}

	public virtual void  TransitState(State nextState)
	{
		if (nextState == null) 
		{
			this.enabled = false;
			return;
		}
		m_CurrentState.ExitState(this);
		m_CurrentState = nextState;
		m_CurrentState.InitState (this);
	}


}
