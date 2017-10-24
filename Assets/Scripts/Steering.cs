using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour {
	private List<Transform> nodes = new List<Transform> ();
	private int currentnode = 1;
	public Transform AI;
	public Vector3 Relativepoint;
	public int maxsteer;
	public Rigidbody2D rb;
	public Vector2 towardsnext;
	public int Acceleration;
	void Start(){
		
		Transform[] pathtransform = AI.GetComponentsInChildren<Transform> ();
		rb= gameObject.GetComponent<Rigidbody2D> ();
		nodes = new List<Transform> ();
	for (int i = 1; i < pathtransform.Length; i++) {
		if (pathtransform [i] != transform) {
			nodes.Add (pathtransform [i]);

			print (pathtransform [i]);}
	}// Use this for initialization
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Applysteer ();
		Drive ();
		waypoint ();
	}
	void Applysteer(){
//		Relativepoint = transform.InverseTransformPoint (nodes [currentnode].position);
//		float steer = (Relativepoint.x / Relativepoint.magnitude) * maxsteer;
//		gameObject.GetComponent<Rigidbody2D> ().MoveRotation( steer);
		//Vector3	Target =Vector3.Lerp(nodes[currentnode+1].position-nodes[currentnode+1].right,nodes[currentnode+1].position -nodes[currentnode+1].right,Random.value);
		Vector3 Target= nodes[currentnode].position;
		towardsnext= Target-transform.position;
		float targetRot = Vector2.Angle (Vector2.right,towardsnext);
		if (towardsnext.y < 0.0f) {
			targetRot = -targetRot;}
		float rot = Mathf.MoveTowardsAngle (transform.localEulerAngles.z, targetRot, 4.0f);
		transform.eulerAngles = new Vector3 (0.0f, 0.0f, rot);

	}
	void Drive(){
   	float Velocity= rb.velocity.magnitude;
		rb.velocity = new Vector2(towardsnext.x/towardsnext.magnitude,towardsnext.y/towardsnext.magnitude)*12.0f;
		 
		print (rb.velocity);
		//rb.AddForce (towardsnext*10.0f);

		//Velocity += Acceleration;

}
	void waypoint ()
	{
		if (Vector3.Distance (transform.position, nodes [currentnode].position)<0.5f) {
			if (currentnode == nodes.Count - 1)
				currentnode = 0;
			else
				currentnode++;
		}
	}
}

