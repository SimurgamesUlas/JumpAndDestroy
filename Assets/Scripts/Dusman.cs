using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman : MonoBehaviour
{
    [SerializeField] private float hareketHizi;
    bool yasiyor;
    Animator anim;
    GameObject oyuncu;
    SpriteRenderer sr;
    void Start()
    {
        oyuncu = GameObject.Find("Karakter");
        anim = this.GetComponent<Animator>();
        sr = this.GetComponent<SpriteRenderer>();
        yasiyor = true;
    }
    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Kilic")){
            Ol();
        }
        if(col.gameObject.CompareTag("Duvar")){
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        if(yasiyor){
            if(oyuncu.GetComponent<Karakter>().yasiyorMu()){
                İleriGit();
            }else{
                GeriGit();
            }
           
        }
    }
    public void Ol(){
        anim.SetTrigger("oldur");
        oyuncu.GetComponent<Karakter>().SkorArttir();
        yasiyor = false;
        Destroy(this.gameObject,0.3f); 
    }
    void İleriGit(){
        sr.flipX = true;
        transform.Translate(-hareketHizi * Time.deltaTime,0,0);
    }
    void GeriGit(){
        sr.flipX = false;
        transform.Translate(hareketHizi * Time.deltaTime,0,0);
    }
    
}
