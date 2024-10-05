# FACULDADE DE INFORMÁTICA E ADMINISTRAÇÃO PAULISTA

# Projeto: Health&Med

# Integrantes

JULIO DA SILVA CRUZ – RM352759

JULIANO RONCOLETTA VERONEZ - RM352758

ERICK MOLIZANE ALMEIDA MOTTA – RM352724

# 1. OBJETIVO

Listagem de requisitos do Hackathon apresentado à Faculdade de Informática e Administração Paulista como parte das exigências do Curso de Pós-graduação de Arquitetura de Sistemas .NET com Azure.


# 2. FUNDAMENTAÇÃO TEÓRICA

## 2.1. ESTRUTURA DO PROJETO

O projeto é dividido em duas interfaces de programação de aplicação (APIs), são elas:
* Cadastro: responsável por cadastrar e autenticar o usuário;
* Agendamento: possibilita o agendamento de consultas e marcação de disponibilidade de médicos.

## 2.2. Casos de uso
Cadastrar médico:
O médico se cadastra no sistema.

![image](https://github.com/user-attachments/assets/ce41b41a-5847-4287-82d4-ac70cac52b25)


Cadastrar paciente:
O paciente se cadastra no sistema.

![image](https://github.com/user-attachments/assets/5d7fe949-9352-40d0-82e8-2d7ee3dff668)


Alterar horários de disponibilidade médica:
O médico ao efetuar login poderá alterar seus horários, acrescentando ou removendo horários, caso haja clientes com consultas marcadas o horário não poderá ser deletado.

![image](https://github.com/user-attachments/assets/9a6e265e-7151-4fb9-b20c-594c263f9f1f)


Agendar consulta:
O paciente ao efetuar login poderá consultar os médicos cadastrados, em seguida pesquisar os horários disponíveis de consulta do médico escolhido e agendar, o respectivo médico será informado sobre o agendamento através de um e-mail enviado pelo sistema.

![image](https://github.com/user-attachments/assets/e51cb5d8-cdd6-40e2-8c8f-78a7f898184d)


## 2.3. API CADASTRO

**Essa API cobre os requisitos funcionais número 1, 2, 4 e 5 do documento de requisitos fornecido pela FIAP.**

No cadastro e autenticação optou-se por criar dois _endpoints_, um para cadastro médico e outro para cadastro de pacientes, foi convencionado que o _front_ iria acionar cada um deles usando telas distintas. 
É importante haver a separação entre esses dois tipos de cadastro porque no __login__ tanto o paciente quanto o médico acessam usando e-mail e senha e em um quadro onde o médico também é paciente ele poderia fazer ambos os registros usando os mesmos dados.

A API segue o modelo de código limpo para melhor organização e para facilitar modificações futuras, tendo em vista que no momento o objetivo é criar um MVP.

### 2.3.1. Parâmetros de entrada

Existem no total quatro _endpoints_, sendo divididos em duas _controllers_, uma dedicada ao cadastro e autenticação de médicos e outra de pacientes, em ambos os casos a autenticação recebe os mesmos parâmetros de entrada.

Cadastro do Médico:
{
  "nome": "string",
  "cpf": "string",
  "cep": "string",
  "endereco": "string",
  "estado": "string",
  "crm": "string",
  "telefone": "string",
  "email": "string",
  "password": "string",
  "confirmPassword": "string"
}

Cadastro do Paciente:
{
  "nome": "string",
  "cpf": "string",
  "cep": "string",
  "endereco": "string",
  "estado": "string",
  "idade": "string",
  "telefone": "string",
  "email": "string",
  "password": "string",
  "confirmPassword": "string"
}

Autenticação:
{
  "email": "string",
  "senha": "string"
}

### 2.3.2. Requisitos funcionais

* Criptografar senha para salvar;
* Campos "CPF" sendo _strings_ para se adequar ao formato hexadecimal que será necessário em um futuro próximo;
* Validar se o CPF está no formato correto;
* Validar se o e-mail registrado é composto por "[caracteres]@[caracteres]";
* Validar a senha cadastrada que deve conter 6 caracteres no total (números, letras e caracteres especiais);
* Validar se o CRM está no formato correto;
* O médico deverá poder se cadastrar preenchendo os campos obrigatórios: Nome, CPF, Número CRM, E-mail e Senha;
* O paciente poderá se cadastrar preenchendo os campos Nome, CPF, E- mail e Senha;
* O sistema deve permitir que o médico faça login usando o e-mail e uma senha;
* O sistema deve permitir que o paciente faça login usando E-mail e Senha.

### 2.3.3. Requisitos não funcionais

* Banco de dados PostGreSQL;
* .NET 8;
* Arquitetura limpa.


## 2.4. API Agendamento

**Essa API cobre os requisitos funcionais número 3, 6, 7 e 8 e requisitos não funcionais número 1 e 2 do documento de requisitos fornecido pela FIAP.**

A API segue o modelo de código limpo com minimal API para melhor manutenção e agilizar o desenvolvimento do MVP.

### 2.4.1. Parâmetros de entrada

Agendamento
{
  "pacienteId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "especialidadeMedicoId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "dataHoraAtendimento": "2024-10-05T18:36:28.066Z"
}
Listagem de agendamento
* string ID.

Edição do Horário do médico
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "pacienteId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "especialidadeMedicoId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "dataHoraAtendimento": "2024-10-05T18:36:47.569Z"
}

### 2.4.2. Requisitos funcionais

* Possibilitar cadastro/edição de horários disponíveis pelo médico;
* O sistema deve permitir busca por médicos pelo paciente;
* O sistema deve permitir ao paciente marcar consultas dentro da tabela de horários disponíveis do médico;
* O sistema deve informar ao respectivo médico da consulta marcada pelo paciente.


### 2.4.3. Requisitos não funcionais

* Testes unitários utilizando a biblioteca XUnit;
* Cobertura mínima de testes de trinta por cento;
* Concorrência de Agendamentos;
* Validação de Conflito de Horários;
* Banco de dados PostGreSQL;
* .NET 8;
* Arquitetura limpa.

## 2.5. EXECUÇÃO

Para fazer a execução basta executar o comando `docker-compose up -d` que fará a geração da infraestrutura e em seguida executar as APIs.

