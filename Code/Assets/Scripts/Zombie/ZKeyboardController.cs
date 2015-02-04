using UnityEngine;

public class ZKeyboardController : MonoBehaviour
{
	public KeyCode DropLadder = KeyCode.W, TieShoeLaces = KeyCode.E;
	
	public GameObject Target;
	private BoxCollider2D TargetCollider;
	private Vector2 originalCenter, originalSize;
	public TimerRun timer;
	private bool isCrouched = false;
	
	private bool IsWalking = true;
	
	void Start()
	{
		if (Target == null)
			throw new MissingComponentException();
		
		TargetCollider = Target.GetComponent<BoxCollider2D>();
		if (TargetCollider == null)
			throw new MissingComponentException();
		originalCenter = TargetCollider.center;
		originalSize = TargetCollider.size;
		
		Target.animation.Play("stand");
	}
	
	void Update()
	{
		bool W = false;
		bool E = false;

		CheckKeyPresses (out W, out E);

		if (timer.InstructionsTimeLeft > 0)
		{
			return; //wait
		}
		
		if (IsWalking)
		{
			Vector3 newPosition = Target.transform.position;
			newPosition.x += 2 * Time.deltaTime;
			Target.transform.position = newPosition;
		}

		Debug.Log (isCrouched);

		if ((DropLadder == KeyCode.W && W) || (DropLadder == KeyCode.E && E) )
		{
			GameObject ladder2 = GameObject.Find("Ladder2");
			
			if (ladder2 != null)
			{
				Rigidbody2D rigidBody = ladder2.GetComponent<Rigidbody2D>();
				
				if (rigidBody == null)
					throw new MissingComponentException();
				
				rigidBody.gravityScale = 1f;
			}
		}
		else
		if ( ( (TieShoeLaces == KeyCode.W &&W ) || (TieShoeLaces == KeyCode.E && E)) && !isCrouched  )
		{
			isCrouched = true;


			Target.animation.Play("tie");
			this.IsWalking = false;
			
			Vector2 newCenter = TargetCollider.center;
			newCenter.y = 309.8044f;
			TargetCollider.center = newCenter;
			
			Vector2 newSize = TargetCollider.size;
			newSize.y = 646.4517f;
			TargetCollider.size = newSize;
			
		}
		else if ((TieShoeLaces == KeyCode.W && !W ) || (TieShoeLaces == KeyCode.E && !E))
		{
			isCrouched = false;

			Target.animation.Play("walk");
			this.IsWalking = transform;
			
			TargetCollider.center = originalCenter;
			TargetCollider.size = originalSize;
		}
	}

	void CheckKeyPresses(out bool W, out bool E)
	{
		W = Input.GetKey(KeyCode.W);
		E = Input.GetKey(KeyCode.E);
		
		
		foreach (Touch touch in Input.touches) 
		{
			if ( touch.phase != TouchPhase.Canceled && touch.phase != TouchPhase.Ended)
			{
				var pixelVector = touch.position;
				
				var viewPortClick = Camera.main.ScreenToViewportPoint(pixelVector);
				if (viewPortClick.x < 0.25f)
				{
					W = true;
				}
				else if (viewPortClick.x > 0.75f)
				{
					E = true;
				}
			}
		}
		
	}
}