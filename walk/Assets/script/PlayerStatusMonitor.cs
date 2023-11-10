using UnityEngine;
using TMPro;

public class PlayerStatusMonitor : MonoBehaviour
{
    public TMP_Text statusText;
    public SoundManager soundManager;

    private Transform targetTransform;
    private Vector3 previousPosition;
    private bool isMoving;
    private int frameCounter;

    private void Start()
    {
        GameObject playerGameObject = GameObject.Find("player");
        if (playerGameObject != null)
        {
            SetTarget(playerGameObject.transform);
        }
        else
        {
            Debug.LogError("Failed to find player object in the scene!");
        }
    }

    public void SetTarget(Transform target)
    {
        targetTransform = target;
        previousPosition = target.position;
    }

    private void Update()
    {
        frameCounter++;

        if (frameCounter >= 10)
        {
            frameCounter = 0;

            if (targetTransform != null)
            {
                if (targetTransform.position != previousPosition && !isMoving)
                {
                    isMoving = true;
                    statusText.text = "Moving";
                    soundManager.PlaySound();
                }
                else if (targetTransform.position == previousPosition && isMoving)
                {
                    isMoving = false;
                    statusText.text = "Static";
                    soundManager.StopSound();
                }

                previousPosition = targetTransform.position;
            }
        }
    }
}