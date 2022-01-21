using UnityEngine;

public class AU_Body : MonoBehaviour
{
    [SerializeField] SpriteRenderer bodySprite;

    public void SetColor(Color newColor)
    {
        bodySprite.color = newColor;
    }

    private void OnEnable()
    {
        if (AU_PlayerController.allBodies != null)
        {
            AU_PlayerController.allBodies.Add(transform);
        }
    }

    public void Report()
    {
        Debug.Log("Reported");
        AU_PlayerController.allBodies.RemoveAt(AU_PlayerController.allBodies.Count - 1);
        Destroy(gameObject);
    }
}
