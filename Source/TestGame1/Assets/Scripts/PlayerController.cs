using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 2.0f;

	[HideInInspector] public Animator animator;
	[HideInInspector] public CharacterController controller;

	float moveX, moveY;
	Vector3 velocity;

	void Start()
	{
		animator = GetComponentInChildren<Animator>();
		controller = GetComponent<CharacterController>();
	}

	private void Update()
	{
		if (controller.isGrounded && velocity.y < 0)
			velocity.y = 0f;
		velocity.y -= 9.81f / 10f;
		velocity.y = Mathf.Clamp(velocity.y, -1f, 1f);

		// pos
		Vector3 pos = new Vector3(1, 0, -1) * Input.GetAxis("Horizontal") +
			new Vector3(1, 0, 1) * Input.GetAxis("Vertical");
		controller.Move((pos.normalized + velocity) * Time.deltaTime * speed);

		// rot
		if (pos != Vector3.zero && animator != null)
		{
			Quaternion lookRot = Quaternion.LookRotation(pos);
			float rotationSpeed = Time.deltaTime * 15f;
			animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, lookRot, rotationSpeed);
		}

		// animation
		if (animator != null && !animator.IsInTransition(0))
			SetAnimation(pos.magnitude > 0.1f ? "run" : "idle");
	}

	void SetAnimation(string name)
	{
		AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
		if (!state.IsName(name))
			animator.CrossFadeInFixedTime(name, 0.25f);
	}
}
