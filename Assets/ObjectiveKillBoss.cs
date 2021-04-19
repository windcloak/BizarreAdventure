using UnityEngine;

[RequireComponent(typeof(Objective))]
public class ObjectiveKillBoss : MonoBehaviour
{

    EnemyManager m_EnemyManager;
    Objective m_Objective;

    void Start()
    {
        m_Objective = GetComponent<Objective>();
        DebugUtility.HandleErrorIfNullGetComponent<Objective, ObjectiveKillEnemies>(m_Objective, this, gameObject);

        m_EnemyManager = FindObjectOfType<EnemyManager>();
        DebugUtility.HandleErrorIfNullFindObject<EnemyManager, ObjectiveKillEnemies>(m_EnemyManager, this);
        m_EnemyManager.onRemoveEnemy += OnKillEnemy;

        // set a title and description specific for this type of objective, if it hasn't one
        if (string.IsNullOrEmpty(m_Objective.title))
            m_Objective.title = "Eliminate the boss";

        if (string.IsNullOrEmpty(m_Objective.description))
            m_Objective.description = "Defeat the boss";

    }

    void OnKillEnemy(EnemyController enemy, int remaining)
    {
        if (m_Objective.isCompleted)
            return;

        if (enemy.CompareTag("Boss"))
        {
            m_Objective.CompleteObjective(string.Empty, remaining.ToString(), "Objective complete : " + m_Objective.title);
        }

    }

}
