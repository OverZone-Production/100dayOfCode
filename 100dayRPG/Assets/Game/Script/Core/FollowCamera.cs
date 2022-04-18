using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheRPG.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] float sensitivity = 10f;
        [SerializeField] float minFov = 15f;
        [SerializeField] float maxFov = 90f;


        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = target.position;
            float fov = Camera.main.fieldOfView;
            fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            Camera.main.fieldOfView = fov;
        }
    }
}

