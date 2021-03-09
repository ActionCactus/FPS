using UnityEngine;
using FPS.Player.Data;
using System.Collections.Generic;

namespace FPS.Infrastructure
{
    public class ComponentData : MonoBehaviour
    {
        /// <todo>
        /// Make this generic, or have a base ObjectState enum.
        ///
        /// If generic (the best way), we'd need to find a clean instantiation interface.
        /// </todo>
        private Dictionary<PlayerMovementStates, bool> activeStates;

        public ComponentData()
        {
            this.activeStates = new Dictionary<PlayerMovementStates, bool>();
        }

        public void SetActive(PlayerMovementStates state)
        {
            this.activeStates[state] = true;
        }

        public void SetInactive(PlayerMovementStates state)
        {
            this.activeStates[state] = false;
        }

        public bool IsActive(PlayerMovementStates state)
        {
            if (!this.activeStates.ContainsKey(state))
            {
                return false;
            }

            return this.activeStates[state];
        }
    }
}