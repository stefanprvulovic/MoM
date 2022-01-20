export class Ministarstvo
{
    constructor(listaOdseka)
    {
        this.listaOdseka=listaOdseka;
        this.container=null;
    }

    draw(host)
    {
        this.container=document.createElement("div");
        this.container.className="mainContainer";
        host.appendChild(this.container);

        let naslov=document.createElement("h1");
        naslov.innerHTML='Ministarstvo Magije';
        this.container.appendChild(naslov);

        let containerPretraga = document.createElement("div");
        containerPretraga.className="Pretraga";
        this.container.appendChild(containerPretraga);

        let containerSlucaj=document.createElement("div");
        containerSlucaj.className="Slucajevi"
        this.container.appendChild(containerSlucaj);

        let containerRadnik=document.createElement("div");
        containerRadnik.className="Radnici";
        this.container.appendChild(containerRadnik);

        this.drawPretraga(containerPretraga);
        this.drawSlucajevi(containerSlucaj);
        this.drawRadnici(containerRadnik);
    }

    drawPretraga(host)
    {
        var l = document.createElement("h2");
        l.innerHTML='Pretraga';
        host.appendChild(l);

        var l = document.createElement("label");
        l.innerHTML='Odsek:';
        host.appendChild(l);

        var se =document.createElement("select");
        se.className="srcOdsek";
        host.appendChild(se);

        var op;
        this.listaOdseka.forEach(p =>{
            op = document.createElement("option");
            op.innerHTML=p.ime;
            op.value=p.id;
            se.appendChild(op);
        })

        // let divRbt=document.createElement("div");
        // host.appendChild(divRbt);
        // divRbt.className="divZaRbt"
        
        // this.listaOdseka.forEach(p => {
            
        //     let rbt = document.createElement("input");
        //     rbt.type="radio";
        //     rbt.value=p.id;
        //     rbt.name="radioDugmici";
        //     divRbt.appendChild(rbt);
        //     l = document.createElement("label");
        //     l.innerHTML=p.ime;
        //     divRbt.appendChild(l);
        // });

        var l = document.createElement("label");
        l.innerHTML='Status:';
        host.appendChild(l);

        var se = document.createElement("select");
        se.className="srcStatus";
        host.appendChild(se);

        var op;

        op = document.createElement("option");
        op.innerHTML='rešen';
        op.value=0;
        se.appendChild(op);
        op = document.createElement("option");
        op.innerHTML='u procesu rešavanja';
        op.value=1;
        se.appendChild(op);

        let bttnSrc = document.createElement("button");
        bttnSrc.className="dugmeTrazi";
        bttnSrc.onclick=(ev)=>this.findSlucajeve();
        bttnSrc.innerHTML='Traži';
        host.appendChild(bttnSrc);


    }

    findSlucajeve()
    {
        let odseci = this.container.querySelector("select");
        var odsekID=odseci.options[odseci.selectedIndex].value;
        console.log(odsekID);

        let statusi = this.container.document.querySelector("srcStatus");
        var statusID=statusi.options[statusi.selectedIndex].value;
        console.log(statusID);
        
    }

    drawSlucajevi(host)
    {
        var n = document.createElement("h2");
        n.innerHTML='Dodaj slučaj';
        host.appendChild(n);

        var n = document.createElement("h2");
        n.innerHTML='Promeni status slučaja';
        host.appendChild(n);  
    }

    drawRadnici(host)
    {
        var n = document.createElement("h2");
        n.innerHTML='Dodaj radnika';
        host.appendChild(n);

        var n = document.createElement("h2");
        n.innerHTML='Otpusti radnika';
        host.appendChild(n);
        
    }

    drawOption(host, description, value)
    {
        host = document.createElement("option");
        host.innerHTML=description;
        host.value=value;
        this.appendChild(op);
    }
}
