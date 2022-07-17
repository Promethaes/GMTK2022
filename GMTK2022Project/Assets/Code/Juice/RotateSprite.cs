using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    // Start is called before the first frame update
    void OnEnable()
    {
        transform.rotation = Quaternion.identity;
        IEnumerator Spin()
        {
            while (true)
            {
                yield return new WaitForEndOfFrame();
                transform.Rotate(Vector3.forward * speed*Time.deltaTime);
            }
        }
        StartCoroutine(Spin());
    }


}
