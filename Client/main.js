import { Ministarstvo } from "./Ministarstvo.js";
import { Odsek } from "./Odsek.js";

var listaOdseka=[];

fetch("https://localhost:5001/Odsek/getOdsek")  // u okviru jsona, imamo odseke
.then(p => 
    {
        console.log(p);
        p.json().then(odseci => 
            {
                odseci.forEach(odsek => { // odseci su vise odseka, a jedan odsek je
                    var p = new Odsek(odsek.id, odsek.ime)
                    listaOdseka.push(p);
                });
                var m = new Ministarstvo(listaOdseka);
                m.draw(document.body);
            })
    })

console.log(listaOdseka);

