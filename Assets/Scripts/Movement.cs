using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {
	public float acceleration;
	public float steering;
	private Rigidbody2D rb;
	private float steeringRightAngle;
	public Camera cam;
	public Text tex;
	public Text Lap;
	public  int Laps=0;
	public Text Gameover;
	private float time;private float Starttime;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		Starttime = Time.time;
	}

	void FixedUpdate () {
		time = Time.time-Starttime;
		float milliseconds = 100.0f;
		milliseconds -= Time.deltaTime;
		tex.text = "Time: "+((int)time/60).ToString()+":"+((int)time%60).ToString()+":"+((Time.time-(int)time%60)*100).ToString("f0");//Mathf.RoundToInt (time).ToString () + ":";//+(time-Mathf.RoundToInt(time)).ToString("f2");
		float h = -Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Vector2 speed = transform.up * (v * acceleration);
		rb.AddForce(speed);
		/*float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		print (v);
		rb.AddForce (transform.up*v*acceleration);
		float direction = Vector2.Dot (rb.velocity, rb.GetRelativeVector(Vector2.up));

		rb.rotation += h * steering*(rb.velocity.magnitude/5.0f);*/


		float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));
		if(direction >= 0.0f) {
			rb.rotation += h * steering * (rb.velocity.magnitude / 5.0f);
			//rb.AddTorque((h * steering) * (rb.velocity.magnitude / 10.0f));
		} else {
			rb.rotation -= h * steering * (rb.velocity.magnitude / 5.0f);
			//rb.AddTorque((-h * steering) * (rb.velocity.magnitude / 10.0f));
		}



		if(rb.angularVelocity > 0) {
			steeringRightAngle = -90;
		} else {
			steeringRightAngle = 90;
		}


		Vector2 forward = new Vector2(0.0f, 0.5f);
		Vector2 rightAngleFromForward = Quaternion.AngleAxis(steeringRightAngle, Vector3.forward) * forward;
		Debug.DrawLine((Vector3)rb.position, (Vector3)rb.GetRelativePoint(rightAngleFromForward), Color.green);

		float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(rightAngleFromForward.normalized));

		Vector2 relativeForce = (rightAngleFromForward.normalized * -1.0f) * (driftForce * 10.0f);


		Debug.DrawLine((Vector3)rb.position, (Vector3)rb.GetRelativePoint(relativeForce), Color.red);

		rb.AddForce(rb.GetRelativeVector(relativeForce));
		Vector2 offset = cam.transform.position;
		cam.transform.position = new Vector3 (transform.position.x, transform.position.y, cam.transform.position.z);

	}
	void OnTriggerEnter2D(Collider2D other)
	{

		////if (other.tag== "GameController") {
		//Laps++;
		//Lap.text = "Lap:" + (Laps).ToString () + "/2";

    }
	//}

	}

