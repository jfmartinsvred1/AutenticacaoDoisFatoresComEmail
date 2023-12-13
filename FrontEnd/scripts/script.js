
const url = "https://localhost:7193/User/"
let emailTemp=""

//FormLogin
const usernameLogin=document.getElementById('usernameLogin');
const passwordLogin=document.getElementById('passwordLogin');
const btnLogin=document.querySelector(".btnLogin");
const formLogin=document.querySelector(".logar");
const submitLogin=document.getElementById('sumitLogin');
const loginForm=document.querySelector('#loginForm');

//FormCadastro
const cadastroForm=document.querySelector('#cadastroForm')
const usernameCadastro=document.querySelector('#username')
const emailCadastro=document.querySelector('#email')
const passwordCadastro=document.querySelector('#password')
const rePasswordCadastro=document.querySelector('#rePassword')
const txtSenha=document.querySelector('.txtSenha');
const btnCadastro=document.querySelector(".btnCadastro");
const formCadastro=document.querySelector(".cadastro");
const submitCadasto=document.querySelector(".submitCadastro");

//FormAut
const autForm=document.querySelector("#aut");
const codAut=document.querySelector("#codAut");
const formAut =document.querySelector('.aut');



function sumirBtnCadastroEIrParaTelaDeCadastro(){
    btnCadastro.style.display='none'
    formCadastro.style.display='block'
    formLogin.style.display='none';
    btnLogin.style.display='block';
}

function sumirBtnLoginEIrTelaDeLogin(){
    btnLogin.style.display='none'
    formLogin.style.display='block'
    btnCadastro.style.display='block'
    formCadastro.style.display='none'
    formAut.style.display='none'
}

//Sumir a tela cadastro
function aparecerTelaAut(){
    formCadastro.style.display='none'
    formAut.style.display='block'
}

//Post cadasto
async function postCadastro(cadastro, login){
    const response = await fetch(`${url}cadastra`,{
        method:"POST",
        body: cadastro,
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        }
    });
    const data = await response.json();
    console.log(data);
    if(response.ok){
        console.log(emailTemp)
        aparecerTelaAut()
        emailTemp=''
        console.log(emailTemp)
        postLogin(login)
    }
}

//Post Aut 

async function postAut(aut){
    const response = await fetch(`${url}autentica`,{
        method:"POST",
        body: aut,
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        }
    });

    const data = await response.json();
    console.log(data);
}

//PostLogin
async function postLogin(login){
    const response= await fetch(`${url}login`,{
        method:"POST",
        body:login,
        headers:{
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        }
    });
    const data = await response.json();
    console.log(data);
}


cadastroForm.addEventListener('submit', (e)=>{
    if(passwordCadastro.value==rePasswordCadastro.value){
        e.preventDefault();

    let cadastro={
        username: usernameCadastro.value,
        email: emailCadastro.value,
        password: passwordCadastro.value,
        rePassword:passwordCadastro.value
    }
    let login={
        username:cadastro.username,
        password:cadastro.password,
        headers:{
            'Content-Type':'application/json',
            'Accept': 'application/json'
        }
    }
    emailTemp=emailCadastro.value;
    cadastro = JSON.stringify(cadastro);
    login = JSON.stringify(login);
    postCadastro(cadastro, login);
    }
    else{
        e.preventDefault()
        txtSenha.style.display='block'
    }
})

autForm.addEventListener('submit', (e)=>{
    e.preventDefault();
    let aut={
        email:emailTemp,
        code:codAut.value, 
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        }
    }
    aut = JSON.stringify(aut);

    postAut(aut);
})

loginForm.addEventListener('submit', (e)=>{
    e.preventDefault();
    let login={
        username:usernameLogin.value,
        password:passwordLogin.value,
        headers:{
            'Content-Type':'application/json',
            'Accept': 'application/json'
        }
    }
    login = JSON.stringify(login);

    postLogin(login);
})