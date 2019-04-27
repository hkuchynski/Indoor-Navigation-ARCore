using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(LineRenderer))]
public class PathDebugger : MonoBehaviour
{

    [SerializeField]
    private NavMeshAgent agent;

    private LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Sprites/Default")) { color = Color.green };
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
        line.startColor = Color.green;
        line.endColor = Color.green;

    }

    // Update is called once per frame
    void Update()
    {
        if (agent.hasPath)
        {
            line.positionCount = agent.path.corners.Length;
            line.SetPositions(agent.path.corners);
            line.enabled = true;
        }
        else
        {
            line.enabled = false;
        }
    }
}
