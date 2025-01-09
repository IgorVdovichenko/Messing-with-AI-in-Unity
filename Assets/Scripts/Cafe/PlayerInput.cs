using System;
using Cafe.AI;
using UnityEngine;

namespace Cafe
{
    public class PlayerInput : MonoBehaviour
    {
        private IPlayer player;

        private void Awake()
        {
            player = GetComponent<Player>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                player.Sit();
            }
        }
    }
}