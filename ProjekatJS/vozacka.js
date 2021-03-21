import { Evidencija } from "./evidencija.js";
import { Kategorija } from "./kategorija.js";

export class Vozacka
{
    constructor(id, ime, prezime, brojDozvole, jmbg,  grad)//, kategorije)
    {
        this.id = id;
        this.ime = ime;
        this.prezime = prezime;
        this.brojDozvole = brojDozvole;
        this.grad = grad;
        this.kategorije = [];
        this.miniContainer = null;
        this.jmbg = jmbg;
        this.red = null;
    }

    crtajRed(red)
    {
        
        var data = null;
        this.red = red;
        var label = ["Ime", "Prezime", "Broj_dozvole", "JMBG", "Grad", "Kategorija"];
        var info = [this.ime, this.prezime, this.brojDozvole, this.jmbg, this.grad, ""];
        info.forEach((element, index) => {    
                data = document.createElement("td");
                data.innerHTML = element;
                data.className = label[index];
                red.appendChild(data);
        });
        
        let dugme = document.createElement("button");
        dugme.innerHTML = "Obrisi";
    }
    izmeniRed(vozac)
    {
        var informacije = this.red.childNodes;
        informacije[0].innerHTML = vozac.ime;
        informacije[1].innerHTML = vozac.prezime;
        informacije[2].innerHTML = vozac.brojDozvole;
        informacije[4].innerHTML = vozac.grad;
        //informacije[5].innerHTML = vozac.kategorije.ime;

        this.ime = vozac.ime;
        this.prezime = vozac.prezime;
        this.brojDozvole = vozac.brojDozvole;
        this.grad = vozac.grad;
        //this.kategorije = vozac.kategorije;

        fetch("https://localhost:5001/Evidencija/IzmeniVozaca",{
            headers:{
                "Content-Type":"application/json"
            },
            method:"PUT",
            body:JSON.stringify(
                {
                    "id": this.id,
                    "imeVozaca": this.ime,
                    "prezimeVozaca": this.prezime,
                    "brojDozvole": this.brojDozvole,
                    "grad": this.grad,
                    "jmbg": this.jmbg
                }
            )
        });
    }
    getJMBG()
    {
        return this.jmbg;
    }
    retRed()
    {
        return this.red;
    }
    getIme()
    {
        return this.ime;
    }
    dodajKategoriju(kategorija, id)
    {
        var kateg = new Kategorija(id, kategorija); 
        this.kategorije.push(kateg);
    }
    printKategoriju()//Metoda koja vraca kategorije u obliku string MINT
    {
        var pom = [];
        this.kategorije.forEach(el =>{
            pom.push(el.ime);
        });
        pom.toString();
        return pom;
    }
    osvezi()
    {
        var informacije = this.red.childNodes;
        informacije[0].innerHTML = this.ime;
        informacije[1].innerHTML = this.prezime;
        informacije[2].innerHTML = this.brojDozvole;
        informacije[4].innerHTML = this.grad;
        informacije[5].innerHTML = this.printKategoriju();
    }
    kategorijaPush(kateg)
    {   
        this.kategorije = kateg;
        console.log("Svi elementi vozaca: ");
        console.log("ID: ",this.id);
        console.log("IME: ", this.ime);
        console.log("PREZIME: ", this.prezime);
        console.log("BROJ DOZVOLE: ", this.brojDozvole);
        console.log("GRAD: ", this.grad);
        console.log("KATEGORIJE: ", this.kategorije);

        this.kategorije.forEach(el =>{
            console.log(this.id);
            el.ubaciUbazu(this.id);
        })
    }
    getId()
    {
        for( var i = 0; i < 100000; i++)
        {

        }
        fetch("https://localhost:5001/Evidencija/GetID/" + this.jmbg).then(d => {
            d.json().then(data3 =>{
                data3.forEach(voz =>{
                     this.setID(voz.id);
                     //console.log(this.id);
                });
            });
        });
    } 
    setID(id)
    {
        this.id = id;
        //console.log(this.id);
    }
    izbrisiKategoriju(kateg)
    {
        kateg.forEach(el1 =>{
            this.kategorije.forEach((el2, index) =>{
                if(el1.ime === el2.ime)
                {
                    el2.brisiIzBaze();
                    this.kategorije.splice(index,1);
                }
            });
        });
    }
}