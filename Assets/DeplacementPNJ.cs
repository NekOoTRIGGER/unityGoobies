using UnityEngine;
using UnityEngine.AI;

public class DeplacementPNJ : MonoBehaviour
{

    public Transform cible; // PNJ1
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false; // On d�sactive au d�but
    }

    public void AllerVersCible()
    {
        agent.enabled = true;
        if (cible != null)
        {
            agent.SetDestination(cible.position);
        }
    }
}
