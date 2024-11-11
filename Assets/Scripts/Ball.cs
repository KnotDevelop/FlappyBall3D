using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance;
    [SerializeField] Rigidbody rb;
    [SerializeField] float jumpForce = 2.5f;
    [SerializeField] float gravityForce = -10f;
    [SerializeField] float speed = 0.65f;
    [SerializeField] int difficultCurve = 0;
    Vector3 currentVelocity;
    bool isDead = false;
    [SerializeField] float startRotationSpeed = 2000;
    [SerializeField] float rotationSpeed;
    private void Awake()
    {
        Instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.gameObject.name == "CheckFromTop")
            {
                other.gameObject.GetComponentInParent<Donut>().FromTop();
            }
            if (other.gameObject.name == "ScoreCheck")
            {
                other.gameObject.GetComponentInParent<Donut>().GetScore();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null) 
        {
            if (collision.collider.name == "Donut")
            {
                collision.collider.GetComponentInParent<Donut>().HitDonut();
            }
            if (collision.collider.name == "Ground")
            {
                if (isDead) return;
                    Dead();
            }
        }
    }

    void Dead()
    {
        isDead = true;
        AudioManager.instance.Play_Dead();
        UIManager.Instance.OpenFinishPanel();
        AudioManager.instance.Stop_Background();
        AudioManager.instance.Play_GameOver();
    }

    void Jump()
    {
        rb.velocity = new Vector3(0, jumpForce, 0);
        AudioManager.instance.Play_Jump();
        rotationSpeed = startRotationSpeed;
        //Debug.Log("Jump");
    }

    private void Update()
    {
        if (TimeManager.instance.isPuase) return;
        Physics.gravity = new Vector3(0, gravityForce, 0);
        //rb.velocity = new Vector3(speed * Time.deltaTime, rb.velocity.y, 0);
        transform.Translate(speed * Time.deltaTime * TimeManager.instance.GetTimeScale(), 0, 0);
        //if (Input.touchCount > 0)
        if (Input.GetMouseButtonDown(0))
        {
            //Touch _touch = Input.GetTouch(0);
            //if (_touch.phase == TouchPhase.Began)
            //{
                Jump();
            //}
        }
        transform.GetChild(0).rotation *= Quaternion.Euler(Time.deltaTime*rotationSpeed * TimeManager.instance.GetTimeScale(), 0, 0);
        rotationSpeed -= Time.deltaTime * TimeManager.instance.GetTimeScale() * startRotationSpeed;
    }
    public IEnumerator DifficultCurve()
    {
        while (true)
        {
            difficultCurve++;
            jumpForce = 2.5f + (difficultCurve * 0.01f * 1);
            gravityForce = (10 * -1) - (difficultCurve * 0.01f * 4f);
            Physics.gravity = new Vector3(0, gravityForce, 0);
            yield return new WaitForSeconds(1f);
        }
    }
    public void SaveVelocity() 
    {
        currentVelocity = rb.velocity;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
    }
    public IEnumerator SetCurrentVelocity()
    {
        yield return new WaitForSeconds(0.2f);
        rb.velocity = currentVelocity;
        rb.useGravity = true;
    }

}
