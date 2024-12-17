using UnityEngine;
using UnityEngine.AI;

public class FindPath : MonoBehaviour
{
    public Transform target;
    private NavMeshPath path;
    private float elapsed = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        path = new NavMeshPath();
        elapsed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > 1)
        {
            elapsed = 0;
            Vector3 navmeshPoint;
            NavMeshHit hit;
            navmeshPoint = new Vector3(target.position.x , target.position.y, target.position.z );
            if (NavMesh.SamplePosition(navmeshPoint, out hit, 100.0f, NavMesh.AllAreas))
            {
                NavMesh.CalculatePath(transform.position, hit.position, NavMesh.AllAreas, path);
            }
        }
        for (int i = 0; i < path.corners.Length - 1; i++)
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
    }
    public NavMeshPath GetPath()
    {
        return path;
    }
    public Transform GetTarget()
    {
        return target;
    }
}
