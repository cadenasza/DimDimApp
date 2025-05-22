# DimDimApp - Checkpoint 3 - FIAP

Projeto realizado para o 3º Checkpoint de Containers com Docker.

## 🚀 Tecnologias Utilizadas

- ASP.NET Core MVC (.NET)
- Oracle XE
- Docker + Docker Compose
- Git & GitHub

---

## 🐳 Como Executar o Projeto

> Pré-requisitos: Docker e Git instalados

 Estrutura dos Containers
dimdim-api: Container da aplicação ASP.NET MVC

oracle: Container com Oracle XE (banco de dados)

Ambos estão conectados na mesma rede Docker.

- Variáveis de Ambiente
Definidas no Dockerfile e docker-compose.yml:

ORACLE_PASSWORD

ASPNETCORE_ENVIRONMENT

👨‍💻 Equipe
Leonardo Cadena de Souza - RM: 557528