using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSelf : MonoBehaviour {

    public float _DelayTime;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(_DelayTime);

        Destroy(gameObject);
    }
}
