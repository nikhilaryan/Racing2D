using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class AI : MonoBehaviour {
	public Color linecolor;
	private List<Transform> nodes = new List<Transform> ();
	void OnDrawGizmos(){
		Gizmos.color = linecolor;
		Transform[] pathtransform = GetComponentsInChildren<Transform> ();

		nodes = new List<Transform> ();
		for (int i = 0; i < pathtransform.Length; i++) {
			if (pathtransform [i] != transform) {
				nodes.Add (pathtransform [i]);
				print (pathtransform [i]);}
		}
		for (int i = 0; i < nodes.Count; i++) {
			Vector3 currentnode = nodes [i].position;
			Vector3 previousnode = Vector3.zero;
			if (i > 0) {
				previousnode = nodes [i - 1].position;
			} else if (i == 0 && nodes.Count >1)
				previousnode = nodes [nodes.Count - 1].position;
			Gizmos.DrawLine (previousnode, currentnode);
		}
	}

	void update(){

	}
}
