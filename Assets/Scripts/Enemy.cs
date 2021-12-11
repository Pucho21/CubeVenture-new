using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints;
    public float movementSpeed;
    private Vector3 targetPosition;
    private int wavepointIndex = 0;
    bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        targetPosition = waypoints[wavepointIndex].position;
        transform.position = targetPosition;
        int difficulty;
        if (UserInfoHolder.instance != null && UserInfoHolder.instance.selectedLevel != null)
            difficulty = UserInfoHolder.instance.selectedLevel.difficulty;
        else
        {
            difficulty = 2;
        }

        switch(difficulty){
            case 1:
                movementSpeed = 3f;
                break;
            case 2:
                movementSpeed = 5f;
                break;
            case 3:
                movementSpeed = 7f;
                break;
        }
        GetNextWaypoint();
        
    }
    void Update()
    {
        if (isDead)
                return;

        Vector3 dir = targetPosition - transform.position;
        transform.rotation = Quaternion.LookRotation(dir);
        transform.Translate(dir.normalized * movementSpeed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex == waypoints.Length-1)
        {
            wavepointIndex = 0;
        }
        else
            wavepointIndex++;

        targetPosition = waypoints[wavepointIndex].position;

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(gameObject.tag))
        {
            Debug.Log("Slime squished");
            GetComponent<BoxCollider>().enabled = false;
            isDead = true;
            transform.GetChild(0).GetComponent<Animator>().Play("SlimeDie");
            GameManager.instance.EnemyKilled();
            Destroy(gameObject,2f);
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(MakeEnemyUnkillable());
            FadeScreen.instance.FadeOutScreen();
            other.GetComponent<RollCube>().PlayerKilled();

            SpawnPoint.instance.PlayerRespawn();
            Debug.Log("Player killed");
        }
        else if (other.gameObject.CompareTag("Mirror"))
        {
            other.GetComponent<MovableObject>().RespawnBlock();
        }
    }

    private IEnumerator MakeEnemyUnkillable()
    {
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        GetComponent<BoxCollider>().enabled = true;
    }



}
