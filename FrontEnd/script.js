const url = "https://localhost:7193/User/"
let emailTemp=""

const btnCadastro=document.querySelector(".btnCadastro");
const formCadastro=document.querySelector(".cadastro");
const submitCadasto=document.querySelector(".submitCadastro");

//FormCadastro
const cadastroForm=document.querySelector('#cadastroForm')
const usernameCadastro=document.querySelector('#username')
const emailCadastro=document.querySelector('#email')
const passwordCadastro=document.querySelector('#password')
const rePasswordCadastro=document.querySelector('#rePassword')

//FormAut
const autForm=document.querySelector("#aut");
const codAut=document.querySelector("#codAut");

const btnLogin=document.querySelector(".btnLogin");
const formLogin=document.querySelector(".logar");

const formAut =document.querySelector('.aut');



//Sumir o btn cadastro e aparecer a tela de cadastro
btnCadastro.addEventListener('click', ()=>{
    btnCadastro.style.display='none'
    formCadastro.style.display='block'
})

btnLogin.addEventListener('click', ()=>{
    btnLogin.style.display='none'
    formLogin.style.display='block'
})

//Sumir a tela cadastro
submitCadasto.addEventListener('click', ()=>{
    formCadastro.style.display='none'
    formAut.style.display='block'


})

//Post cadasto
async function postCadastro(cadastro){
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


cadastroForm.addEventListener('submit', (e)=>{
    e.preventDefault();

    let cadastro={
        username: usernameCadastro.value,
        email: emailCadastro.value,
        password: passwordCadastro.value,
        rePassword:passwordCadastro.value
    }
    emailTemp=emailCadastro.value;
    cadastro = JSON.stringify(cadastro);

    postCadastro(cadastro);
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
