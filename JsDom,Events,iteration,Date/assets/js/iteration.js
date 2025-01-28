
///Arraydakileri gormek uchun
array.forEach(function(value,index,arr) {
    console.log(value);
});


///Arr her bir deyerin 2-e vurur qaytarir.
let newArr=array.map(function(value,index,arr){
    value*2
});


///Verilen serte uygun deyerleryi qaytarir(11-i silir)
let newarr=array.filter(function(value,index,arr){
    value!=11
});


//Verilen sert butun deyerlerde odenirse TRUE qaytarir.
console.log(array.every((value,index,arr)=>value>20));

//Verilen sert en az 1 deyerde odenirse TRUE qaytarir.
console.log(array.some((value,index,arr)=>value>20));


///Deyerlerin cemini tapr burada
let array=[23,56,23,100,37];
console.log(array.reduce((prev,next,index,arr)=>prev+next));


///Objects
let posts = [
  {
    "userId": 1,
    "id": 1,
    "title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
    "body": "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
  },
  {
    "userId": 1,
    "id": 2,
    "title": "qui est esse",
    "body": "est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla"
  },
  {
    "userId": 1,
    "id": 3,
    "title": "ea molestias quasi exercitationem repellat qui ipsa sit aut",
    "body": "et iusto sed quo iure\nvoluptatem occaecati omnis eligendi aut ad\nvoluptatem doloribus vel accusantium quis pariatur\nmolestiae porro eius odio et labore et velit aut"
  },
  {
    "userId": 1,
    "id": 4,
    "title": "eum et est occaecati",
    "body": "ullam et saepe reiciendis voluptatem adipisci\nsit amet autem assumenda provident rerum culpa\nquis hic commodi nesciunt rem tenetur doloremque ipsam iure\nquis sunt voluptatem rerum illo velit"
  },
  {
    "userId": 1,
    "id": 5,
    "title": "nesciunt quas odio",
    "body": "repudiandae veniam quaerat sunt sed\nalias aut fugiat sit autem sed est\nvoluptatem omnis possimus esse voluptatibus quis\nest aut tenetur dolor neque"
  },
  {
    "userId": 1,
    "id": 6,
    "title": "dolorem eum magni eos aperiam quia",
    "body": "ut aspernatur corporis harum nihil quis provident sequi\nmollitia nobis aliquid molestiae\nperspiciatis et ea nemo ab reprehenderit accusantium quas\nvoluptate dolores velit et doloremque molestiae"
  },
]
console.log(posts.filter(value=>value.id>4).reduce((total,next)=>total+next.id,0));
posts.forEach(value=>{
    console.log(value);
})


///Date
let date=new Date();
console.log(date.getHours());
console.log(date.getMinutes());
console.log(date.getSeconds());
//oturulen saniyeden sonra ishleyir.
setTimeout(function(){
alert("hello..")
},2000)
//Oturulen saniyeden bir ishleyir.
setInterval(()=>{
    console.log("salam");
},2000)

function getDate() {
  let date = new Date();
  let hour = date.getHours() > 10 ? date.getHours() : "0" + date.getHours();
  let second = date.getSeconds() > 10 ? date.getSeconds() : "0" + date.getSeconds();
  let minutes = date.getMinutes() > 10 ? date.getMinutes() : "0" + date.getMinutes();
  document.getElementById("watch").innerText = `${hour}:${minutes}:${second}`
}
setInterval(getDate, 1000);