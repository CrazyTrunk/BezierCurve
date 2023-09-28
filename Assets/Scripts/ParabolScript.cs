using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParabolScript : MonoBehaviour
{
    public AnimationCurve curve;
    [SerializeField]
    public float duration = 4.0f;
    [SerializeField]
    public float heightY = 3.0f;
    [SerializeField] Vector3 start;
    [SerializeField] Vector2 end;
    // Start is called before the first frame update
    private void Start()
    {
        start = transform.position;
        StartCoroutine(Curve(start, end));
    }
    public IEnumerator Curve(Vector3 start, Vector2 target)
    {
        float timePassed = 0f;
        Vector2 end = target;
        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            float linearT = timePassed / duration;

            float heightT = curve.Evaluate(linearT);

            float height = Mathf.Lerp(0f, heightY, heightT);

            transform.position = Vector2.Lerp(start, end, linearT) + new Vector2(0f, height);
            yield return null;
        }
    }
}
