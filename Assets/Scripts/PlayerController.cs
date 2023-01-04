using UnityEngine.InputSystem;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float xRange = 10.0f;
    public GameObject projectilePrefab;

    private float horizontalInput;

    private void OnMove(InputValue movementValue)
    {
        float movementFloat = movementValue.Get<float>();
        horizontalInput = movementFloat;
    }

    private void FixedUpdate()
    {
        /*on store la valeur dans une variabe xRange pour la position négative (à gauche) = -xRange*/
        if (transform.position.x < -xRange)
        {
            /*la position sur l'axe x est defini par la variable xRange ce qui met une limitation de deplacement au joueur*/
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        /*pour la position positif (à droite) on retire le moin de la variable*/
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        /*on ajoute de la vitesse sur les movements du player par la variable horizontalInput*/
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
*//*envoie de projetiles par le joueur*//*
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }*/
    }

    void OnFire()
    {
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }
}
