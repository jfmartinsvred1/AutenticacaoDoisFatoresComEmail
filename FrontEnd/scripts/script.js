
const url = "https://localhost:7193/User/"
//Var Temps
let emailTemp=""
let logado;
let usernameTemp="";

//User
const txtUser=document.querySelector('.logado');

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

//Funcs Login

function sumirBtnLogin(){
    btnLogin.style.display='none'
}

function aparecerBtnLogin(){
    btnLogin.style.display='block'
}

function aparecerFormLogin(){
    formLogin.style.display='block'
}

function sumirFormLogin(){
    formLogin.style.display='none'
}

//Funcs Cadastro

function sumirBtnCadastro(){
    btnCadastro.style.display='none'
}

function aparecerBtnCadastro(){
    btnCadastro.style.display='block'
}

function aparecerFormCadastro(){
    formCadastro.style.display='block'
}

function sumirFormCadastro(){
    formCadastro.style.display='none'
}

function aparecerTxtSenhasNaoIguais(){
    txtSenha.style.display='block'
}

function sumirTxtSenhasNaoIguais(){
    txtSenha.style.display='none'
}
//Funcs Logado
function aparecerNomeUser(){
    txtUser.innerHTML=`Olá, ${usernameTemp}`
}

function telaDeLogado(){
    sumirBtnCadastro()
    sumirBtnLogin()
    sumirFormCadastro()
    sumirFormLogin()
    aparecerNomeUser()
}

if(logado){
    telaDeLogado()
}
function zerarTempsLogin(){
    usernameTemp=''
}

//Funcs Aut
function sumirTelaAut(){
    formAut.style.display='none'
}
function aparecerTelaAut(){
    formAut.style.display='block'
}
//Functions BtnsHtml
function clickBtnCadastro(){
    sumirBtnCadastro()
    aparecerFormCadastro()
    sumirFormLogin()
    aparecerBtnLogin()
}

function clickBtnLogin(){
    sumirBtnLogin()
    aparecerFormLogin()
    sumirBtnCadastro()
    sumirFormCadastro()
    sumirTelaAut()
}
//Functions 

function irParaTelaAutAposCadastro(){
    sumirFormCadastro()
    aparecerTelaAut()
    sumirTxtSenhasNaoIguais()
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
        irParaTelaAutAposCadastro()
        emailTemp=''
        console.log(emailTemp)
        postLogin(login)
    }
    else{
        zerarTempsLogin()
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
    if(response.ok){
        logado=true
        telaDeLogado()
        console.log(logado)
    }
    else{
        zerarTempsLogin()
    }
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
    usernameTemp=login.username
    emailTemp=emailCadastro.value;
    cadastro = JSON.stringify(cadastro);
    login = JSON.stringify(login);
    postCadastro(cadastro, login);
    }
    else{
        e.preventDefault()
        aparecerTxtSenhasNaoIguais()
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