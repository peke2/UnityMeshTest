using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(MeshFilter))]

public class Triangle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Mesh mesh = new Mesh();
		mesh.vertices = new Vector3[]
		{
			new Vector3(0f, 0.5774f, 0f),
			new Vector3(0.5f, -0.2886f, 0f),
			new Vector3(-0.5f, -0.2886f, 0f),
		};
		mesh.colors = new Color[]
		{
			new Color(1f, 0f, 0f, 1f),
			new Color(0f, 1f, 0f, 1f),
			new Color(0f, 0f, 1f, 1f),
		};

		mesh.uv = new Vector2[]
		{
			new Vector2(0f, 0f),
			new Vector2(1f, 0f),
			new Vector2(1f, 1f),
		};

		mesh.triangles = new int[] { 0, 1, 2 };

		GetComponent<MeshFilter>().mesh = mesh;
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
