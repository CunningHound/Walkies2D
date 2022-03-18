using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float maxY;
    public float minY;

    public bool sitting { get; private set; }

    public GameObject cameraTarget;
    public float cameraTargetMoveAheadDistance;
    public float cameraTargetMoveAheadSpeed;

    public float minimumSitTime;
    private float timeSinceSitting;

    public ScoreManager scoreManager;
    public Animator animator { get; private set; }

    public GameObject audioSourcePrefab;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        sitting = false;
        timeSinceSitting = 0;
        Time.timeScale = 1;
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

        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        if(sitting && timeSinceSitting < minimumSitTime)
        {
            timeSinceSitting += Time.deltaTime;
            inputX = 0;
            inputY = 0;
        }

        Vector3 movement = new Vector3(inputX, inputY, 0);
        float magnitude = movement.magnitude;
        if (sitting && magnitude > 0)
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
            if(animator != null)
            {
                if (inputX == 0)
                {
                    animator.SetInteger("xDirection", 0);
                }
                else
                {
                    animator.SetInteger("xDirection", inputX > 0 ? 1 : -1);
                }
            }
            transform.SetPositionAndRotation(newPosition, Quaternion.identity);
            if(scoreManager != null)
            {
                scoreManager.setDistanceInLevel((int)gameObject.transform.position.x);
            }
        }

        if (cameraTarget != null)
        {
            if (movement.x > 0)
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

    public void PlayClip(AudioClip clip)
    {
        if (audioSourcePrefab != null)
        {
            GameObject source = Instantiate(audioSourcePrefab);

            AudioSource audioSource = source.GetComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.Play();
            Destroy(source, 2f);
        }
    }

}
