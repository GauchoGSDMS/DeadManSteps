using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStates 
{
	void Idle(Animator anim);
	void Run(Animator anim);
	void Crouch(Animator anim);
	void Jump(Animator anim);
	void Falling(Animator anim);
	void Dead(Animator anim);
}
