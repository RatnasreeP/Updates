function validate()
{

    var profile=[];
    var tempprofile=[];
    var pro={};
    var x,profile1;
    var c=0;

    passwordvalidate();
    pro.name1=document.getElementById("name").value;
    pro.password1=document.getElementById("password").value;

    

    profile.push(pro);

    localStorage.setItem('profile', JSON.stringify(profile));

    console.log(profile);
    redirect();

}
function namevalidate()
{
    var name1=document.getElementById("name").value;

    var reg = /^[a-zA-Z0-9_.-]+@[a-zA-Z0-9]+.([a-z]{2,3})+.([a-z]{2,3})$/;

    var bool=true;

    if(!(name1.match(reg)) || (name1.length==0))
    {
        alert("Enter valid name is should be like mail id");
        bool=false;
    }
    var name=[];
    name=name1.split("@");
}
function passwordvalidate()
{
    var bool=true;
    var password1=document.getElementById("password").value;
    var reg=/^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$/;
    if (password1.length<8||!(password1.match(reg)))
    {
        alert("password should be alphanumeric and length>=8");
        // return false;
    }
    redirect();
}
function redirect()
{

    var password1=document.getElementById("password").value;
    var name1=document.getElementById("name").value;
    if(name1 && password1)
    {
        alert("Welcome");
        window.location.href="home.html";
        console.log(window.location.href);

    }


}
