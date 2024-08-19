# Desafio B3 [**Avaliação Dev 3**](https://github.com/aasf86/b3/blob/main/Avalia%C3%A7%C3%A3o%20Dev%203.pdf)
Solução para o desafio permitindo calcular CDB.

## 1º Clonar codigo fonte.
Execute a seguinte linha de comando: *"necessário git cli"*
```cmd
    git clone https://github.com/aasf86/b3
```
## 2º Construir ambiente
No diretório raiz do projeto, executar a seguinte linha de comando: *"necessário docker"*
```cmd
    docker-compose up -d
```
---
## 3º Demonstração de uso dos serviços.
Uma vez construido o ambiente, na maquina hospedeira é possivel acessar os servicos.

- Solução B3
    - B3.App: http://localhost:3003/
        - *Aplicação SPA responsável pela iteração visual com usuário fornecendo tela para calculo de CDB.*
    - B3.Api: http://localhost:8081/swagger/index.html
        - *Aplicação rest web api responsável pela regra e calculo do CDB.*