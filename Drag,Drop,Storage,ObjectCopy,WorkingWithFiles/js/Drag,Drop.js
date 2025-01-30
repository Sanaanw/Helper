///Releated with drag element
let dragElement1=document.querySelector(".dragElement1");

//Drag bashlianda ishliir.
dragElement1.ondragstart=function(){
    let id=dragElement1.id;
}
dragElement2.ondragstart=function(){
    let id=dragElement2.id;
}
//Havada qalanda ishliir.
dragElement.ondragend=function(){
    console.log("drag end");
}
//Drag bitende(biraxanda) ishliir.  
dragElement.ondrag=function(){
    console.log("drag");
}


///Releated with area
let area=document.querySelector(".area");
//Drag element areaya enter olanda.
area.ondragenter=function(){
    console.log("Drag element entered");
}
//Areani leave edende ishliir.
area.ondragleave=function(){
    console.log("Drag element leaved");
}
//area daxilinde(drag kimi).
area.ondragover=function(ev){
    ev.preventDefault();
    console.log("Drag element over");
}
area.ondrop=function(ev){
    area.append(dragElement1);
}



///Esas ishlenenler:
let dragElements=document.querySelectorAll(".dragElement");
let area=document.querySelector(".area");
let id;
dragElements.forEach(dragElement=>{
    dragElement.ondragstart=function(){
        id=dragElement.id;
    }
});
 area.ondragover=function(ev){
     ev.preventDefault();
 }
area.ondrop=function(){
    area.append(document.getElementById(id));
}