using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {


		//set the background to scroll by using an offset and repeating material
		MeshRenderer mr = GetComponent<MeshRenderer>();

		Material mat = mr.material;

		Vector2 offset = mat.mainTextureOffset;

		offset.y += Time.deltaTime * .15f;

		mat.mainTextureOffset = offset;
	
	}
}
