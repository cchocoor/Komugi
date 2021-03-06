// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Animation)]
	[Tooltip("Sets the Blend Weight of an Animation. Check Every Frame to update the weight continuosly, e.g., if you're manipulating a variable that controls the weight.")]
	public class SetAnimationWeight : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(Animation))]
		public FsmOwnerDefault gameObject;
		[RequiredField]
		[UIHint(UIHint.Animation)]
		public FsmString animName;
		public FsmFloat weight = 1f;
		public bool everyFrame;

		public override void Reset()
		{
			gameObject = null;
			animName = null;
			weight = 1f;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			DoSetAnimationWeight(gameObject.OwnerOption == OwnerDefaultOption.UseOwner ? Owner : gameObject.GameObject.Value);
			
			if (!everyFrame)
				Finish();		
		}

		public override void OnUpdate()
		{
			DoSetAnimationWeight(gameObject.OwnerOption == OwnerDefaultOption.UseOwner ? Owner : gameObject.GameObject.Value);
		}

		void DoSetAnimationWeight(GameObject go)
		{
			if (go == null) return;

			if (go.GetComponent<Animation>() == null)
			{
				LogWarning("Missing animation component: " + go.name);
				return;
			}

			AnimationState anim = go.GetComponent<Animation>()[animName.Value];

			if (anim == null)
			{
				LogWarning("Missing animation: " + animName.Value);
				return;
			}

			anim.weight = weight.Value;
		}
	}
}