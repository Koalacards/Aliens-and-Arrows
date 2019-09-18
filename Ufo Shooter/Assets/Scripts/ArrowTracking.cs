using UnityEngine;
using System.Collections;

public class ArrowTracking : MonoBehaviour {

	public float maxStretch = 2.0f;
	public LineRenderer bowtop;
	public LineRenderer bowbottom;
	private Rigidbody2D rb2d;
	private SpringJoint2D spring;
	bool clickedOn;
	private Ray raytomouse;
	private float maxStretchSquared;
	private Ray bowmidtoprojectile;
	private Vector2 bowmidposition;
	private Transform bow;
	private Vector2 preVelocity;


	void Awake()
	{
		spring = FindObjectOfType<SpringJoint2D> ();
		rb2d = FindObjectOfType<Rigidbody2D> ();



	}

	void Start () {
		LineRendererSetup ();
		bow = spring.connectedBody.transform;
		raytomouse = new Ray (bow.position, Vector3.zero);
		maxStretchSquared = maxStretch * maxStretch;
		bowmidposition = ((bowtop.transform.position + bowbottom.transform.position) / 2);
		bowmidtoprojectile = new Ray(bowmidposition, Vector3.zero);

	}
	

	void Update () {

		Quaternion arrowrot = transform.localRotation;
		arrowrot.eulerAngles = new Vector3 (0, 0, transform.rotation.z);
		arrowrot.eulerAngles = raytomouse.direction;

		if (clickedOn) {
			Dragging ();
		}

		if (spring != null) {
			if (!rb2d.isKinematic && preVelocity.sqrMagnitude > rb2d.velocity.sqrMagnitude) {
				StartCoroutine (Revitalize ());
				Destroy (spring);
				rb2d.velocity = preVelocity;
			}

			if (!clickedOn) {
				preVelocity = rb2d.velocity;
			}

			LineRendererUpdate ();
		} else {
			bowtop.enabled = false;
			bowbottom.enabled = false;
		}
	}

	void LineRendererSetup()
	{
		bowtop.SetPosition (0, bowtop.transform.position);
		bowbottom.SetPosition (0, bowbottom.transform.position);

		bowtop.sortingLayerName = "Bow";
		bowbottom.sortingLayerName = "Bow";

		bowtop.sortingOrder = 1;
		bowbottom.sortingOrder = 1;
	}

	void OnMouseDown()
	{
		spring.enabled = false;
		clickedOn = true;
	}

	void OnMouseUp()
	{
		spring.enabled = true;
		rb2d.isKinematic = false;
		clickedOn = false;

	}

	void Dragging()
	{
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 bowToMouse = mouseWorldPoint - bow.position;
		if (bowToMouse.sqrMagnitude > maxStretchSquared) {
			raytomouse.direction = bowToMouse;
			mouseWorldPoint = raytomouse.GetPoint (maxStretch);
		}
		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;
	}

	void LineRendererUpdate()
	{
		Vector2 bowtoarrow = transform.position - bow.transform.position;
		bowmidtoprojectile.direction = bowtoarrow;
		Vector3 holdpoint = bowmidtoprojectile.GetPoint (bowtoarrow.magnitude);
		bowtop.SetPosition (1, holdpoint);
		bowbottom.SetPosition (1, holdpoint);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "OutOfBounds") {
			Reset ();
		}
	}

	void Reset()
	{
		this.transform.position = new Vector3 (-6.152f, .205f, 0);
		//Quaternion rot = transform.localRotation;
		//rot.eulerAngles = new Vector3 (0, 0, 205f);
		//transform.localRotation = rot;
		rb2d.isKinematic = true;
		spring.enabled = true;

		bowtop.enabled = true;
		bowbottom.enabled = true;
	}

	IEnumerator Revitalize()
	{
		yield return new WaitForSecondsRealtime (.01f);
		Instantiate (spring);
	}
}
