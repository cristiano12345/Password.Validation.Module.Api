## **Repositório: **


Api para cumprir o desafio de criar uma API robusta que possua inicialmente um *endpoint* para validação de senha.

## **Critério de validação**

Uma senha é considerada válida quando a mesma atender as seguintes regras:

- Nove ou mais caracteres
- Não possuir caracteres repetidos dentro do conjunto
- Ao menos 1 dígito
- Ao menos 1 letra minúscula
- Ao menos 1 letra maiúscula
- Ao menos 1 caractere especial
  - Os caracteres especiais aceitos são: ! @ # $ % ^ & * ( ) - +

Exemplo:  

```c#
IsValid("") // false  
IsValid("aa") // false  
IsValid("ab") // false  
IsValid("AAAbbbCc") // false  
IsValid("AbTp9!foo") // false  
IsValid("AbTp9!foA") // false
IsValid("AbTp9 fok") // false
IsValid("AbTp9!fok") // true
```

> **_Nota:_**  Espaços em branco não são considerados como caracteres válidos.

## **Premissas consideradas**

Tendo como base que a validação senha é algo bem simples e a princípio pode ser resolvido com uma *expressão regular* e 
poucas linhas de código, levou-se em consideração o seguinte:

* Esta api poderá estar inserida em um ecosistema maior que precise de escalabilidade e disponibilidade.
* A necessidade de estar preparada para receber novas features/funcionalidades sem degradar desempenho. 
E isso também justifica a decisão do *pattern* escolhido (CQRS)
* Que as regras de validação da senha é algo que possa ser modificado de forma rápida e por isso foi implementado o pattern "Specification"

* **Design de API:** Para criação da API seguiu-se o padrão de maturidade de REST. 
* **Endpoint:** O proposto foi a criação de um endpoint que recebesse uma senha para validação e devolvesse um booleano como resposta.
### **Organização da Solução**

O projeto está organizado da seguinte forma:

```
 +- Password.Validation.Module.Api
 |
 +- Password.Validation.Module.Application
 |
 +- Password.Validation.Module.Contract
 |
 +- Password.Validation.Module.CrossCutting
 |
 +- Password.Validation.Module.Service
 |
 +- Password.Validation.Module.Test 
```

Onde:

* `Password.Validation.Module.Api`: É onde fica o código responsável pela exposição da API.
* `Password.Validation.Module.Application`: Aqui ficam os *handlers* das requisições feitas a API, aqui são implementados os casos de usos.
* `Password.Validation.Module.Contract`: Projeto de modelos anêmicos dos quais apenas os contratos/models são implementados.
* `Password.Validation.Module.Service`: Aqui estão as regras da aplicação, todas as regras de negócios são implementadas aqui.
* `Password.Validation.Module.CrossCutting`: Aqui é a camada que faz o cruzamento de todas as demais, que "não se conhecem" mas que dependem indiretamente entre si, como o mecanismo de Injeção de Dependência.
* `Password.Validation.Module.Test`: Esta é a camada onde são estritors todos os testes.

## **Rotas & Contratos**

Essa api possui apenas um endpoint/rota que deve ser utilizado para chamadas de validação de senha:

```c#
POST /api/password/validate
```

Os contratos/modelos de requisição e respostas são:

*Requisição*
```c#
{
  "password": "string"
}
```

*Resposta
```c#
{
  "password": true|false
}
```

## **Execução usando Visual Studio**

* Faça o clone deste repositório
* Abra o projeto através do arquivo [`Password.Validation.Module.sln`]
* Defina o projeto `Password.Validation.Module.Api` como sendo o *start-up* da solução.
* Selecione o perfil de execução como `Kestrel`.
* Cliquem no menu `Debug` e em seguida na opção `Start Debugging` ou simplesmente pressione `F5`.
* Abra o navegador de sua preferência e acesse o endereço [http://localhost:5000] ou http://localhost:5000/swagger/index.html])
* Uma página do swagger com a documentação da api será apresentada e com opção de realização de chamadas de testes (`try out`)

Obrigado, estou à disposição!

Nome: Cristiano Alberto De Andrade
Email: cristiano.a.andrade@hotmail.com
Celular: 11 963752767
