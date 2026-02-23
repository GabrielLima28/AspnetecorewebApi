

https://github.com/user-attachments/assets/e4a5cd8e-7b0c-4b0b-ac52-13f49de92ccd

# Projeto de Cadastro 📋

Este repositório é dedicado a uma pequena demonstração de um mini projeto de cadastro, incluindo a configuração do banco de dados utilizando **Docker**.

## Configuração do Banco de Dados 🐬

Demonstração da **configuração e gerenciamento de um banco de dados MySQL em ambiente containerizado com Docker**, utilizando volumes para persistência de dados e variáveis de ambiente para definir credenciais de acesso, com a utilização da interface gráfica do **DataGrip** para visualizar e interagir com o banco.

## Objetivos
- Praticar conceitos de containerização com Docker  
- Configurar e gerenciar um banco de dados MySQL  
- Garantir persistência de dados com volumes  
- Utilizar o **DataGrip** como ferramenta gráfica para explorar tabelas, executar queries e administrar o banco  

### 1. Criação do  volume
```bash
##docker volume create <nome_do_volume>
docker volume create volume
````
### 2. Criando o Container
```bash
##docker container run -d --name mysql -p 3306:3306 -v <nome_do_volume>:/var/lib/mysql -e MYSQL_ROOT_PASSWORD=123 -e MYSQL_USER=<nome_do_usuario>  -e MYSQL_PASSWORD=123  mysql:latest
docker container run -d --name mysql -p 3306:3306 -v volume:/var/lib/mysql -e MYSQL_ROOT_PASSWORD=123 -e MYSQL_USER=Gabriel  -e MYSQL_PASSWORD=Admin123  mysql:latest
```
### 3. configuração do Banco de dados 

https://github.com/user-attachments/assets/d3fc448e-9128-4cd9-9074-2ad4f52a2293





https://github.com/user-attachments/assets/48e633e2-2f1b-42cd-9f4c-f49d59d6e6ee


