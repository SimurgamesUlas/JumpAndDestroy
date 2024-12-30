using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Karakter : MonoBehaviour
{
    [SerializeField] private float ziplamaGucu;
    Rigidbody2D rb;
    public GameObject kilicSaldirmaYeri;
    Animator anim;
    private int skor;
    bool saldirbilirmi = true;
    bool yasiyor;
    public TextMeshProUGUI skortext;
    Dusman dusman;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        yasiyor = true;
    }

    public void SkorArttir(){
        skor++;
    }
    public int skorOgren(){
        return skor;
    }
    void Update()
    {
       
        skortext.text = skor.ToString();
        if(Input.GetKeyDown("k")){
            Zipla();
        }
        if(Input.GetKeyDown("l")){
            Asagiin();
        }
        if(Input.GetKeyDown("j") && saldirbilirmi){
            Saldir();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col){
       
        if(col.gameObject.CompareTag("Mantar") && yerdeMi()){
            yasiyor = false;
            anim.SetTrigger("olmek");
            Debug.Log("üst");
        }
        if(col.gameObject.CompareTag("Yarasa")){
            yasiyor = false;
            anim.SetTrigger("olmek");
  
        }
        
    }
    public void Zipla(){
        if(yasiyor){
        if(yerdeMi()){
                    rb.velocity = Vector2.zero;
                    rb.AddForce(Vector2.up * ziplamaGucu);
                }
        }
        
    }
    

    public void Asagiin(){
        if(yasiyor){
              if(!yerdeMi()){
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.down * ziplamaGucu);
        }
        }

        
    }

    public void Saldir(){
        if(yasiyor){
        anim.SetTrigger("saldir");
       StartCoroutine(kilicAcKapat());
        }

    }
    IEnumerator kilicAcKapat(){
        saldirbilirmi = false;
        kilicSaldirmaYeri.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        kilicSaldirmaYeri.SetActive(false);
        saldirbilirmi = true;
    }
    
    bool yerdeMi(){

        RaycastHit2D hit = Physics2D.Raycast(transform.position+new Vector3(0,-0.25f,0),Vector2.down,0.1f);
        if(hit.collider){
            return true;
        }else{
            return false;
        }
    }
    private void OnTriggerEnter2D(Collider2D col){
            col.gameObject.GetComponent<Dusman>()?.Ol();
            Zipla();
            Debug.Log("pArent");
        }
    
    public bool yasiyorMu(){
        return yasiyor;
    }
}
