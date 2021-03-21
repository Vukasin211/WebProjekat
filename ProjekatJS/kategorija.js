export class Kategorija
{
    constructor(id, ime)
    {
        this.id = id;
        this.ime = ime;
    }

    getKategorija()
    {
        return this.ime;
    }

    ubaciUbazu(idVozaca)
    {
        this.idVozaca = idVozaca;
        fetch("https://localhost:5001/Evidencija/UpisiKategoriju/" + this.idVozaca,{
            headers:{
                "Content-Type":"application/json"
            },
            method:"POST",
            body:JSON.stringify(
                {
                    "kategorije": this.ime
                }
            )
        });
    }

    brisiIzBaze()
    {
        fetch("https://localhost:5001/Evidencija/IzbrisiKategoriju/" + this.id,{method:"DELETE"});
    }
}