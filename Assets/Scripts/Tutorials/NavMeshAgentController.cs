using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    private float maxX = 10;
    private float maxZ = 10;
    private float timeBetweenMoves = 12;
    private string _name;

    private void Start()
    {
        _name = this.gameObject.name;
        if (_name == "Ally")
        {
            InvokeRepeating("MoveAlly", 5.0f, timeBetweenMoves);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _name == "Enemy")
        {
            Ray ray =  cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

           if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

    void MoveAlly()
    {        
        float x = Random.Range(-maxX, maxX);
        float y = transform.position.y;
        float z = Random.Range(-maxZ, maxZ);
        Vector3 point = new Vector3(x, y, z);
        agent.SetDestination(point); 
    }
}
