using UnityEngine;

public class NavMeshMoveTest : MonoBehaviour
{
    public FindPath pathFinder;
    public Vector3[] path;
    public Vector3 nextMoveLocation = Vector3.zero;

    public Rigidbody rb;
    public float moveForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdatePath();
        Vector3 moveDirection = FindMoveDirection();
        rb.AddForce(moveDirection* moveForce, ForceMode.Force);
    }

    public void UpdatePath()
    {
        if (pathFinder != null)
        {
            path = new Vector3[pathFinder.GetPath().corners.Length];
            for (int i = 0; i < pathFinder.GetPath().corners.Length; i++)
            {
                path[i] = pathFinder.GetPath().corners[i];
            }
            if (path.Length >= 2)
            {
                nextMoveLocation = FindNextMoveLocation();
            }
        }
    }
    public Vector3 FindNextMoveLocation()
    {
        float lowestDistance = Mathf.Infinity;
        int cureentPointIndex = 0;
        for (int i = 0; i < path.Length; i++)
        {
            float distance = Vector3.Distance(path[i], transform.position);
            if (distance < lowestDistance)
            {
                lowestDistance = distance;

                cureentPointIndex = i;
                Debug.Log(i);
            }
        }
        Debug.Log(cureentPointIndex);
        if (cureentPointIndex+1 > path.Length-1)
        {
            return Vector3.zero;
        }
        return path[cureentPointIndex + 1];
    }
    public Vector3 FindMoveDirection()
    {
        if (nextMoveLocation != new Vector3(0, 0, 0))
        {
            Vector3 moveDirection = (nextMoveLocation - transform.position).normalized;
            return moveDirection;
        }
        else
        {
            return new Vector3(0, 0, 0);
        }
    }
}
