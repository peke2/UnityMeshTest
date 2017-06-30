using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(MeshFilter))]

public class Skin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Mesh mesh = new Mesh();

		int num_blocks = 6;
		int num_vertices = ((num_blocks * 4)+2) * 4;
		Vector3[] vertices = new Vector3[num_vertices];
		Vector3[] normals = new Vector3[num_vertices];
		Color[] colors = new Color[num_vertices];

		Vector3[] baseVertices = new Vector3[]{
			new Vector3(0.5f, 0.5f, 0),
			new Vector3(0.5f, -0.5f, 0),
			new Vector3(-0.5f, -0.5f, 0),
			new Vector3(-0.5f, 0.5f, 0),
		};

		int num_quads = 24 + 2;
		int num_triangles = num_quads * 2;
		int index_count = 0;
		int[] triangles = new int[num_triangles * 3];
		int index;
		Vector3 v0, v1, n;

		for(int i=0; i<4; i++)
		{
			for(int j=0; j<num_blocks; j++)
			{
				index = i*num_blocks*4 + j * 4;
				vertices[index + 0] = new Vector3(baseVertices[i].x, baseVertices[i].y, j);
				vertices[index + 1] = new Vector3(baseVertices[i].x, baseVertices[i].y, j+1);
				vertices[index + 2] = new Vector3(baseVertices[(i+1)%4].x, baseVertices[(i+1)%4].y, j);
				vertices[index + 3] = new Vector3(baseVertices[(i+1)%4].x, baseVertices[(i+1)%4].y, j+1);

				colors[index + 0] = new Color(0.75f, 0.75f, 0.75f, 1f);
				colors[index + 1] = new Color(0.75f, 0.75f, 0.75f, 1f);
				colors[index + 2] = new Color(0.75f, 0.75f, 0.75f, 1f);
				colors[index + 3] = new Color(0.75f, 0.75f, 0.75f, 1f);

				triangles[index_count++] = index + 0;
				triangles[index_count++] = index + 1;
				triangles[index_count++] = index + 2;

				v0 = vertices[index+1] - vertices[index+0];
				v1 = vertices[index+2] - vertices[index+1];
				n = Vector3.Cross(v0, v1);
				normals[index+0] = n;
				normals[index+1] = n;
				normals[index+2] = n;
				normals[index+3] = n;
				
				triangles[index_count++] = index + 3;
				triangles[index_count++] = index + 2;
				triangles[index_count++] = index + 1;

				v0 = vertices[index+3] - vertices[index+2];
				v1 = vertices[index+2] - vertices[index+1];
				n = Vector3.Cross(v0, v1);
				normals[index+0] = n;
				normals[index+1] = n;
				normals[index+2] = n;
				normals[index+3] = n;
			}
		}

		index = num_blocks*4*4;
		vertices[index + 0] = new Vector3(baseVertices[0].x, baseVertices[0].y, 0);
		vertices[index + 1] = new Vector3(baseVertices[1].x, baseVertices[1].y, 0);
		vertices[index + 2] = new Vector3(baseVertices[3].x, baseVertices[3].y, 0);
		vertices[index + 3] = new Vector3(baseVertices[2].x, baseVertices[2].y, 0);
		colors[index + 0] = new Color(0.75f, 0.75f, 0.75f, 1f);
		colors[index + 1] = new Color(0.75f, 0.75f, 0.75f, 1f);
		colors[index + 2] = new Color(0.75f, 0.75f, 0.75f, 1f);
		colors[index + 3] = new Color(0.75f, 0.75f, 0.75f, 1f);

		v0 = vertices[index+1] - vertices[index+0];
		v1 = vertices[index+2] - vertices[index+1];
		n = Vector3.Cross(v0, v1);
		normals[index + 0] = n;
		normals[index + 1] = n;
		normals[index + 2] = n;
		normals[index + 3] = n;

		triangles[index_count++] = index + 0;
		triangles[index_count++] = index + 1;
		triangles[index_count++] = index + 2;
		triangles[index_count++] = index + 3;
		triangles[index_count++] = index + 2;
		triangles[index_count++] = index + 1;
		index += 4;

		vertices[index + 0] = new Vector3(baseVertices[0].x, baseVertices[0].y, 6);
		vertices[index + 1] = new Vector3(baseVertices[1].x, baseVertices[1].y, 6);
		vertices[index + 2] = new Vector3(baseVertices[3].x, baseVertices[3].y, 6);
		vertices[index + 3] = new Vector3(baseVertices[2].x, baseVertices[2].y, 6);
		colors[index + 0] = new Color(0.75f, 0.75f, 0.75f, 1f);
		colors[index + 1] = new Color(0.75f, 0.75f, 0.75f, 1f);
		colors[index + 2] = new Color(0.75f, 0.75f, 0.75f, 1f);
		colors[index + 3] = new Color(0.75f, 0.75f, 0.75f, 1f);

		v0 = vertices[index+2] - vertices[index+0];
		v1 = vertices[index+1] - vertices[index+2];
		n = Vector3.Cross(v0, v1);
		normals[index + 0] = n;
		normals[index + 1] = n;
		normals[index + 2] = n;
		normals[index + 3] = n;

		triangles[index_count++] = index + 0;
		triangles[index_count++] = index + 2;
		triangles[index_count++] = index + 1;
		triangles[index_count++] = index + 3;
		triangles[index_count++] = index + 1;
		triangles[index_count++] = index + 2;

		mesh.vertices = vertices;
		mesh.colors = colors;

		mesh.triangles = triangles;

		GetComponent<MeshFilter>().mesh = mesh;
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
