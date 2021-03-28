import { Kategorija } from "./kategorija.js";
import {Vozacka} from "./vozacka.js"

export class Evidencija
{
    constructor(id, ime)
    {
        this.id = id;
        this.imeDrzave = ime;
        this.vozaci = [];
        this.container = null;
        this.tabela = null;
    }

    crtaj(host)
    {
        if(!host)
        {
            throw new Error("Host ne postoji");
        }

        this.container = document.createElement("div");
        this.container.className = "Kontejner";
        host.appendChild(this.container);

        let infoDiv = document.createElement("div");
        infoDiv.className = "infoDiv";
        this.container.appendChild(infoDiv);

        var drzava = document.createElement("label");
        drzava.innerHTML = this.imeDrzave;
        drzava.className = "imeDrzave";
        infoDiv.appendChild(drzava);

        let evDiv = document.createElement("div");
        evDiv.className = "evDiv";
        this.container.appendChild(evDiv);

        let tabela = document.createElement("table");
        tabela.className = "listaVozaca";
        this.tabela = tabela;
        evDiv.appendChild(tabela);


        this.crtajFormu(infoDiv);
        this.crtajEvidencijaFormu();
    }

    crtajFormu(host)
    {
        let labele = ["Ime", "Prezime", "Broj_dozvole", "JMBG", "Grad", "Kategorija"];
        let elLabel = null;
        let inputEl = null;
        labele.forEach((element,index) =>
        {

            elLabel = document.createElement("label");
            elLabel.innerHTML = element;
            elLabel.className = "Labele";
            host.appendChild(elLabel);

            if(index < 5)
            {
                inputEl = document.createElement("input");
                inputEl.className = element;
                
                if(index === 3 || index === 2)
                {
                    inputEl.type = "number";
                }
    
                host.appendChild(inputEl);
            }

        })

        labele = ["AM", "A1", "A2", "A", "B1", "B", "BE", "C1" ,"C1E" , "C", "CE", "D1", "D1E", "D", "DE", "F", "M"];

        let everyButton  = null; 
        let checkDiv = null; 

        let checkboxDiv = document.createElement("div");
        checkboxDiv.className = "checkboxDiv";

        labele.forEach(element =>
        {
                checkDiv = document.createElement("div");
                checkDiv.className = "checkDiv";

                everyButton = document.createElement("input");
                everyButton.type = "checkbox";
                everyButton.className = "cheks" + this.id;
                everyButton.value = element;
                
                inputEl = document.createElement("label");
                inputEl.innerHTML = element;

                checkDiv.appendChild(everyButton);
                checkDiv.appendChild(inputEl);

                checkboxDiv.appendChild(checkDiv);
        });

        host.appendChild(checkboxDiv);

        const buttonAdd = document.createElement("button");
        buttonAdd.innerHTML = "Dodaj";
        buttonAdd.className = "Dugme";
        host.appendChild(buttonAdd);

        const buttonEdit = document.createElement("button");
        buttonEdit.innerHTML = "Izmeni";
        buttonEdit.className = "Dugme";
        host.appendChild(buttonEdit);

        const buttonAddCategory = document.createElement("button");
        buttonAddCategory.innerHTML = "Dodaj kategorije";
        buttonAddCategory.className = "Dugme";
        host.appendChild(buttonAddCategory);

        const buttonDelCategory = document.createElement("button");
        buttonDelCategory.innerHTML = "Izbrisi kategorije";
        buttonDelCategory.className = "Dugme";
        host.appendChild(buttonDelCategory);

        buttonEdit.onclick =(ev) =>
        {
            var tempFlag = true;
            var jmbg1 = this.container.querySelector(".JMBG").value;
            if(vozac === false || this.vozaci.length === 0)  
            {
                alert("Ne postoji vozac sa datim maticnim brojem");
            }
            else
            {
                var vozac = this.createVozacTemp(jmbg1);
                this.vozaci.forEach(element =>
                    {
                        if(element.getJMBG() === jmbg1)
                        {
                            element.izmeniRed(vozac);
                            tempFlag = false;
                        }
                    })
            }
            if(tempFlag === true)
            {
                alert("Ne postoji vozac sa datim maticnim brojem");
            }
        }

        buttonAdd.onclick =(ev) =>
        {
            let flag = false;
            var jmbg2 = this.container.querySelector(".JMBG").value;
            this.vozaci.forEach(element =>
                {
                    if(jmbg2 === element.getJMBG())
                    {
                        flag = true;
                    }
                });

            if(flag === true)
            {
                alert("Vec postoji vozac sa postojecim JMBG-om");
            }
            else if(this.validateJMBG(jmbg2) === false)
            {
                alert("Nije validan JMBG");
            }
            else if(this.validateJMBG(jmbg2) && flag === false)
            {
                var vozac = this.createVozacTemp(jmbg2);
                this.vozaci.push(vozac);
                this.cratjRedEvidencije(vozac);
                this.dodajUbazu();
            }
        }

        buttonAddCategory.onclick =(ev) =>
        {
            var kateg = this.cheksCategory();
            var jmbg1 = this.container.querySelector(".JMBG").value;
            this.vozaci.forEach(el =>{
                if(jmbg1 === el.jmbg)
                {
                    el.kategorijaPush(kateg);
                    this.crtajVozace();
                }
            });
        }

        buttonDelCategory.onclick =(ev) =>
        {
            var kateg = this.cheksCategory();
            var jmbg1 = this.container.querySelector(".JMBG").value;
            if(jmbg1 === "")
            {
                alert("Nije unet JMBG");
            }
            else
            {
                this.vozaci.forEach(el =>{
                    if(jmbg1 === el.jmbg)
                    {
                        el.izbrisiKategoriju(kateg);
                        this.crtajVozace();
                    }
                });
            } 
        }
    }

    
    cheksCategory()
    {
        var checks = document.getElementsByClassName("cheks" + this.id);
            var kateg = [];
            for( let i = 0; i < 17; i++)
            {
                if(checks[i].checked === true)
                {
                    kateg.push(new Kategorija(null, checks[i].value));
                }
            }

        return kateg;
    }

    createVozacTemp(jmbg)
    {
        var ime = this.container.querySelector(".Ime").value;

        var prezime = this.container.querySelector(".Prezime").value;

        var brDozvole = this.container.querySelector(".Broj_dozvole").value;

        var grad = this.container.querySelector(".Grad").value;

        var kateg = this.cheksCategory();
        var vozac = new Vozacka(null, ime, prezime, brDozvole, jmbg, grad);
        vozac.kategorije = kateg;
        return vozac;
    }

    cratjRedEvidencije()
    {
        this.findIdVozaca();
        var tabela = this.tabela;
        var element = this.vozaci.pop();
        let red = document.createElement("tr");
        red.className = "red";
        element.crtajRed(red);
        
        let delButton = document.createElement("button");
        delButton.innerHTML = "Obrisi";
        delButton.className = "Dugme";
        red.appendChild(delButton);
        tabela.appendChild(red);

        this.vozaci.push(element);

        delButton.onclick =(ev) =>
        {
            var flag = true;
            var labele = ["AM", "A1", "A2", "A", "B1", "B", "BE", "C1" ,"C1E" , "C", "CE", "D1", "D1E", "D", "DE", "F", "M"];
            
            {
                this.vozaci.forEach((vozac,index) =>
                {
                    if(element.getJMBG() === vozac.getJMBG())
                    {
                        vozac.izbrisiKategoriju(labele);
                        if(vozac.kategorije.length === 0)
                            flag = true;
                        if(flag === true)
                        {
                            fetch("https://localhost:5001/Evidencija/IzbrisiVozaca/" + vozac.id,{method:"DELETE"});
                            this.vozaci.splice(index, 1);
                            tabela.removeChild(red); 
                        }
                        else
                        {
                            alert("Neophodno je pre brisanja vozaca brisanje svih kategorije ");
                        }   
                    }
                });
            }   
        }
    }

    crtajEvidencijaFormu()
    {
        let red = document.createElement("tr");
        this.tabela.appendChild(red);
        
        let labele = ["Ime: ", "Prezime: ", "Broj dozvole: ", "JMBG: ", "Grad: ", "Kategorija: "];
        let heder = null;

        labele.forEach(element =>
            {
                heder = document.createElement("th");
                heder.innerHTML = element;
                red.appendChild(heder);
            })
    }

    validateJMBG(jmbg)
    {
        if(jmbg.length === 13)
        return true;
        else
        return false;
    }

    dodajVozaca(vozac)
    {
        this.vozaci.push(vozac);
        var evDiv = this.container.querySelector("listaVozaca");
        this.cratjRedEvidencije();
    }

    dodajUbazu()
    {
        var vozac = this.vozaci.pop();

            var kateg = this.cheksCategory();

        fetch("https://localhost:5001/Evidencija/UpisiVozaca/" + this.id,{
            headers:{
                "Content-Type":"application/json",
                "Access-Control-Allow-Origin": "*"
            },
            method:"POST",
            body:JSON.stringify(
                {
                    "imeVozaca": vozac.ime,
                    "prezimeVozaca": vozac.prezime,
                    "brojDozvole": vozac.brojDozvole,
                    "grad": vozac.grad,
                    "jmbg": vozac.jmbg
                }
            )
        }).then(p=>{
            if(p.ok)
            {
                p.json().then(data =>{
                    vozac.id = data.id;
                    var kateg = this.cheksCategory();
                    vozac.addCategory(kateg);
                    this.vozaci.push(vozac);
                    this.crtajVozace();
                })
            }
        });
    }

    findIdVozaca()
    {
        var vozac = this.vozaci.pop();
        vozac.getId();
        this.vozaci.push(vozac);
    }
    
    crtajVozace()
    {
        this.vozaci.forEach(el=>{
            el.osvezi();
        })
    }
}
