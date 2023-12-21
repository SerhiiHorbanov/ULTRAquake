using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] static private string playerTag = "Player";

        public GameObject player;

        public virtual void Awake()
        {
            player = GameObject.FindGameObjectsWithTag(playerTag)[0];
        }
    }
}