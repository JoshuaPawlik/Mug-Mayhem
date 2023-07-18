using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject regularHand;
    private GameObject punchHand;

    public float punchDistance = 1f;
    public float punchSpeed = 8f;

    private bool isPunching = false;

    void Start()
    {
        regularHand = transform.Find("Hand/mug-hand").gameObject;
        punchHand = transform.Find("Hand/punch-hand").gameObject;

        punchHand.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isPunching)
        {
            StartCoroutine(PerformPunch());
        }
    }

    IEnumerator PerformPunch()
    {
        isPunching = true;

        regularHand.SetActive(false);
        punchHand.SetActive(true);

        Vector3 initialPosition = punchHand.transform.localPosition;
        Vector3 targetPosition = initialPosition - Vector3.right * punchDistance;

        while (Vector3.Distance(punchHand.transform.localPosition, targetPosition) > 0.01f)
        {
            punchHand.transform.localPosition = Vector3.MoveTowards(punchHand.transform.localPosition, targetPosition, Time.deltaTime * punchSpeed);
            yield return null;
        }

        punchHand.transform.localPosition = initialPosition;

        SwitchToRegularHand(); // Switch back to the regular hand as soon as the punch animation is done

        isPunching = false; // Reset the flag after a punch is completed
    }


    void SwitchToRegularHand()
    {
        punchHand.SetActive(false);
        regularHand.SetActive(true);
    }
}
