﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGunner : EnemyCtrl 
{
  
    //public float AttackDistance = 10.0f;

    //public float FollowDistance = 20.0f;

    

    public AudioClip ShootSound = null;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public Transform target;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public SoundFx soundFX;

    void Update()
    {
        NpcAction();//what npc will do
        EnemyDetection();
        PlayerLocation = GameObject.Find("Player").transform.position;//position of player use in can see player
    }

    void NpcAction()
    {
        if (base.navMeshAgent.enabled)
        {
            float dist = Vector3.Distance(Player.transform.position, this.transform.position);

            bool shoot = false;
            bool patrol = false;
            bool follow = base.CanSeePlayer(); 

            if (follow)
            {//follow player
                EnemyDetection();

                if (fireCountdown <= 0f)
                {
                    Shoot();
                    soundFX.ShootSound();
                    fireCountdown = 1f / fireRate;
                    //put shooting wvent here
                    //fireCountdown = 1f / 1;
                }
                fireCountdown -= Time.deltaTime;
                /*navMeshAgent.SetDestination(Player.transform.position);
                float random = Random.Range(0.0f, 1.0f);*/

            }

            patrol = !follow && patrolPoints.Length > 0;

            if ((!follow) && !patrol)
            {
                navMeshAgent.SetDestination(transform.position);
                anim.SetInteger("Stage", 2);
            }

            if (patrol)
            {
                if (!navMeshAgent.pathPending && navMeshAgent.
                    remainingDistance < 0.5f)
                {
                    MoveToNextPatrolPoint();
                    anim.SetInteger("Stage", 1);
                }
                if (navMeshAgent.remainingDistance < 0.01f)
                {
                    anim.SetInteger("Stage", 0);
                    LookAtTarget();
                }
            }

        }
    }
    void Shoot()
    {
        Debug.Log("Shoot");
        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, 
                                firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(target);
        Destroy(bulletGo, 3f);

    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(firePoint.position, .3f);
    }*/
}
