// Copyright 2022 Niantic, Inc. All Rights Reserved.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niantic.ARVoyage.SnowballToss
{
    /// <summary>
    /// A collider just behind a snowring's open center,
    /// triggered when a snowball is thrown through the snowring
    /// </summary>
    public class SnowringThruRing : MonoBehaviour
    {
        public Snowring snowring;
        public GameObject Mark;

        public GameObject cube;
        public Material StartMat;
        public Material EndMat;
        Renderer rdr;


        void Start()
        {
            // material 바꾸기    
            rdr = cube.GetComponent<MeshRenderer>();
            rdr.material = StartMat;
        }

        private void OnTriggerEnter(Collider collider)
        {
            // if (snowring != null)
            // {
            //     Snowball sb = collider.GetComponentInParent<Snowball>();
            //     sb.destroyBall();

            //     // Debug.LogError(collider.transform.parent.parent);
            //     // Destroy(collider.transform.parent.parent);
            //     snowring.Success();
            // }
        }

        private void OnCollisionEnter(Collision collision){
            Debug.LogWarning("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
            Debug.LogWarning(collision);

            ContactPoint contact = collision.contacts[0];

            if (snowring != null)
            {


                // 공 없애기
                Snowball sb = collision.gameObject.GetComponentInParent<Snowball>();
                sb.destroyBall();

                // material 바꾸기
                rdr.material = EndMat;

                // 마크 생성하기
                GameObject go = Instantiate(Mark, contact.point, Quaternion.identity);
                go.transform.parent = this.transform;
                go.transform.rotation = this.transform.rotation;




                // Debug.LogError(collider.transform.parent.parent);
                // Destroy(collider.transform.parent.parent);
                snowring.Success();
            }
        }


    }
}

