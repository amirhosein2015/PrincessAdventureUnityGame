using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public GameObject fireBall;
    public Transform fireBallPoint;
 
    public float fireBallSpeed = 600;
    public AudioSource source;
    public AudioClip Fire;

    //------------------------
    public GameObject Ice;
    public Transform IcePoint;
    public float IceSpeed = 600;
    public AudioClip Freeze;

    //---------------------------
    public GameObject snowMagic;
    public Transform SnowMagicPoint;
    //public float SnowSpeed = 600;
    public AudioClip snow;






    public void FireBallAttack()
    {

        source.clip = Fire;
        source.Play();
        GameObject ball = Instantiate(fireBall, fireBallPoint.position, Quaternion.identity);
        ball.GetComponent<Rigidbody>().AddForce(fireBallPoint.forward * fireBallSpeed);

    }


    public void IceAttack()
    {

        source.clip = Freeze;
        source.Play();
        GameObject ball = Instantiate(Ice, IcePoint.position, Quaternion.identity);
        ball.GetComponent<Rigidbody>().AddForce(IcePoint.forward *IceSpeed);

    }

    [System.Obsolete]
   
    public void SnowMagic()
    {

        source.clip = snow;
        source.Play();
        GameObject Snow = Instantiate(snowMagic, SnowMagicPoint.position, rotation: Quaternion.EulerRotation(0, 90f, 0));
        //ball.GetComponent<Rigidbody>().AddForce(SnowMagicPoint.localPosition * SnowSpeed);

    }


}
