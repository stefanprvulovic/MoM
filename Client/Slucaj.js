export class Slucaj
{
    constructor(kodnoIme, nivoPov, opis, odsekID, imeRadnika="nije dodeljen")
    {
        this.kodnoIme=kodnoIme;
        this.nivoPov=nivoPov;
        this.opis=opis;
        this.odsekID=odsekID;
        this.imeRadnika=imeRadnika;
    }

    drawRow(host)
    {
        var row=document.createElement("tr");
        host.appendChild(row);

        var info=document.createElement("td");
        info.innerHTML=this.kodnoIme;
        row.appendChild(info);

        var info=document.createElement("td");
        info.innerHTML=this.status;
        row.appendChild(info);

        var info=document.createElement("td");
        info.innerHTML=this.nivoPov;
        row.appendChild(info);

        var info=document.createElement("td");
        info.innerHTML=this.opis;
        row.appendChild(info);

        var info=document.createElement("td");
        info.innerHTML=this.imeRadnika;
        row.appendChild(info);
    }
}