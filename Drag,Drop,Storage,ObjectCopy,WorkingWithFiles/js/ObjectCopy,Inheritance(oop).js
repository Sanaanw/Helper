
function Person(name,age) {
    this.name=name;
    this.age=age;
    this.getAge=function() {
        return this.age;
    }
}
let person1=new Person("Sanan",20);

const user ={
    name:"Sanan",
    age:"20",
    getAge:function(){
        return this.age;
    }
}

const user2=Object.assign({},user);
user2.name="Turan";
console.log(user.name);

Object.entries(object)
Object.keys(object)
Object.values(object)
///OOP deyl ama OOP yonumlu istfde etmek mumkundur
///Inheritance almaq 
class Person{
    constructor(name,surname){
        this.name=name;
        this.surname=surname;
    }
}
class Student extends Person{
    constructor(name,surname,address,point){
        super(name,surname)
        this.address=address;
        this.point=point;
    }
}
let person11=new Person("Lorem","Ipsum");
console.log(person11.name,person11.surname); 
let stu1=new Student("Lorem","Ipsum","Address1",20);
console.log(stu1.name);


