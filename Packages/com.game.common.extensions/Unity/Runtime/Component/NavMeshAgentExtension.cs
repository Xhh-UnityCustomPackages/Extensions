using UnityEngine.AI;

namespace Game
{
    public static class NavMeshAgentExtension
    {
        public static bool IsArrive(this NavMeshAgent agent)
        {
            if (!agent.isActiveAndEnabled || !agent.isOnNavMesh) return false;
            return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
        }
    }
}