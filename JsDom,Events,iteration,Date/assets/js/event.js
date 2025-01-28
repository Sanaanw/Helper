///EVENT


///Onclickde ish gormek ucun
let button = document.getElementById("btn");
button.onclick = function () {
  let h1 = document.getElementById("Front end")
  h1.style.color = "white";
  h1.style.backgroundColor = "black";
}


///Onclickden bir nece dene yazandan axrinci ishleyir,
//AddEventde ise sirayla hamisi ishleyir.
button.addEventListener("click", function () {
  alert("hello");
})
button.onclick = () => {
  alert("hi")
}


///Navbar working prinsipe
let icon = document.querySelector(".icon");
let button = document.querySelector(".button");
let sidebar = document.querySelector(".sidebar");
icon.onclick = function () {

  sidebar.classList.add("close");//Classname Yanina close yazdirir.
}
button.onclick = function () {
  sidebar.classList.remove("close")
}


///Inputlarin HTML-e yazilmasi
 let btn=document.querySelector(".button");
 let input=document.querySelector(".input");
 let list=document.querySelector(".list");
 btn.addEventListener("click",()=>{
 if(!input.value.trim().lentgh>0){
     alert("it's empty");
     return;
   }
list.innerHTML="";
for (let i = 1; i <= input.value; i++) {
    let li=`<li class="list-group-item">${i}</li>`
     list.innerHTML+=li;
 }
 input.value="";
 if(!input.value)
 {
    alert("bosh qoyma");
    return;
 }
let li=`<li class="list-group-item">${input.value}</li>`
list.innerHTML+=li;
 input.value="";
});


///input deyishib kenara cixanda ishleyir.
document.getElementById("input").onchange=()=>{
    console.log("input val changed..");
}
///inputa focus (toxunanda) ishleyir.
document.getElementById("input").onfocus=()=>{
    console.log("input focus");
}
///focusun ekse chole cixanda ishleyir.
document.getElementById("input").onblur=()=>{
    console.log("input blur");
}
///Search mentiqi yazdiqca ekrana cixardir.
document.getElementById("input").onkeyup=function(){
    console.log(this.value);
}
//Submitde SweetAlert ishlenmesi(CDN qoshmaghi unutma)(toastr,SweetAlert2github)
document.getElementById("form").onsubmit=function(ev){
    ev.preventDefault();
    Swal.fire({
        title: "Good job!",
        text: "You clicked the button!",
        icon: "success"
      });
}


