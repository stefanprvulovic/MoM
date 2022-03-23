import { Radnik } from "./Radnik.js";
import { Slucaj } from "./Slucaj.js";

export class Ministarstvo {
    constructor(listaOdseka) {
        this.listaOdseka = listaOdseka;
        this.container = null;
    }

    draw(host) {
        this.container = document.createElement("div");
        this.container.className = "mainContainer";
        host.appendChild(this.container);

        let naslov = document.createElement("h1");
        naslov.className = "naslov";
        naslov.innerHTML = "Ministarstvo Magije";
        this.container.appendChild(naslov);

        let containerSadrzaj = document.createElement("div");
        containerSadrzaj.className = "containerSadrzaj";
        this.container.appendChild(containerSadrzaj);

        let containerPretraga = document.createElement("div");
        containerPretraga.className = "containerPretraga";
        containerSadrzaj.appendChild(containerPretraga);

        let containerSlucaj = document.createElement("div");
        containerSlucaj.className = "containerSlucaj"
        containerSadrzaj.appendChild(containerSlucaj);

        let containerRadnik = document.createElement("div");
        containerRadnik.className = "containerRadnik";
        containerSadrzaj.appendChild(containerRadnik);

        this.drawPretraga(containerPretraga);
        this.drawSlucajevi(containerSlucaj);
        this.drawRadnici(containerRadnik);
    }

    deletePrev() {
        var prev = document.querySelector(".containerTable");
        var parent = prev.parentNode;
        parent.removeChild(prev);

        prev = document.createElement("table");
        prev.className = "containerTable";
        parent.appendChild(prev);

        return prev;
    }

    drawHeader(host) {
        var th;
        var colName = ["Kodno ime", "Status", "Nivo poverljivosti", "Kratak opis", "Zaduženi"];
        colName.forEach(p => {
            th = document.createElement("th");
            th.className = "Ime kolone"
            th.innerHTML = p;
            host.appendChild(th);
        });
    }

    drawPretraga(host) {
        var l = document.createElement("h2");
        l.innerHTML = 'Pretraga';
        host.appendChild(l);

        var l = document.createElement("label");
        l.innerHTML = 'Odsek:';
        host.appendChild(l);

        let divRbt = document.createElement("div");
        host.appendChild(divRbt);
        divRbt.className = "divZaRbt";

        this.listaOdseka.forEach(p => {
            let dugmeDiv = document.createElement("div");
            divRbt.appendChild(dugmeDiv);

            let rbt = document.createElement("input");
            rbt.type = "radio";
            rbt.value = p.id;
            rbt.className = "radioDugme";
            rbt.name = "Pretraga Odseka";
            dugmeDiv.appendChild(rbt);
            l = document.createElement("label");
            l.innerHTML = p.ime;
            dugmeDiv.appendChild(l);
        });

        var l = document.createElement("label");
        l.innerHTML = 'Status:';
        host.appendChild(l);


        let divSelect = document.createElement("div");
        divSelect.className = "divSelect";
        host.appendChild(divSelect);

        var se = document.createElement("select");
        se.className = "srcStatus";
        divSelect.appendChild(se);

        ['rešen', 'u procesu rešavanja'].forEach((el, ind) => {
            const op = document.createElement("option");
            op.innerHTML = el;
            op.value = ind;
            se.appendChild(op);
        });

        let divSrc = document.createElement("div");
        divSrc.className = "divTrazi";
        host.appendChild(divSrc);
        let bttnSrc = document.createElement("button");
        bttnSrc.className = "dugmeTrazi";
        bttnSrc.innerHTML = 'Traži';
        divSrc.appendChild(bttnSrc);

        let divTable = document.createElement("div");
        divTable.className = "divTable"
        this.container.appendChild(divTable);
        let containerTable = document.createElement("table");
        containerTable.className = "containerTable";
        divTable.appendChild(containerTable);

        // Trazi slucajeve po odseku
        bttnSrc.onclick = () => {
            containerTable = this.deletePrev();
            const odsek = this.container.querySelector("input[name='Pretraga Odseka']:checked");
            if (odsek) {
                fetch(`https://localhost:5001/Odsek/${odsek.value}/getSlucaj/${se.selectedOptions[0].value}`)
                    .then(async val => {
                        const slucajevi = await val.json();
                        if (slucajevi.length) {
                            this.drawHeader(containerTable);
                            slucajevi.forEach(x => {
                                let s = new Slucaj();
                                // console.log(s);
                                s.kodnoIme = x.kodnoIme;
                                if (x.status == 0) {
                                    s.status = "rešen";
                                }
                                else if (x.status == 1) {
                                    s.status = "u procesu rešavanja";
                                }
                                s.nivoPov = x.nivoPov;
                                s.opis = x.opis;
                                if (x.radnik.ime != null && x.radnik.prezime != null) {
                                    let ime = x.radnik.ime;
                                    let prezime = x.radnik.prezime;
                                    s.imeRadnika = ime + ' ' + prezime;
                                }
                                s.drawRow(containerTable);

                            }
                            );
                        }
                        else {
                            alert(`Nema takvih slučajeva!`);
                        }
                    })
                    .catch(er => console.log(er));
            }
            else {
                alert('Niste odabrali odsek!')
            }
        };
    }



    drawSlucajevi(host) {
        var n = document.createElement("h2");
        n.innerHTML = "Dodaj slučaj";
        host.appendChild(n);

        let addSlucaj = document.createElement("div");
        addSlucaj.className = "Dodavanje";
        host.appendChild(addSlucaj);

        let labelaIme = document.createElement("label");
        labelaIme.innerHTML = "Ime:";
        addSlucaj.appendChild(labelaIme);
        let imeInput = document.createElement("input");
        imeInput.className = "imeInput"
        addSlucaj.appendChild(imeInput);

        let povLabela = document.createElement("label");
        povLabela.innerHTML = "Nivo poverljivosti:";
        addSlucaj.appendChild(povLabela);

        let slcPov = document.createElement("select");
        slcPov.className = "povDugme";
        addSlucaj.appendChild(slcPov);

        ['poverljivo', 'ograničen pristup', 'javno'].forEach((el, ind) => {
            const o = document.createElement("option");
            o.innerHTML = el;
            o.value = ind;
            slcPov.appendChild(o);
        });

        let opisLab = document.createElement("label");
        opisLab.innerHTML = "Kratak opis:";
        addSlucaj.appendChild(opisLab);

        let textBox = document.createElement("textarea");
        textBox.className = "Opis";
        textBox.maxLength = 100;
        addSlucaj.appendChild(textBox);

        let odsLabela = document.createElement("label");
        odsLabela.innerHTML = "Odsek:";
        addSlucaj.appendChild(odsLabela);

        let slcOdsek = document.createElement("select")
        slcOdsek.className = "slcOdsek";
        addSlucaj.appendChild(slcOdsek);

        this.listaOdseka.forEach(p => {
            let od = document.createElement("option");
            od.innerHTML = p.ime;
            od.value = p.id;
            slcOdsek.appendChild(od);

        });

        let divDodaj = document.createElement("div");
        divDodaj.className = "divDodaj";
        addSlucaj.appendChild(divDodaj);

        let addButton = document.createElement("button");
        addButton.className = "dugmeDodaj";
        addButton.innerHTML = "Dodaj";
        divDodaj.appendChild(addButton);

        // Dodaj novi slucaj
        addButton.onclick = () => {
            let ime = addSlucaj.querySelector(".imeInput").value;
            let nivoPovSelected = addSlucaj.querySelector(".povDugme").selectedOptions[0].value;
            let nivoPov;
            if (nivoPovSelected == 0) {
                nivoPov = "poverljivo";
            }
            else if (nivoPovSelected == 1) {
                nivoPov = "ograničen pristup";
            }
            else if (nivoPovSelected == 2) {
                nivoPov = "javno";
            }
            let opis = addSlucaj.querySelector(".Opis").value;
            let odsekID = addSlucaj.querySelector(".slcOdsek").selectedOptions[0].value;
            if (ime && opis) {
                let s = new Slucaj(ime, nivoPov, opis, odsekID);
                fetch(`https://localhost:5001/Slucaj/addSlucaj/${s.odsekID}`,
                    {
                        method: "POST",
                        headers: {
                            'Content-Type': 'application/json',
                            'Accept': 'application/json'
                        },
                        body: JSON.stringify(s)
                    })
                    .then(response => response.json());
                alert(`Uspešno je dodat slučaj!`);
            }
            else {
                alert(`Niste popunili podatke!`);
            }
        }

        var n = document.createElement("h2");
        n.innerHTML = "Promeni status slučaja";
        host.appendChild(n);

        let setStatus = document.createElement("div");
        setStatus.className = "Status";
        host.appendChild(setStatus);

        let Ime = document.createElement("label");
        Ime.innerHTML = "Ime:";
        setStatus.appendChild(Ime);
        let Input = document.createElement("input");
        Input.className = "imeInput"
        setStatus.appendChild(Input);

        let statusLabel = document.createElement("label");
        statusLabel.innerHTML = "Status:";
        setStatus.appendChild(statusLabel);

        var se = document.createElement("select");
        se.className = "slcStatus";
        setStatus.appendChild(se);

        ['rešen', 'u procesu rešavanja'].forEach((el, ind) => {
            const op = document.createElement("option");
            op.innerHTML = el;
            op.value = ind;
            se.appendChild(op);
        });

        let divIzmeni = document.createElement("div");
        divIzmeni.className = "divIzmeni";
        setStatus.appendChild(divIzmeni);

        let buttonIzmeni = document.createElement("button");
        buttonIzmeni.className = "dugmeIzmeni";
        buttonIzmeni.innerHTML = "Promeni status";
        divIzmeni.appendChild(buttonIzmeni);

        buttonIzmeni.onclick = () => {
            let kodnoIme = setStatus.querySelector(".imeInput").value;
            let status = setStatus.querySelector(".slcStatus").selectedOptions[0].value;
            fetch(`https://localhost:5001/Slucaj/editStatus/${kodnoIme}`,
                {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json',
                        'Accept': 'application/json'
                    },
                    body: JSON.stringify(kodnoIme)
                })
                .then(response => response.json());
            alert(`Uspešno je izmenjen status slučaja!`);

        }
    }

    drawRadnici(host) {
        var n = document.createElement("h2");
        n.innerHTML = "Dodeli slučaj radniku";
        host.appendChild(n);

        let containerDodela = document.createElement("div");
        containerDodela.className = "Dodela";
        host.appendChild(containerDodela);

        let imeLabela = document.createElement("label");
        imeLabela.innerHTML = "Ime slučaja:";
        containerDodela.appendChild(imeLabela);

        let imeInput = document.createElement("input");
        imeInput.className = "imeSlucaja";
        containerDodela.appendChild(imeInput);

        let labelIme = document.createElement("label");
        labelIme.innerHTML = "Ime radnika:";
        containerDodela.appendChild(labelIme);

        let imeRadnik = document.createElement("input");
        imeRadnik.className = "imeInput1";
        containerDodela.appendChild(imeRadnik);

        let labelPrezime = document.createElement("label");
        labelPrezime.innerHTML = "Prezime radnika:";
        containerDodela.appendChild(labelPrezime);

        let prezimeRadnik = document.createElement("input");
        prezimeRadnik.className = "prezimeInput";
        containerDodela.appendChild(prezimeRadnik);

        let btnDodeli = document.createElement("button");
        btnDodeli.className = "dugmeDodeli";
        btnDodeli.innerHTML = "Dodeli";
        containerDodela.appendChild(btnDodeli);

        btnDodeli.onclick = () => {
            let ime = document.querySelector(".imeInput1").value;
            let prezime = document.querySelector(".prezimeInput").value;
            let imeSlucaja = document.querySelector(".imeSlucaja").value;
            let r = new Radnik();
            if (ime && prezime && imeSlucaja) {
                fetch(`https://localhost:5001/Radnik/getRadnikByName/${ime}/${prezime}`)
                    .then(async val => {
                        const radnik = await val.json();
                        if (radnik) 
                        {
                            radnik.forEach(x => {
                                r.id = x.id
                                r.ime = ime;
                                r.prezime = prezime;
                                console.log(r);
                            })

                            fetch(`https://localhost:5001/Slucaj/dodeliSlucaj/${r.id}/${imeSlucaja}`,
                                {
                                    method: 'PUT',
                                    headers: {
                                        'Content-Type': 'application/json',
                                        'Accept': 'application/json'
                                    },
                                    body: JSON.stringify(imeSlucaja)
                                })
                                .then(response => response.json());
                            alert(`Uspešno je dodeljen radnik slučaju!`);
                        }
                        else
                        {
                            alert("Ne postoji radnik sa takvim imenom!")
                        }
                    });
            }
            else {
                alert("Podaci nisu u potpunosti uneti!")
            }


        }

        var n = document.createElement("h2");
        n.innerHTML = "Otpusti radnika";
        host.appendChild(n);

        let brisanjeDiv=document.createElement("div");
        brisanjeDiv.className="brisanjeDiv";
        host.appendChild(brisanjeDiv);

        let lbIme=document.createElement("label");
        lbIme.innerHTML="Ime:";
        brisanjeDiv.appendChild(lbIme);

        let inpIme=document.createElement("input");
        inpIme.className="inpIme";
        brisanjeDiv.appendChild(inpIme);

        let lbPrezime=document.createElement("label");
        lbPrezime.innerHTML="Prezime:";
        brisanjeDiv.appendChild(lbPrezime);

        let inpPrezime=document.createElement("input");
        inpPrezime.className="inpPrezime";
        brisanjeDiv.appendChild(inpPrezime);

        let btnBrisi=document.createElement("button");
        btnBrisi.innerHTML="Obriši";
        btnBrisi.className="dugmeBrisi";
        brisanjeDiv.appendChild(btnBrisi);

        btnBrisi.onclick = () => {
            let ime = document.querySelector(".inpIme").value;
            let prezime = document.querySelector(".inpPrezime").value;
            let r = new Radnik();
            if (ime && prezime) {
                fetch(`https://localhost:5001/Radnik/getRadnikByName/${ime}/${prezime}`)
                    .then(async val => {
                        const radnik = await val.json();
                        if (radnik) 
                        {
                            radnik.forEach(x => {
                                r.id = x.id
                                r.ime = ime;
                                r.prezime = prezime;
                            })

                            fetch(`https://localhost:5001/Radnik/deleteRadnik/${r.id}`,
                            {
                                method: 'DELETE'
                            })
                            .then (s => {
                                if (s.ok) {s.json()}
                            })
                        }
                        else
                        {
                            alert("Ne postoji radnik sa takvim imenom!")
                        }});


        }


}
}}