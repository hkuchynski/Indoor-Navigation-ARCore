using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.UI;

public class NavigationController : MonoBehaviour
{
    public Transform destination1;
    public Transform destination2;
    public Transform player;
    private NavMeshAgent agent;
    private NavMeshPath path;
    private float elapsed = 0.0f;
    public Dropdown myDropdown;
    public Text text;
    public GameObject cameraTarget;   //SpherePointer
    private bool goStraight = false;
    private bool fiveFeetLeft = false;
    private bool tenFeetLeft = false;
    private bool turnLeft = false;
    private bool goStraight2 = false;
    private bool destinationLeft = false;
    private bool turnLeftStraight = false;
    private bool turnRightFive = false;
    private bool turnRight = false;
    private bool goStraight3 = false;
    private bool destinationTen = false;
    private bool destinationRight = false;


    void Start()
    {
        elapsed = 0.0f;
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        
        if ((myDropdown.value == 1 && elapsed > 1.0f) || text.text == "elevator" && elapsed > 1.0f)
        {
            // modified by Hanna Nekhniadovich on 3/23/19
            if (cameraTarget.transform.position.z >= 7.5f && cameraTarget.transform.position.z <= 7.9f 
                && cameraTarget.transform.position.x >= 9.5f && cameraTarget.transform.position.x <= 11.5f)
            {
                if (!goStraight)
                {
                    FindObjectOfType<AudioManager>().Play("GoStraight");
                    goStraight = true;
                }
            }

            if (cameraTarget.transform.position.z >= 11.5f && cameraTarget.transform.position.z <= 12.0f && cameraTarget.transform.position.x >= 9.5f && cameraTarget.transform.position.x <= 11.5f)
            {
                if (!tenFeetLeft)
                {
                    FindObjectOfType<AudioManager>().Play("TenFeetLeft");
                    tenFeetLeft = true;
                }
            }

            if (cameraTarget.transform.position.z >= 14.2f && cameraTarget.transform.position.z <= 14.8f && cameraTarget.transform.position.x >= 9.5f && cameraTarget.transform.position.x <= 11.5f)
            {
                if (!fiveFeetLeft)
                {
                    FindObjectOfType<AudioManager>().Play("FiveFeetLeft");
                    fiveFeetLeft = true;
                }
            }

            if (cameraTarget.transform.position.z >= 16.5f && cameraTarget.transform.position.z <= 17.1f && cameraTarget.transform.position.x >= 9.5f && cameraTarget.transform.position.x <= 11.5f)
            {
                if (!turnLeft)
                {
                    FindObjectOfType<AudioManager>().Play("TurnLeftNow");
                    turnLeft = true;
                }
            }

            if (cameraTarget.transform.position.x >= 8.5f && cameraTarget.transform.position.x <= 9.0f && cameraTarget.transform.position.z >= 15.0f && cameraTarget.transform.position.z <= 18.0f)
            {
                if (!goStraight2)
                {
                    FindObjectOfType<AudioManager>().Play("GoStraight");
                    goStraight2 = true;
                }
            }

            if (cameraTarget.transform.position.x >= 5.0f && cameraTarget.transform.position.x <= 5.5f && cameraTarget.transform.position.z >= 15.0f && cameraTarget.transform.position.z <= 18.0f)
            {
                if (!destinationLeft)
                {
                    FindObjectOfType<AudioManager>().Play("DestinationOnTheLeft");
                    destinationLeft = true;
                }
            }


            elapsed -= 1.0f;
            agent = player.GetComponent<NavMeshAgent>();
            agent.SetDestination(destination1.position);
            path = new NavMeshPath();
            NavMesh.CalculatePath(transform.position, destination1.position, NavMesh.AllAreas, path);

            for (int i = 0; i < path.corners.Length - 1; i++)
                Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);

            
        }

        if (myDropdown.value == 2 && elapsed > 1.0f || text.text == "lab" && elapsed > 1.0f)
        {
            elapsed -= 1.0f;
            agent = player.GetComponent<NavMeshAgent>();
            agent.SetDestination(destination2.position);
            path = new NavMeshPath();
            NavMesh.CalculatePath(transform.position, destination2.position, NavMesh.AllAreas, path);

            if (cameraTarget.transform.position.x >= 4.0f && cameraTarget.transform.position.x <= 6.0f && cameraTarget.transform.position.z >= 15.0f && cameraTarget.transform.position.z <= 18.0f)
            {
                if (!turnLeftStraight)
                {
                    FindObjectOfType<AudioManager>().Play("TurnLeftGoStraight");
                    turnLeftStraight = true;
                }
            }

            if (cameraTarget.transform.position.x >= 7.0f && cameraTarget.transform.position.x <= 7.7f && cameraTarget.transform.position.z >= 15.0f && cameraTarget.transform.position.z <= 18.0f)
            {
                if (!turnRightFive)
                {
                    FindObjectOfType<AudioManager>().Play("FiveFeetTurnRight");
                    turnRightFive = true;
                }
            }

            if (cameraTarget.transform.position.x >= 9.0f && cameraTarget.transform.position.x <= 9.5f && cameraTarget.transform.position.z >= 15.0f && cameraTarget.transform.position.z <= 18.0f)
            {
                if (!turnRight)
                {
                    FindObjectOfType<AudioManager>().Play("TurnRightNow");
                    turnRight = true;
                }
            }

            if (cameraTarget.transform.position.z >= 16.8f && cameraTarget.transform.position.z <= 17.6f && cameraTarget.transform.position.x >= 9.5f && cameraTarget.transform.position.x <= 11.5f)
            {
                if (!goStraight3)
                {
                    FindObjectOfType<AudioManager>().Play("GoStraight");
                    goStraight3 = true;
                }
            }

            if (cameraTarget.transform.position.z >= 11.0f && cameraTarget.transform.position.z <= 11.7f && cameraTarget.transform.position.x >= 9.5f && cameraTarget.transform.position.x <= 11.5f)
            {
                if (!destinationTen)
                {
                    FindObjectOfType<AudioManager>().Play("DestinationTen");
                    destinationTen = true;
                }
            }

            if (cameraTarget.transform.position.z >= 7.5f && cameraTarget.transform.position.z <= 8.3f && cameraTarget.transform.position.x >= 9.5f && cameraTarget.transform.position.x <= 11.5f)
            {
                if (!destinationRight)
                {
                    FindObjectOfType<AudioManager>().Play("DestinationOnTheRight");
                    destinationRight = true;
                }
            }

            for (int i = 0; i < path.corners.Length - 1; i++)
                Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
        }
    }
}

