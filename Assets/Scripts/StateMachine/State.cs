using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : ScriptableObject 
{
	public Transit[] _transitions;
	public virtual void InitState(StateController controller){}
	public virtual void UpdateState(StateController controller){}
	public virtual void ExitState(StateController controller){}
	public virtual void OnStateCollisionEnter(Collision collision,StateController controller){}
	public virtual void OnStateCollisionExit(Collision collision,StateController controller){}
	public virtual void OnStateTriggerEnter(Collider other,StateController controller){}
	public virtual void OnStateTriggerExit(Collider other,StateController controller){}

}
