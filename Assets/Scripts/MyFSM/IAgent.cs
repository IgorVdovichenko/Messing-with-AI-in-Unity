using UnityEngine;

namespace MyFSM
{
    public interface IAgent
    {
        /// <summary>
        /// Moves agent to destination
        /// </summary>
        /// <param name="position"></param>
        void MoveTo(Vector3 position);
        
        /// <summary>
        /// Stops agent at current position
        /// </summary>
        void Stop();
        
        /// <summary>
        /// Check if agent reached destination
        /// </summary>
        /// <returns></returns>
        bool AtDestination();
    }
}