
# Projeto de Cadastro 📋

Este repositório apresenta um projeto de exemplo de um sistema de cadastro, criado como parte de um exercício de aprendizado, incluindo a configuração do banco de dados utilizando Docker.
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
#### 1. Preparando e aplicando as migrações do Entity Framework Core no container Docker
Antes de configurar e aplicar as migrações no banco de dados dentro do container Docker, adicione os seguitnes pacotes  ao projeto através do terminal:
```powershell
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Pomelo.EntityFrameworkCore.MySql
```
Após instalar os pacotes, você deve aplicar a migração ao banco utilizando o seguinte comando no diretório do projeto:
E para aplicar  ao banco de dados utilize o comando:
```powershell
dotnet ef database update
 ```
<img width="678" height="52" alt="image" src="https://github.com/user-attachments/assets/858d0449-9b14-4a18-9bac-79c333721d3e" />



### 4. verificação da migração do banco de dados  no container docker:
#### 1 Primeiro, entre dentro do container:
```Bash:
docker exec -it <nome_do_container> bash
```
#### 2. Em seguida, execute o seguinte comando dentro do container para acessar o banco como superusuário:
```bash
mysql -u root -p
````
#### 3 Verificação do banco de dado e tabelas criadas:
```bash
show databases;
##USE <nome-do_banco>;
USE meubancoApi;
##comando para verificar as tabélas
Show tables;
## em seguida
##SELECT * FROM <nome_da_tabela>;
SELECT * FROM Categorias;
````

### 5. Configuração da conexão do banco de dados do container com o DataGrip:
https://github.com/user-attachments/assets/d3fc448e-9128-4cd9-9074-2ad4f52a2293
### 6. Exibindo as tabélas
https://github.com/user-attachments/assets/48e633e2-2f1b-42cd-9f4c-f49d59d6e6ee


