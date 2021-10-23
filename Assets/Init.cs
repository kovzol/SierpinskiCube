using UnityEngine;
using System.Collections.Generic;

public class Init : MonoBehaviour
{
    public int N = 3;
    public int seedx = 0;
    public int seedy = 0;

    List<GameObject> cubes = new List<GameObject>();

    public static string Int32ToString(int value, int toBase)
    {
        string result = string.Empty;
        do
        {
            result = "0123456789ABCDEF"[value % toBase] + result;
            value /= toBase;
        }
        while (value > 0);
        return result;
    }

    public void Start()
    {
        int M = 9;
        int O = 2;

        M = 27;
        O = 3;

        // M = 81;
        // O = 4;

        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        Mesh mesh = new Mesh();

        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < M; j++)
            {
                for (int k = 0; k < M; k++)
                {
                    string I = Int32ToString(i, 3);
                    string J = Int32ToString(j, 3);
                    string K = Int32ToString(k, 3);
                    while (I.Length < O)
                        I = "0" + I;
                    while (J.Length < O)
                        J = "0" + J;
                    while (K.Length < O)
                        K = "0" + K;
                    bool p = true;

                    for (int o = 0; o < O; o++)
                    {
                        int ones = 0;
                        if (I.Substring(o, 1).Equals("1"))
                            ones++;
                        if (J.Substring(o, 1).Equals("1"))
                            ones++;
                        if (K.Substring(o, 1).Equals("1"))
                            ones++;
                        if (ones >= 2)
                            p = false;
                    }

                    if (p)
                    {
                        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.transform.position = new Vector3(i, k, j);
                        Color c = Color.white;
                        cube.GetComponent<Renderer>().material.color = c;
                        cubes.Add(cube);
                    }
                }
            }
        }
    }
}