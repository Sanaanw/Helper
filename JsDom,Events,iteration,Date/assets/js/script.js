//JS dom
///String seklinde html yazdirir
 document.write("<h1>salam</h1>")

///Verilen id li elementi goturur,Color deyisir
let h1=document.getElementById("text");
h1.style.color="red";

///Elemetleri TagName ve ClassName ile goturur(List qaytarir)
let list1 = document.getElementsByTagName("h1");
let list2 = document.getElementsByClassName("list");

///Ul icindeki butun li ve ilk li  qaytarir,Text idli qaytarir
let lies=document.querySelectorAll("ul li");
let li1=document.querySelector("ul li")
let h1=document.querySelector("#text");

///Get deyeri goturur,set ise deyeri deyisir(Class adi lorem edir)
console.log(h1.getAttribute("id"));
h1.setAttribute("class","lorem");

///Id olub olmadigini yoxluyur
console.log(h1.hasAttribute("id"));

///Ul goturur icini li elave edir
let list=document.querySelector("ul");
let li2=document.createElement("li");
//Elave etmek ucun
list.append(li);
//innertext stirng kimi elave edir.
li.innerText="<a href=''>salam</a>";
li.innerHTML="<a href=''>salam</a>"

///Ul icindeki li leri silmek ucun
//(getElementsByTagName ve querySelector arasindaki ferqi unutma)
 for (let li = 0; li < list.length; li++) {
   list[li].remove();
  }

/// a-nin hrefini silir burada
 document.querySelector("a").removeAttribute("href");




















