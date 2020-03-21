using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asset.Script
{
    [RequireComponent(typeof(MeshFilter))]
    public class UnityChunkScript : MonoBehaviour
    {

        Mesh mesh;

        Vector3[] vertices;
        int[] triangles;

        public int chunkSize;

        public float blockSize = 0.25f;

        void Start()
        {
            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;


            CreateShape();
            UpdateMesh();
        }

        void Update()
        {
            
        }

        private void UpdateMesh()
        {
            mesh.Clear();

            mesh.vertices = vertices;
            mesh.triangles = triangles;

            mesh.RecalculateNormals();
            gameObject.AddComponent<MeshCollider>();
        }

        private void CreateShape()
        {
            vertices = new Vector3[chunkSize * chunkSize];


            float z = 0;

            for (int i = 0, a = 0; a < chunkSize; a++)
            {
                float x = 0;
                for (int b = 0; b < chunkSize; b++)
                {
                    float y = Mathf.PerlinNoise(x * .3f, z * .3f) * 2f;
                    vertices[i] = new Vector3(x, 0, z);
                    x += blockSize;
                    i++;
                }
                z += blockSize;
            }

            triangles = new int[chunkSize * chunkSize * 6];

            for (int vert = 0, tris = 0, a = 0; a < chunkSize; a++)
            {
                for (int b = 0; b < chunkSize; b++)
                {
                    triangles[tris + 0] = vert + 0;
                    triangles[tris + 1] = vert + chunkSize + 1;
                    triangles[tris + 2] = vert + 1;
                    triangles[tris + 3] = vert + 1;
                    triangles[tris + 4] = vert + chunkSize + 1;
                    triangles[tris + 5] = vert + chunkSize + 2;

                    vert++;
                    tris += 6;

                }
                vert++;
            }
        }

        //private void OnDrawGizmos()
        //{
        //    if (vertices == null) return;

        //    foreach (var item in vertices)
        //    {
        //        Gizmos.DrawSphere(item, .1f);
        //    }
        //}

    }
}
