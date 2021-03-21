import { Evidencija } from "./evidencija.js";
import { Kategorija } from "./kategorija.js";
import { Vozacka } from "./vozacka.js";

fetch("https://localhost:5001/Evidencija/PreuzmiEvidencije").then(p =>{
    p.json().then(data1 => {
        data1.forEach(evid =>{

                const evidencija = new Evidencija(evid.id, evid.imeDrzave);
                evidencija.crtaj(document.body);
                
                fetch("https://localhost:5001/Evidencija/PreuzimiVozaca/" + evid.id).then(s =>{
                    s.json().then(data2 => {
                        data2.forEach(vozac =>
                            {
                                //ovde se kreira vozac
                                var Vozac = new Vozacka(vozac.id, vozac.imeVozaca, vozac.prezimeVozaca, vozac.brojDozvole, vozac.jmbg, vozac.grad, "");
                                fetch("https://localhost:5001/Evidencija/PreuzmiKategorije/" + vozac.id).then(d => {
                                    d.json().then(data3 =>{
                                        data3.forEach(kategorija =>{
                                            Vozac.dodajKategoriju(kategorija.kategorije, kategorija.id);
                                            Vozac.osvezi();  
                                        });
                                    });
                                });
                                evidencija.dodajVozaca(Vozac);
                                //ovde se kreira vozac
                            });
                    });
                });
            });
    });
});

//const evidencija = new Evidencija("Srbija");
//evidencija.crtaj(document.body);

