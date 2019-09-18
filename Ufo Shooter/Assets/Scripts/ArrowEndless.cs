using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEndless : MonoBehaviour {
	public SpringJoint2D sp;
	public bool clickedOn;
	Vector3 mousetoworld;
	private Rigidbody2D rb2d;
	private Ray2D arrowtobow;
	float adj;
	float hyp;
	public LineRenderer topstring;
	public LineRenderer bottomstring;
	public Transform midpoint;
	public bool springgone;
	public Transform bound1;
	public Transform bound2;
	public Vector3 mousepos;
	
	public GameObject Bow;
	public GameObject Arrow;
	public bool clickEnabled;
	public float arrowtobowatrest;
	public float arrowtooriginalarrow;
	public float angle;
	public GameObject particle;
	public Vector2 arrowStartingPos;
	public float arrowStartingRot;

	public float arrowmultiplier;

	public Vector2 bowStartingPos;
	public float bowStartingRot;
	public float bowmultiplier;

	public float changeInPosY;

	public float pastPoint;
	//public GameObject ArrowAtRest;
	Animator anim;
	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.bodyType = RigidbodyType2D.Static;
		transform.position = arrowStartingPos;
		clickedOn = false;
		transform.rotation = Quaternion.Euler (0, 0, arrowStartingRot);
		Bow.transform.rotation = Quaternion.Euler(0,0,bowStartingRot);
		Bow.transform.position = bowStartingPos;
		LineRendererSetup ();
		springgone = false;
		clickEnabled = true;
		anim = GetComponent<Animator> ();
		anim.SetBool ("RegArrowActive", true);
		anim.SetBool ("FireArrowActive", false);
	}
	void Start () {
		sp = GetComponent<SpringJoint2D> ();
		particle.gameObject.SetActive(false);
	}
	void Update () {
		LineRendererSetup ();
		mousepos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if(0 == PlayerPrefs.GetInt("Pause")){
			if(0 == PlayerPrefs.GetInt("Lose")){
				if (clickEnabled == true) {
					if (bound2.transform.position.x >= mousepos.x && mousepos.x >= bound1.transform.position.x) {
						if (bound2.transform.position.y >= mousepos.y && mousepos.y >= bound1.transform.position.y) {
							if (Input.GetMouseButton (0)) {
								clickedOn = true;
								Drag ();
								rb2d.bodyType = RigidbodyType2D.Static;
								sp.enabled = false;
							}
						}
					}
				}
			}
		}
		if (Input.GetMouseButtonUp (0) && clickedOn == true) {
			clickedOn = false;
			rb2d.bodyType = RigidbodyType2D.Dynamic;
			sp.enabled = true;
		}
		if (transform.position.x >= pastPoint && clickedOn == false) {
			sp.enabled = false;
			springgone = true;
			clickEnabled = false;

		}
		if (springgone == false) {
			LineRendererUpdate ();
		}
		if (springgone == true) {
			LineRendererUpdate2 ();
		}
		//if (transform.position.x <= -6.98f) {
		//topstring.material = redmat;
		//bottomstring.material = redmat;
		//}
		//if (transform.position.x >= -6.98f) {
		//topstring.material = whitemat;
		//bottomstring.material = whitemat;
		//}
	}

	public void Drag()
	{
		mousetoworld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousetoworld.z = 0f;
		transform.position = mousetoworld;
		changeInPosY = transform.position.y - arrowStartingPos.y;
		transform.rotation = Quaternion.Euler(0,0, arrowStartingRot - (changeInPosY * arrowmultiplier));
		Bow.transform.rotation = Quaternion.Euler(0,0, bowStartingRot - (changeInPosY * bowmultiplier));
	
	}
	void FixedUpdate()
	{
		if (springgone == true) {
			Vector3 velocity = rb2d.velocity;
			float angle2 = Mathf.Atan2 (velocity.y, velocity.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle2, Vector3.forward);
			particle.gameObject.SetActive(true);
		}
		if (springgone == false) {
			//arrowtobowatrest = Vector3.Distance (ArrowAtRest.gameObject.transform.position, bow.gameObject.transform.position);
			//arrowtooriginalarrow = Vector3.Distance (transform.position, ArrowAtRest.gameObject.transform.position);
			//angle = -1 * Mathf.Atan2 (arrowtooriginalarrow,arrowtobowatrest) * Mathf.Rad2Deg;
			//transform.rotation = Quaternion.AngleAxis (angle, new Vector3(0,0,.012f));
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Respawn")||other.CompareTag("useless")) {
			ArrowReset ();
		}
	}
	public void LineRendererSetup()
	{
		topstring.SetPosition (0, topstring.transform.position);
		bottomstring.SetPosition (0, bottomstring.transform.position);
		topstring.sortingLayerName = "Bow";
		bottomstring.sortingLayerName = "Bow";
		topstring.sortingOrder = 1;
		bottomstring.sortingOrder = 1;
	}
	public void LineRendererUpdate()
	{
		topstring.SetPosition (1, transform.position);
		bottomstring.SetPosition (1, transform.position);
	}
	public void LineRendererUpdate2()
	{
		topstring.SetPosition (1, midpoint.transform.position);
		bottomstring.SetPosition (1, midpoint.transform.position);
	}

	public void ArrowReset()
	{
		if (this.gameObject.tag == "arrow") {
			StartCoroutine (respawnArrow (0));
		}
		if (this.gameObject.tag == "firearrow") {
			transform.position = new Vector2 (1000, 1000);
			StartCoroutine (respawnArrow (.6f));
		}
		if (this.gameObject.tag == "icearrow") {
			transform.position = new Vector2 (1000, 1000);
			StartCoroutine (respawnArrow (.4f));
		}
		if (this.gameObject.tag == "poisonarrow") {
			transform.position = new Vector2 (1000, 1000);
			StartCoroutine (respawnArrow (1f));
		}
		if (this.gameObject.tag == "bombarrow") {
			transform.position = new Vector2 (1000, 1000);
			StartCoroutine (respawnArrow (1f));
		}
	}

	public void spawnRegularArrow()
	{
		anim.SetBool ("RegArrowActive", true);
		anim.SetBool ("FireArrowActive", false);
		anim.SetBool ("IceArrowActive", false);
		anim.SetBool ("PoisonArrowActive", false);
		anim.SetBool ("BombArrowActive", false);
		this.gameObject.tag = "arrow";
	}
	public void spawnFireArrow()
	{
		anim.SetBool ("FireArrowActive", true);
		anim.SetBool ("RegArrowActive", false);
		anim.SetBool ("IceArrowActive", false);
		anim.SetBool ("PoisonArrowActive", false);
		anim.SetBool ("BombArrowActive", false);
		this.gameObject.tag = "firearrow";
	}
	public void spawnIceArrow()
	{
		anim.SetBool ("FireArrowActive", false);
		anim.SetBool ("RegArrowActive", false);
		anim.SetBool ("IceArrowActive", true);
		anim.SetBool ("PoisonArrowActive", false);
		anim.SetBool ("BombArrowActive", false);
		this.gameObject.tag = "icearrow";
	}
	public void spawnPoisonArrow()
	{
		anim.SetBool ("FireArrowActive", false);
		anim.SetBool ("RegArrowActive", false);
		anim.SetBool ("IceArrowActive", false);
		anim.SetBool ("PoisonArrowActive", true);
		anim.SetBool ("BombArrowActive", false);
		this.gameObject.tag = "poisonarrow";
	}

	public void spawnBombArrow()
	{
		anim.SetBool ("FireArrowActive", false);
		anim.SetBool ("RegArrowActive", false);
		anim.SetBool ("IceArrowActive", false);
		anim.SetBool ("PoisonArrowActive", false);
		anim.SetBool ("BombArrowActive", true);
		this.gameObject.tag = "bombarrow";
	}

	public IEnumerator respawnArrow(float buffertime)
	{
		yield return new WaitForSecondsRealtime (buffertime);
		transform.position = arrowStartingPos;
		transform.rotation = Quaternion.Euler (0, 0, arrowStartingRot);
		Bow.transform.rotation = Quaternion.Euler(0,0,bowStartingRot);
		Bow.transform.position = bowStartingPos;
		sp.enabled = true;
		rb2d.bodyType = RigidbodyType2D.Static;
		clickEnabled = true;
		springgone = false;
		particle.gameObject.SetActive(false);
	}
}
