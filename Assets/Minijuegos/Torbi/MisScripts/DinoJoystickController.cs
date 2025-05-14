using UnityEngine;

public class DinoJoystickController : MonoBehaviour
{
    public FixedJoystick joystick;
    public float moveSpeed = 12f;

    private Animator animator;

    private void Start()
    {
        // Buscar el Animator en este objeto o en los hijos
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }

    private void Update()
    {
        // Obtener la direcci�n del joystick
        Vector3 direction = new Vector3(joystick.Horizontal, 0, joystick.Vertical);

        // Calcular la velocidad del movimiento (de 0 a 1)
        float movementMagnitude = Mathf.Clamp01(direction.magnitude);

        // Actualizar animaci�n si hay Animator
        if (animator != null && animator.HasParameter("Speed"))
        {
            animator.SetFloat("Speed", movementMagnitude * 2f);

        }

        // Si se est� moviendo, rotar y trasladar
        if (movementMagnitude > 0.2f)
        {
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}

// Extensi�n para comprobar si el Animator tiene un par�metro espec�fico
public static class AnimatorExtensions
{
    public static bool HasParameter(this Animator animator, string paramName)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName)
                return true;
        }
        return false;
    }
}

