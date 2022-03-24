import { Ministarstvo } from "./Ministarstvo.js";
import { Odsek } from "./Odsek.js";

const listaMinistarstva = [];

fetch('https://localhost:5001/Ministarstvo/getAll')
    .then(async response => {
        const data = await response.json();
        // console.log(data);
        data.forEach(ministarstvo => {
            const m = new Ministarstvo(ministarstvo.ime, ministarstvo.sprat, []);
``
            ministarstvo.odseci.forEach(odsek => {
                m.listaOdseka.push(new Odsek(odsek.id, odsek.ime));
            });

            m.draw(document.body);

            listaMinistarstva.push(m);
        });

        // console.log(listaMinistarstva);
    })
    .catch(error => console.log(error));