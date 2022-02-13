using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float maxY;
    public float minY;

    private bool sitting;
    public GameObject cameraTarget;
    public float cameraTargetMoveAheadDistance;
    public float cameraTargetMoveAheadSpeed;

    public float minimumSitTime;
    private float timeSinceSitting;

    private LivesManager livesManager;
    private ScoreManager scoreManager;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        livesManager = Globals.livesManager;
        scoreManager = Globals.scoreManager;
        if (scoreManager != null)
        {
            scoreManager.player = this;
        }
        sitting = false;
        timeSinceSitting = 0;
        Time.timeScale = 1;

        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // first check if we're sitting, as that nullifies a lot of other inputs;
        if (Input.GetButtonDown("Jump"))
        {
            if (sitting)
            {
                sitting = false;
                StandUp();
            }
            else
            {
                sitting = true;
                timeSinceSitting = 0;
                Sit();
            }
        }
        timeSinceSitting += Time.deltaTime;

        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(inputX, inputY, 0);
        float magnitude = movement.magnitude;
        if (sitting && timeSinceSitting > minimumSitTime && magnitude > 0)
        {
            sitting = false;
            StandUp();
        }
        if (magnitude > 1)
        {
            movement = movement / movement.magnitude;
        }

        if (!sitting && movement.magnitude > 0)
        {
            Vector3 newPosition = transform.position + (movement * speed * Time.deltaTime);
            if (newPosition.y > maxY)
            {
                newPosition.y = maxY;
            }
            else if (newPosition.y < minY)
            {
                newPosition.y = minY;
            }
            transform.SetPositionAndRotation(newPosition, Quaternion.identity);

        }

        if (cameraTarget != null)
        {
            if (movement.x > 0 && !sitting)
            {
                float localXTarget = Mathf.Lerp(cameraTarget.transform.localPosition.x, cameraTargetMoveAheadDistance, cameraTargetMoveAheadSpeed * Time.deltaTime);
                cameraTarget.transform.localPosition = new Vector3(localXTarget, 0, 0);
            }
            else
            {
                float localXTarget = Mathf.Lerp(cameraTarget.transform.localPosition.x, 0, cameraTargetMoveAheadSpeed * Time.deltaTime);
                cameraTarget.transform.localPosition = new Vector3(localXTarget, 0, 0);
            }
        }
    }

    private void LoseLife()
    {
        Debug.Log("[PlayerController::LoseLife] lose life");
        if (livesManager != null)
        {
            livesManager.LoseLife();
        }
    }

    public void React(ScaryThing scaryThing)
    {
        Debug.Log("[PlayerController::React] reacting to ScaryThing " + scaryThing.transform.parent.name);
        if (scoreManager != null)
        {
            switch (scaryThing.scareType)
            {
                case ScaryThingType.BigBlackDog:
                    scoreManager.Penalise(scaryThing.scareType);
                    Bark();
                    LoseLife();
                    break;
                case ScaryThingType.Jogger:
                case ScaryThingType.RubbishCollector:
                    if (sitting)
                    {
                        ;
                    }
                    else
                    {
                        scoreManager.Penalise(scaryThing.scareType);
                        Bark();
                        LoseLife();
                    }
                    break;
            }
        }
    }

    private void Sit()
    {
        if(animator != null)
        {
            animator.SetTrigger("sit");
        }
    }

    private void StandUp()
    {
        if(animator != null)
        {
            animator.SetTrigger("stand");
        }
    }

    private void Bark()
    {
        Debug.Log("bark");
        if (animator != null)
        {
            animator.SetTrigger("bark");
        }
    }

    private void Chomp()
    {
        if(animator != null)
        {
            animator.SetTrigger("eat");
        }
    }

}
