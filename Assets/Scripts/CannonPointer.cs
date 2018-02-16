using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace HoloToolkit.Unity.InputModule
{

    public class CannonPointer : MonoBehaviour, IEventSystemHandler
    {

        private Transform cannon;
        private AudioSource shotSound;

        public Transform dummy;
        public Transform target;
        public Rigidbody bullet;

        public static float firingSpeed;
        public static float firingAngle;

        //Fires a bullet in the direction thew barrel is facing
        public void Fire()
        {
            shotSound.Play();
            Rigidbody firedBullet = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
            firedBullet.velocity = -firedBullet.transform.forward * firingSpeed;
            Destroy(firedBullet.gameObject, 5.0f);
        }

        // Initialization
        void Start()
        {
            shotSound = GetComponent<AudioSource>();
            cannon = GetComponent<Transform>();
            firingSpeed = 5.0f;
            firingAngle = 30.0f;
        }

        public void OnHoldCompleted(HoldEventData eventData)
        {
            Fire();
        }

        // Points the cannon at the target on the y-rotation
        void Update()
        {
            dummy.LookAt(target);
            cannon.eulerAngles = new Vector3(firingAngle, dummy.eulerAngles.y + 180, 0);

            
            if (Input.GetButton("Fire1"))
            {
                Fire();
            }
            
        }
        

    }
}