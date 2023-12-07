API de Autenticação de Dois Fatores com Envio de Código via Email em .NET Core
Bem-vindo à API de Autenticação de Dois Fatores desenvolvida em .NET Core. Esta API serve como um exemplo prático para entender e implementar um sistema robusto de autenticação de dois fatores, utilizando o envio de códigos via email para garantir a identidade do usuário.

Funcionalidades Principais
Registro de Usuário:

Cadastre-se na plataforma fornecendo as informações necessárias.
Login:

1-Faça o login na API usando suas credenciais.
Autenticação de Dois Fatores:

2-Após o login bem-sucedido, será necessário autenticar-se com um segundo fator.
Envio de Código via Email:

3-Um código de verificação será enviado para o endereço de email associado à conta.
Verificação do Código:

4-Insira o código recebido para concluir o processo de autenticação de dois fatores.
Pré-requisitos
Certifique-se de ter o SDK .NET Core instalado em sua máquina antes de iniciar.

Configuração
Clone o repositório:

bash
Copy code
https://github.com/jfmartinsvred1/AutenticacaoDoisFatoresComEmail
Navegue até o diretório do projeto:

bash
Copy code
cd nome-do-repositorio
Abra o arquivo appsettings.json e configure as informações do banco de dados e as credenciais do serviço de email.

Execute as migrações do banco de dados:

bash
Copy code
dotnet ef database update
Inicie a aplicação:

bash
Copy code
dotnet run
A API estará disponível em https://localhost:7193/ por padrão.

Uso
Registro:

Envie uma requisição POST para https://localhost:7193/user/cadastra com as informações do usuário.
Login:
  "username": 
  "email": 
  "password": 
  "rePassword": 

Autenticação:
  "email": "string",
  "code": "string"

Para verificar o código, envie uma requisição POST para /api/account/verifycode com o código recebido por email.
Contribuições
Contribuições são bem-vindas! Sinta-se à vontade para enviar pull requests ou relatar problemas.